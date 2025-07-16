using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Ollama_Frontend
{
	public partial class UploadModelfileDialog : Form
	{
		public string FilePath => txtFilePath.Text.Trim();
		public string ModelName => txtModelname.Text.Trim();
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
			/*string[] elines = System.IO.File.ReadAllLines(FilePath);
			var emodelData = ModelfileParser.Parse(elines, txtModelname.Text);
			MessageBox.Show($"FROM: {emodelData.from}\r\n\r\nSYSTEM PROMPT: {emodelData.system}\r\n\r\nTEMPLATE: {emodelData.template}\r\n\r\nJSON: {JsonConvert.SerializeObject(emodelData)}");

			DialogResult = DialogResult.Cancel;*/
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
