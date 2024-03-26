using System.Diagnostics;
using System.Windows.Forms;

namespace QLTS.Tool_Khao_Sat
{
    public partial class FormDetail : Form
    {
        private fForm parentForm = new fForm();

        public FormDetail(fForm parent)
        {
            parentForm = parent;

            InitializeComponent();
        }

        private async void btnGetStore_Click(object sender, System.EventArgs e)
        {
            string storeName = txtStoreName.Text;

            if (string.IsNullOrEmpty(storeName))
            {
                try
                {
                    // Lấy store từ server
                    await parentForm.GetStoreLatestByName(storeName.Trim());

                    DialogResult d = MessageBox.Show("Lấy store thành công", "Thông báo", MessageBoxButtons.YesNo);

                    if (d == DialogResult.Yes)
                    {
                        Process.Start(Application.StartupPath + "/Data/Store");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập store name", "Thông báo");
            }
        }

        private async void btnGetData_Click(object sender, System.EventArgs e)
        {
            string organID = txtOrganID.Text;

            if (!string.IsNullOrEmpty(organID))
            {
                try
                {
                    // Lấy store từ server
                    await parentForm.GetDataByOrganizationID(organID.Trim());

                    DialogResult d = MessageBox.Show("Đang lấy dữ liệu, vui lòng chờ", "Thông báo", MessageBoxButtons.YesNo);

                    if (d == DialogResult.Yes)
                    {
                        Process.Start(Application.StartupPath + "/Data/DataBackup");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID đơn vị", "Thông báo");
            }
        }
    }
}
