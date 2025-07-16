namespace Ollama_Frontend
{
	partial class ChatWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtChatInput = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtChatHistory = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// txtChatInput
			// 
			this.txtChatInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtChatInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChatInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtChatInput.ForeColor = System.Drawing.Color.White;
			this.txtChatInput.Location = new System.Drawing.Point(0, 393);
			this.txtChatInput.Name = "txtChatInput";
			this.txtChatInput.Size = new System.Drawing.Size(402, 22);
			this.txtChatInput.TabIndex = 0;
			this.txtChatInput.WordWrap = false;
			// 
			// btnSend
			// 
			this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnSend.Location = new System.Drawing.Point(408, 392);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 22);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtChatHistory
			// 
			this.txtChatHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtChatHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtChatHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtChatHistory.ForeColor = System.Drawing.Color.White;
			this.txtChatHistory.Location = new System.Drawing.Point(0, -2);
			this.txtChatHistory.Name = "txtChatHistory";
			this.txtChatHistory.ReadOnly = true;
			this.txtChatHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.txtChatHistory.Size = new System.Drawing.Size(483, 390);
			this.txtChatHistory.TabIndex = 2;
			this.txtChatHistory.Text = "";
			// 
			// ChatWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(482, 415);
			this.Controls.Add(this.txtChatHistory);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtChatInput);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "ChatWindow";
			this.Text = "ChatWindow";
			this.Load += new System.EventHandler(this.ChatWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtChatInput;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.RichTextBox txtChatHistory;
	}
}