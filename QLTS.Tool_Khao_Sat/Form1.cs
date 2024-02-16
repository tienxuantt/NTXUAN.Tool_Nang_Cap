using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using QLTS.Tool_Khao_Sat.BL;
using QLTS.Tool_Khao_Sat.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTS.Tool_Khao_Sat
{
    public partial class fForm : Form
    {
        // Api thao tác với dữ liệu
        private HttpApi api = null;

        // Biến cờ thông báo có khảo sát tiếp k
        private bool upgradeActive = true;

        public string scriptExecute = "";

        // Các tỉnh trên chương trình
        private List<Tenant> tenants = new List<Tenant>();

        private List<Tenant> tenantsUpgrade = new List<Tenant>();

        private int TotalTenantUpgrade = 0;
        private int TotalTenantUpgradeSuccess = 0;

        private int TotalTenantUpgradeDone = 0;
        private int TotalTenantUpgradeFail = 0;

        private string pathFileExcel = string.Empty;
        private List<string> listJsonExcel = new List<string>();

        // Số thread đang thực hiện
        private int countProcess = 0;
        // Tối đa bao nhiêu thread
        private int maxProcess = 10;
        private int timer = 200;
        private int numRun = 50;

        private bool isSaveOutput = false;
        private bool isSaveExcel = false;
        private bool isExecuteOutput = false;
        private bool isLoadAllTenant = false;

        private object key = new object();
        private object key2 = new object();

        public fForm()
        {
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            api = new HttpApi();

            LoadCookie();
        }

        private void LoadCookie()
        {
            CookieJson result = new CookieJson();

            result = api.LoadCookieJson();

            txtCookie.Text = result.Cookie;

            api.CookieValue = result.Cookie;
        }

        // Lưu lại cookie
        private void btnSaveCookie_Click(object sender, EventArgs e)
        {
            var cookie = txtCookie.Text;

            if (string.IsNullOrEmpty(cookie))
            {
                MessageBox.Show("Vui lòng điền cookie", "Thông báo");
            }
            else
            {
                api.CookieValue = cookie;

                api.SaveCookieJson(cookie);
            }
        }

        // Binding vào listview1
        private void BindingListView1(List<Tenant> tenantBind = null)
        {
            int STT = 1;

            listView1.Items.Clear();

            if(tenantBind == null)
            {
                tenantBind = tenants;
            }

            foreach (var item in tenantBind)
            {
                ListViewItem lsvItem = new ListViewItem("");

                lsvItem.SubItems.Add(STT.ToString());
                lsvItem.SubItems.Add(item.tenant_name);

                lsvItem.UseItemStyleForSubItems = false;
                if (!string.IsNullOrEmpty(item.error))
                {
                    lsvItem.SubItems.Add("Có lỗi xảy ra");
                    lsvItem.ToolTipText = item.error;

                    lsvItem.SubItems[2].ForeColor = Color.Red;
                }
                else if(item.survey_success)
                {
                    lsvItem.SubItems[2].ForeColor = Color.Blue;
                    lsvItem.SubItems.Add("Done");
                }
                else
                {
                    lsvItem.SubItems.Add("");
                }

                lsvItem.Tag = item;

                listView1.Items.Add(lsvItem);

                STT++;
            }
        }

        // Lọc full tenant trên chương trình
        private async Task GetListTenant()
        {
            tenants = new List<Tenant>();

            List<Tenant> result = new List<Tenant>();

            List<string> tenantIgnore = new List<string>()
            {
                "authen",
                "register",
                "demo",
                "test",
                "thidiem"
            };

            result = await api.GetTeants();

            result = result.OrderBy(s => s.tenant_code).ToList();

            foreach (var item in result)
            {
                bool valid = true;

                foreach (var item2 in tenantIgnore)
                {
                    if (item.tenant_code.ToLower().Contains(item2))
                    {
                        valid = false;
                    }
                }

                if (valid || isLoadAllTenant)
                {
                    item.survey_success = false;
                    item.error = "";
                    item.tenant_name = item.tenant_name.Replace("Tỉnh ", "");

                    tenants.Add(item);
                }
            }
        }

        // Validate cookie
        private bool ValidateForm(bool isValidateScript = false)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(api.CookieValue))
            {
                valid = false;

                MessageBox.Show("Vui lòng nhập cookie", "Thông báo");
            }

            if (isValidateScript && valid && string.IsNullOrEmpty(scriptExecute))
            {
                valid = false;

                MessageBox.Show("Vui lòng sửa script", "Thông báo");
            }

            return valid;
        }

        private async void btnLoadTeant_Click(object sender, EventArgs e)
        {
            isLoadAllTenant = false;

            try
            {
                if (!ValidateForm())
                {
                    return;
                }

                // Lấy các tỉnh
                await GetListTenant();

                BindingListView1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Có lỗi xảy ra");
            }
        }

        // Bắt đầu khảo sát các subject được chọn
        private void StartUpgrade()
        {
            pathFileExcel = Application.StartupPath + "/Data/FileExcelOutput.xlsx";
            listJsonExcel = new List<string>();

            // Lấy các biến
            isSaveOutput = checkBoxSaveOutput.Checked;
            isExecuteOutput = checkBoxExecute.Checked;
            isSaveExcel = checkSaveExcel.Checked;

            // Lấy ra các subject khảo sát
            tenantsUpgrade = GetListTenantUpgrade();

            // Tổng vấn đề khảo sát
            TotalTenantUpgrade = tenantsUpgrade.Count;
            // Reset vấn đề
            TotalTenantUpgradeSuccess = 0;
            // Lấy timer
            timer = Int32.Parse(txtTimer.Text);
            numRun = Int32.Parse(txtRun.Text);

            TotalTenantUpgradeDone = 0;
            TotalTenantUpgradeFail = 0;

            // Bật cờ
            upgradeActive = true;

            // Xóa file log
            ClearFileLog();

            // Tạo một luồng riêng cho khảo sát
            Thread thread = new Thread(async () => {
                StartUpgradeBackground();
            });

            thread.IsBackground = true;
            thread.Start();
        }

        // Bắt đầu khảo sát
        private void StartUpgradeBackground()
        {
            while (upgradeActive && TotalTenantUpgradeSuccess < TotalTenantUpgrade)
            {
                Thread.Sleep(timer);

                if (countProcess < maxProcess)
                {
                    var tenant = tenantsUpgrade.FirstOrDefault(s => !s.survey_success);

                    if (tenant != null)
                    {
                        tenant.survey_success = true;
                        tenant.error = "";

                        NewProcessExecuteScript(tenant);
                    }
                }
            }

            if (isSaveExcel)
            {
                try
                {
                    if (listJsonExcel.Count > 0)
                    {
                        ExportDataTableToExcel_ClosedXML();
                    }

                    MessageBox.Show("Xuất excel thành công", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xuất excel lỗi");
                }
            }
            else
            {
                MessageBox.Show("Nâng cấp thành công", "Thông báo");
            }
        }

        // Cập nhật lại số tỉnh, số đơn vị lỗi
        private void UpdateListViewItem(Tenant tenant, bool isStart = false)
        {
            var listItem = listView1.CheckedItems;

            if (listItem.Count > 0)
            {
                for(var i = 0; i< listItem.Count; i++)
                {
                    if(listItem[i].SubItems[2].Text == tenant.tenant_name)
                    {
                        listItem[i].UseItemStyleForSubItems = false;
                        listItem[i].SubItems[2].ForeColor = Color.Blue;

                        listItem[i].Tag = tenant;

                        if (isStart)
                        {
                            listItem[i].SubItems[3].Text = "Đang nâng cấp...";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(tenant.error))
                            {
                                listItem[i].UseItemStyleForSubItems = false;
                                listItem[i].SubItems[3].ForeColor = Color.Red;
                                listItem[i].SubItems[3].Text = tenant.error;
                                listItem[i].SubItems[3].Font = new Font(listView1.Font, FontStyle.Bold);
                            }
                            else
                            {
                                listItem[i].UseItemStyleForSubItems = false;
                                listItem[i].SubItems[3].ForeColor = Color.Blue;
                                listItem[i].SubItems[3].Text = "Done";
                                listItem[i].SubItems[3].Font = new Font(listView1.Font, FontStyle.Bold);
                            }
                        }

                        break;
                    }
                }
            }
        }

        // Lấy các bản ghi được chọn
        private List<Tenant> GetListTenantUpgrade()
        {
            List<Tenant> listResult = new List<Tenant>();

            var listItem = listView1.CheckedItems;

            if(listItem.Count > 0)
            {
                foreach (ListViewItem item in listItem)
                {
                    Tenant tenant = item.Tag as Tenant;

                    tenant.survey_success = false;
                    tenant.error = "";

                    listResult.Add(tenant);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi", "Thông báo");
            }

            return listResult;
        }

        private void NewProcessExecuteScript(Tenant tenant)
        {
            listView1.Invoke(new MethodInvoker(() =>
            {
                UpdateListViewItem(tenant, true);
            }));

            lock (key)
            {
                countProcess++;
            }

            Thread thread = new Thread(async () => {
                try
                {
                    List<DataV2> result = new List<DataV2>();
                    object resultJson = null;

                    if (isSaveExcel)
                    {
                        resultJson = await api.ExecuteScriptJson(tenant.tenant_id.ToString(), scriptExecute);
                    }
                    else
                    {
                        result = await api.ExecuteScript(tenant.tenant_id.ToString(), scriptExecute);
                    }

                    // Lưu lại kết quả
                    if (isSaveOutput)
                    {
                        SaveOutputResult(result);
                    }

                    // Lưu kết quả ra excel
                    if (isSaveExcel)
                    {
                        lock (key2)
                        {
                            listJsonExcel.Add(resultJson.ToString());
                        }
                    }

                    // Chạy luôn script
                    if (isExecuteOutput && result.Count > 0)
                    {
                        var querys = result.Select(s => s.Data).ToList();

                        await RunScript(tenant, querys);
                    }

                    lock (key)
                    {
                        TotalTenantUpgradeDone++;
                    }
                }
                catch (Exception ex)
                {
                    tenant.error = ex.Message;
                    
                    lock (key)
                    {
                        TotalTenantUpgradeFail++;
                    }
                }

                lock (key)
                {
                    TotalTenantUpgradeSuccess++;
                }

                labelTenantProcess.Invoke(new MethodInvoker(() =>
                {
                    labelTenantProcess.Text = string.Format("{0}/{1}", TotalTenantUpgradeSuccess, TotalTenantUpgrade);
                }));

                labelSuccess.Invoke(new MethodInvoker(() =>
                {
                    labelSuccess.Text = string.Format("Success: {0}", TotalTenantUpgradeDone);
                }));

                labelFail.Invoke(new MethodInvoker(() =>
                {
                    labelFail.Text = string.Format("Fail: {0}", TotalTenantUpgradeFail);
                }));

                listView1.Invoke(new MethodInvoker(() =>
                {
                    UpdateListViewItem(tenant);
                }));

                lock (key)
                {
                    countProcess--;
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        private void ExportDataTableToExcel_ClosedXML()
        {
            string jsonString = listJsonExcel.FirstOrDefault(s => s.Length > 10);

            JArray jsonArray = JArray.Parse(jsonString);

            // Tạo một Workbook
            using (var workbook = new XLWorkbook())
            {
                // Tạo một Worksheet
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Thêm dòng tiêu đề vào Worksheet
                int colIndex = 1;

                foreach (JToken token in jsonArray[0])
                {
                    worksheet.Cell(1, colIndex).Value = token.Path.Replace("[0].", "");
                    colIndex++;
                }

                int rowIndex = 2;

                foreach (var jsonItem in listJsonExcel)
                {
                    var jsonArrayItem = JArray.Parse(jsonItem);

                    foreach (JObject jsonObject in jsonArrayItem)
                    {
                        colIndex = 1;
                        foreach (JProperty property in jsonObject.Properties())
                        {
                            worksheet.Cell(rowIndex, colIndex++).Value = GetValueExcel(property.Value.ToString());
                        }
                        rowIndex++;
                    }
                }

                // Lưu file Excel
                workbook.SaveAs(pathFileExcel);
            }
        }

        private XLCellValue GetValueExcel(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch (Exception)
            {
            }

            return value;
        }

        private async Task RunScript(Tenant tenant, List<string> listScript)
        {
            int index = 1;
            string scriptRun = "";

            for (int i = 0; i < listScript.Count; i++)
            {
                scriptRun += listScript[i] + " \n ";

                if (index >= numRun || (i == listScript.Count - 1))
                {
                    Thread.Sleep(2000);

                    try
                    {
                        var result = await api.ExecuteScript(tenant.tenant_id.ToString(), scriptRun);
                    }
                    catch (Exception ex)
                    {
                    }

                    scriptRun = "";
                    index = 1;
                }
                else
                {
                    index++;
                }
            }
        }

        private void ClearFileLog()
        {
            string filePath = Application.StartupPath + "/Data/LogKhaoSat.txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void SaveOutputResult(List<DataV2> listData)
        {
            try
            {
                string filePath = Application.StartupPath + "/Data/LogKhaoSat.txt";

                foreach (var item in listData)
                {
                    api.WriteLog(string.Format("{0} \n",item.Data), filePath);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            upgradeActive = false;
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            upgradeActive = true;

            if (!ValidateForm(true))
            {
                return;
            }

            StartUpgrade();
        }

        private void btnEditScript_Click(object sender, EventArgs e)
        {
            var formScript = new fFormScript(this);

            formScript.Show();
        }

        private void SetSelectedAll(bool isSelected)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = isSelected;
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectedAll(checkBoxAll.Checked);
        }

        private async Task DeleteMisaQlts()
        {
            try
            {
                List<Tenant> listTenant = new List<Tenant>();

                listTenant = await api.GetTeants();

                var authen = listTenant.FirstOrDefault(s => s.tenant_code.Contains("authen"));

                if (authen != null)
                {
                    var result = await api.ExecuteScript(authen.tenant_id.ToString(), Script.ScriptDeleteUser_Authen);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDeleteMisaQLTS_Click(object sender, EventArgs e)
        {
            upgradeActive = true;
            scriptExecute = Script.ScriptDeleteUser;

            if (!ValidateForm(true))
            {
                return;
            }

            Thread thread = new Thread(async () => {
                await DeleteMisaQlts();
            });

            thread.IsBackground = true;
            thread.Start();

            StartUpgrade();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            List<Tenant> result = new List<Tenant>();

            foreach (var item in tenants)
            {
                if (item.tenant_name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    result.Add(item);
                }
            }

            BindingListView1(result);
        }

        private void fForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnLoadAllTenant_ClickAsync(object sender, EventArgs e)
        {
            isLoadAllTenant = true;

            try
            {
                if (!ValidateForm())
                {
                    return;
                }

                // Lấy các tỉnh
                await GetListTenant();

                BindingListView1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Có lỗi xảy ra");
            }
        }
    }
}
