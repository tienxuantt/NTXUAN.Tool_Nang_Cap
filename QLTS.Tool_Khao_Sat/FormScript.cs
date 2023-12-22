using System;
using System.Text.Json;
using System.Windows.Forms;

namespace QLTS.Tool_Khao_Sat
{
    public partial class fFormScript : Form
    {
        private fForm parentForm = new fForm();

        public fFormScript(fForm parent)
        {
            parentForm = parent;

            InitializeComponent();

            Binding();
        }

        private void Binding()
        {
            txtEditScript.Text = parentForm.scriptExecute;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                parentForm.scriptExecute = txtEditScript.Text;

                this.Hide();
                parentForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Có lỗi xảy ra");
            }
        }

        private void fFormScript_Load(object sender, EventArgs e)
        {
            
        }
    }
}
