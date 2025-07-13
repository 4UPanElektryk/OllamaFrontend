namespace Ollama_Frontend
{
	partial class ProgressDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnDetails = new System.Windows.Forms.Button();
			this.tbDetails = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnClose = new System.Windows.Forms.Button();
			this.lbStatus = new System.Windows.Forms.Label();
			this.lbProgress = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Status";
			// 
			// btnDetails
			// 
			this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDetails.ForeColor = System.Drawing.Color.White;
			this.btnDetails.Location = new System.Drawing.Point(12, 108);
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(91, 23);
			this.btnDetails.TabIndex = 1;
			this.btnDetails.Text = "Details";
			this.btnDetails.UseVisualStyleBackColor = true;
			this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
			// 
			// tbDetails
			// 
			this.tbDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tbDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDetails.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbDetails.ForeColor = System.Drawing.Color.White;
			this.tbDetails.Location = new System.Drawing.Point(-3, 137);
			this.tbDetails.Multiline = true;
			this.tbDetails.Name = "tbDetails";
			this.tbDetails.ReadOnly = true;
			this.tbDetails.Size = new System.Drawing.Size(804, 316);
			this.tbDetails.TabIndex = 2;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 79);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(776, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 3;
			this.progressBar1.Value = 10;
			// 
			// btnClose
			// 
			this.btnClose.Enabled = false;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.Location = new System.Drawing.Point(713, 108);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Ok";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lbStatus
			// 
			this.lbStatus.AutoSize = true;
			this.lbStatus.ForeColor = System.Drawing.Color.White;
			this.lbStatus.Location = new System.Drawing.Point(9, 37);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(35, 13);
			this.lbStatus.TabIndex = 5;
			this.lbStatus.Text = "label2";
			// 
			// lbProgress
			// 
			this.lbProgress.AutoSize = true;
			this.lbProgress.ForeColor = System.Drawing.Color.White;
			this.lbProgress.Location = new System.Drawing.Point(9, 63);
			this.lbProgress.Name = "lbProgress";
			this.lbProgress.Size = new System.Drawing.Size(35, 13);
			this.lbProgress.TabIndex = 6;
			this.lbProgress.Text = "label3";
			// 
			// ProgressDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lbProgress);
			this.Controls.Add(this.lbStatus);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tbDetails);
			this.Controls.Add(this.btnDetails);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "ProgressDialog";
			this.Text = "ProgressFrom";
			this.Load += new System.EventHandler(this.ProgressFrom_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDetails;
		private System.Windows.Forms.TextBox tbDetails;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Label lbProgress;
	}
}