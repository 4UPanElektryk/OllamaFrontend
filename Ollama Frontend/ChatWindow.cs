using Newtonsoft.Json;
using OllamaApiClasses;
using OllamaApiClasses.Requests;
using OllamaApiClasses.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ollama_Frontend
{
	public partial class ChatWindow : Form
	{
		private bool ChatBusy = false;
		private List<ChatMessage> MessageHistory = new List<ChatMessage>();
		private string ModelName = "";
		private string OllamaHost = ""; // Default host, can be changed
		public ChatWindow(string model, string host)
		{
			InitializeComponent();
			ModelName = model;
			OllamaHost = host;
			this.Text = $"Chat with {model} on {host}";
		}

		private void ChatWindow_Load(object sender, EventArgs e)
		{

		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (ChatBusy)
			{
				MessageBox.Show("Chat is busy, please wait for the current operation to finish.", "Chat Busy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ChatBusy = true;
			SendChatRequest(txtChatInput.Text.Trim());
			txtChatInput.Text = "";
		}
		private void SendChatRequest(string Text)
		{
			txtChatHistory.SelectionStart = txtChatHistory.TextLength;
			txtChatHistory.SelectionLength = 0;
			txtChatHistory.SelectionColor = Color.LightBlue;
			txtChatHistory.AppendText("You: ");
			txtChatHistory.SelectionStart = txtChatHistory.TextLength;
			txtChatHistory.SelectionLength = 0;
			txtChatHistory.SelectionColor = Color.White;
			txtChatHistory.AppendText($"{Text}{Environment.NewLine}");
			txtChatHistory.SelectionStart = txtChatHistory.TextLength;
			txtChatHistory.SelectionLength = 0;
			txtChatHistory.SelectionColor = Color.Green;
			txtChatHistory.AppendText($"{ModelName}: ");
			txtChatHistory.SelectionStart = txtChatHistory.TextLength;
			txtChatHistory.SelectionLength = 0;
			txtChatHistory.SelectionColor = Color.White;
			txtChatHistory.ScrollToCaret();

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri($"http://{OllamaHost}/");
			MessageHistory.Add(new ChatMessage
			{
				role = "user",
				content = Text
			});
			rqChat request = new rqChat
			{
				model = ModelName,
				messages = MessageHistory.ToArray()
			};
			var response = client.SendAsync(
				new HttpRequestMessage(HttpMethod.Post, $"/api/chat")
				{
					Content = new StringContent(
						JsonConvert.SerializeObject(request),
						Encoding.UTF8,
						"application/json"
					)
				},
				HttpCompletionOption.ResponseHeadersRead
			).Result;
			StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
			if (response.IsSuccessStatusCode)
			{
				Thread thread = new Thread(() => ReceiveLine(reader));
				thread.Start();
			}
			else
			{
				MessageBox.Show("Failed to send chat request: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ChatBusy = false;
			}
		}

		private void ReceiveLine(StreamReader reader)
		{
			string line = null;
			string fullLine = "";
			while ((line = reader.ReadLine()) != null)
			{
				Debug.WriteLine(line);
				reChat response = JsonConvert.DeserializeObject<reChat>(line);
				if (response.message != null)
				{
					fullLine += response.message.Value.content;
					AddTextToChat(response.message.Value.content);
					if (response.done)
					{
						MessageHistory.Add(response.message.Value);
						AddTextToChat(Environment.NewLine);
						fullLine = "";
					}
				}
				else
				{
					MessageBox.Show("Received an empty message from the chat API.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			ChatBusy = false;
		}
		private void AddTextToChat(string text)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => AddTextToChat(text)));
				return;
			}
			txtChatHistory.AppendText(text);
			txtChatHistory.SelectionStart = txtChatHistory.TextLength;
			txtChatHistory.SelectionLength = 0;
			txtChatHistory.ScrollToCaret();
		}
	}
}
