using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ollama_Frontend
{
    public partial class MainForm: Form
    {
		public string ollamaHost;
		public MainForm()
        {
            InitializeComponent();
			this.Text = "Ollama Frontend";
			lbHost.Text = "Ollama Host: Not Connected";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ConnectDialog connectForm = new ConnectDialog();
			if (connectForm.ShowDialog() == DialogResult.OK)
			{
				// Handle the connection logic here
				string host = connectForm.Host; // Assuming you have a property to get the host
				if (!host.Contains(':')) { host = host + ":11434"; } // Default Port
				ollamaHost = host;
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri($"http://{host}/");
				try
				{
					var response = client.GetAsync("/").Result; // Example endpoint
					if (response.IsSuccessStatusCode)
					{
						button1.Hide();
						lbHost.Text = "Ollama Host: " + host;
					}
					else
					{
						MessageBox.Show("Failed to connect: " + response.ReasonPhrase);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error connecting: " + ex.Message);
				}
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri($"http://{ollamaHost}/");
			try
			{
				var response = client.GetAsync("/api/tags").Result; // Example endpoint to get models
				if (response.IsSuccessStatusCode)
				{
					string content = response.Content.ReadAsStringAsync().Result;
					/*List<string> models = JsonConvert.DeserializeObject<List<string>>(content);
					lvModels.Items.Clear();


					foreach (var model in models)
					{
						lbModels.Items.Add(model);
					}*/
				}
				else
				{
					MessageBox.Show("Failed to refresh models: " + response.ReasonPhrase);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error refreshing models: " + ex.Message);
			}
		}

		private void btnPull_Click(object sender, EventArgs e)
		{
			PullDialog pullDialog = new PullDialog();
			if (pullDialog.ShowDialog() == DialogResult.OK)
			{
				string modelName = pullDialog.ModelName;
				// Handle the pull logic here
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri($"http://{ollamaHost}/");
				try
				{
					PullRequest pullRequest = new PullRequest
					{
						name = modelName
					};
					var response = client.SendAsync(
						new HttpRequestMessage(HttpMethod.Post, $"/api/pull")
						{
							Content = new StringContent(
							JsonConvert.SerializeObject(pullRequest),
							Encoding.UTF8,
							"application/json"
							)
						},
						HttpCompletionOption.ResponseHeadersRead
					).Result;
					StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
					ProgressDialog progressDialog = new ProgressDialog(reader, $"Pulling Model: {modelName}");
					progressDialog.ShowDialog();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error pulling model: " + ex.Message);
				}
			}
		}
	}
}
