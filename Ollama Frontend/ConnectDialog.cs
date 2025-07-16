using System;
using System.Windows.Forms;

namespace Ollama_Frontend
{
    public partial class ConnectDialog: Form
    {
        public string Host => textBox1.Text.Trim();
		public ConnectDialog()
        {
            InitializeComponent();
        }

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
