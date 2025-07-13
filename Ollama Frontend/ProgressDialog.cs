using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ollama_Frontend
{
    public partial class ProgressDialog: Form
    {
		bool DetailsVisible = false;
		string LastVisibleLine = "";
		public ProgressDialog(StreamReader Info, string Title)
        {
            InitializeComponent();
			ProgressResponse response = new ProgressResponse
			{
				status = "",
				digest = "",
			}; // This should be replaced with actual response from Ollama API
			SetInfoFromResponse(response);
			Thread thread = new Thread(() => ReceiveLine(Info));
			thread.Start();
			this.Text = Title;
        }

		private void ReceiveLine(StreamReader reader)
		{
			string line = null;
			int count = 0;
			string previousStatus = "";
			while ((line = reader.ReadLine()) != null)
			{
				ProgressResponse response = JsonConvert.DeserializeObject<ProgressResponse>(line);
				if (count % 100 == 0 || response.status != previousStatus)
				{
					previousStatus = response.status;
					SetInfoFromResponse(response);
				}
			}
		}

		private void ProgressFrom_Load(object sender, EventArgs e)
		{
			Details();
		}

		private void btnDetails_Click(object sender, EventArgs e)
		{
			DetailsVisible = !DetailsVisible;
			Details();
		}
		private void Details()
		{
			if (DetailsVisible)
			{
				tbDetails.Visible = true;
				btnDetails.Text = "Hide Details";
				this.Size = new Size(this.Size.Width, this.Size.Height + tbDetails.Height);
			}
			else
			{
				tbDetails.Visible = false;
				btnDetails.Text = "Show Details";
				this.Size = new Size(this.Size.Width, this.Size.Height - tbDetails.Height);
			}
		}
		private void SetInfoFromResponse(ProgressResponse response)
		{
			if (response == null)
			{
				tbDetails.Text = "No response received.";
				return;
			}
			if (InvokeRequired)
			{
				Invoke(new Action(() => SetInfoFromResponse(response)));
				return;
			}
			lbStatus.Text = $"{response.status}";
			if (response.total == null && response.completed == null)
			{
				lbProgress.Text = "Progress: N/A / N/A";
				progressBar1.Style = ProgressBarStyle.Marquee;
				progressBar1.Maximum = 1;
				progressBar1.Value = 1;
			}
			else
			{
				string max = (response.total == null) ? "N/A" : SizeConverter.getSize(response.total ?? 0);
				string completed = (response.completed == null) ? "N/A" : SizeConverter.getSize(response.completed ?? 0);
				lbProgress.Text = $"Progress: {completed} / {max}";
				progressBar1.Style = ProgressBarStyle.Blocks;
				progressBar1.Maximum = (int)(response.total / 1024);
				if (response.completed == null)
				{
					progressBar1.Value = 0;
				}
				else
				{
					progressBar1.Value = (int)(response.completed / 1024);
				}

			}
			if (response.status != LastVisibleLine)
			{
				LastVisibleLine = response.status;
				tbDetails.Text += $"{response.status.PadRight(25, ' ')}" +
								 $"[{response.digest}]\r\n";
			}
			if (response.status == "success")
			{
				btnClose.Enabled = true;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
