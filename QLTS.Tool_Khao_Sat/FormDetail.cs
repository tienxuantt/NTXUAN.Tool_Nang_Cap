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

            if (!string.IsNullOrEmpty(storeName))
            {
                try
                {
                    // Lấy store từ server
                    await parentForm.GetStoreLatestByName(storeName.Trim());

                    DialogResult d = MessageBox.Show("Lấy store thành công", "Thông báo", MessageBoxButtons.YesNo);

                    if (d == DialogResult.Yes)
                    {
                        Process.Start(Application.StartupPath + "/Data");
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
    }
}
