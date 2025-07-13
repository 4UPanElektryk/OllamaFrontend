using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ollama_Frontend
{
    public partial class PullDialog: Form
    {
		public string ModelName
		{
			get { return tbModelName.Text; }
		}

		public PullDialog()
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
		}
	}
}
