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
	public partial class UploadModelfileDialog : Form
	{
		public string FilePath { 			
			get { return txtFilePath.Text; }
			set { txtFilePath.Text = value; }
		}
		public string ModelName { 
			get { return txtModelname.Text; }
			set { txtModelname.Text = value; }
		}
		public UploadModelfileDialog()
		{
			InitializeComponent();
		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			try
			{
				string[] lines = System.IO.File.ReadAllLines(FilePath);
				var modelData = ModelfileParser.Parse(lines, txtModelname.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error parsing model file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}
		private void btnOpen_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if(result == DialogResult.OK)
			{
				string filePath = openFileDialog1.FileName;
				txtFilePath.Text = filePath;
				try
				{
					string[] lines = System.IO.File.ReadAllLines(filePath);
					var modelData = ModelfileParser.Parse(lines, txtModelname.Text);
					// Process modelData as needed
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error parsing model file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
