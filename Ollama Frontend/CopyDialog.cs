using System;
using System.Windows.Forms;

namespace Ollama_Frontend
{
	public partial class CopyDialog : Form
	{
		public string NewModelName => txtNewModel.Text.Trim();
		public string SelectedModel => cbAllModels.SelectedItem?.ToString();
		public CopyDialog(string defaultModel, string[] models)
		{
			InitializeComponent();
			cbAllModels.Text = defaultModel;
			cbAllModels.Items.AddRange(models);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtNewModel.Text))
			{
				MessageBox.Show("Please enter a name for the new model.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (cbAllModels.SelectedItem == null)
			{
				MessageBox.Show("Please select a model to copy from.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains(" "))
			{
				MessageBox.Show("Model names cannot contain spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("/"))
			{
				MessageBox.Show("Model names cannot contain slashes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("\\"))
			{
				MessageBox.Show("Model names cannot contain backslashes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains(":"))
			{
				MessageBox.Show("Model names cannot contain colons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("*"))
			{
				MessageBox.Show("Model names cannot contain asterisks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("?"))
			{
				MessageBox.Show("Model names cannot contain question marks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("\""))
			{
				MessageBox.Show("Model names cannot contain quotes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("<"))
			{
				MessageBox.Show("Model names cannot contain less than signs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains(">"))
			{
				MessageBox.Show("Model names cannot contain greater than signs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Contains("|"))
			{
				MessageBox.Show("Model names cannot contain pipes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txtNewModel.Text.Length > 100)
			{
				MessageBox.Show("Model names cannot be longer than 100 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
