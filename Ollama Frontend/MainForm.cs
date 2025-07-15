using Newtonsoft.Json;
using OllamaApiClasses.Requests;
using OllamaApiClasses.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
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

		private void btnConnect_Click(object sender, EventArgs e)
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
						btnRefresh.PerformClick(); // Refresh the model list after connecting
						CheckVersion(); // Check the version of the Ollama API or client
					}
					else
					{
						MessageBox.Show("Failed to connect: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error connecting!\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void CheckVersion()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri($"http://{ollamaHost}/");
			var response = client.GetAsync("/api/version").Result; // Example endpoint to check version
			if (!response.IsSuccessStatusCode)
			{
				MessageBox.Show("Failed to check version: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			reVersion version = JsonConvert.DeserializeObject<reVersion>(response.Content.ReadAsStringAsync().Result);
			lbVersion.Text = $"Ollama Version: {version.version}";

			// This method can be used to check the version of the Ollama API or client
			// For now, it is left empty as a placeholder
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
					reModels models = JsonConvert.DeserializeObject<reModels>(content);
					lvModels.Items.Clear();


					foreach (var model in models.models)
					{
						lvModels.Items.Add(new ListViewItem(new string[] { model.name, SizeConverter.getSize(model.size), model.digest }));
					}
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
					rqPull pullRequest = new rqPull()
					{
						name = modelName,
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
					btnRefresh.PerformClick(); // Refresh the model list
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error pulling model: " + ex.Message);
				}
			}
		}

		[Serializable]
		internal class OllamaException : Exception
		{
			public OllamaException()
			{
			}

			public OllamaException(string message) : base(message)
			{
			}

			public OllamaException(string message, Exception innerException) : base(message, innerException)
			{
			}

			protected OllamaException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			UploadModelfileDialog uploadDialog = new UploadModelfileDialog();
			DialogResult result = uploadDialog.ShowDialog();
			if (result != DialogResult.OK)
			{
				return;
			}
			string filePath = uploadDialog.FilePath; // Assuming you have a property to get the file path
			string modelName = uploadDialog.ModelName; // Assuming you have a property to get the model name

			rqCreate create = ModelfileParser.Parse(
				System.IO.File.ReadAllLines(filePath),
				modelName
			);

			if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(modelName))
			{
				MessageBox.Show("Please provide a valid file path and model name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri($"http://{ollamaHost}/");
			try
			{
				var response = client.SendAsync(
						new HttpRequestMessage(HttpMethod.Post, $"/api/pull")
						{
							Content = new StringContent(
							JsonConvert.SerializeObject(create),
							Encoding.UTF8,
							"application/json"
							)
						},
						HttpCompletionOption.ResponseHeadersRead
					).Result;
				StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
				if (response.IsSuccessStatusCode)
				{
					ProgressDialog progressDialog = new ProgressDialog(reader, $"Pulling Model: {modelName}");
					progressDialog.ShowDialog();
					btnRefresh.PerformClick(); // Refresh the model list
				}
				else
				{
					MessageBox.Show("Failed to upload model: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error uploading model: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
