namespace Ollama_Frontend
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbVersion = new System.Windows.Forms.Label();
			this.lbHost = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnPull = new System.Windows.Forms.Button();
			this.lvModels = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ModelContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.ModelContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbVersion);
			this.groupBox1.Controls.Add(this.lbHost);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(215, 143);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server";
			// 
			// lbVersion
			// 
			this.lbVersion.AutoSize = true;
			this.lbVersion.Location = new System.Drawing.Point(6, 72);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(80, 13);
			this.lbVersion.TabIndex = 2;
			this.lbVersion.Text = "Ollama Version:";
			// 
			// lbHost
			// 
			this.lbHost.AutoSize = true;
			this.lbHost.Location = new System.Drawing.Point(6, 48);
			this.lbHost.Name = "lbHost";
			this.lbHost.Size = new System.Drawing.Size(64, 13);
			this.lbHost.TabIndex = 1;
			this.lbHost.Text = "Ollama Host";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(9, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.btnRefresh);
			this.groupBox2.Controls.Add(this.btnPull);
			this.groupBox2.Controls.Add(this.lvModels);
			this.groupBox2.ForeColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(233, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(555, 426);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Models";
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(290, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(97, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Upload Modelfile";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Location = new System.Drawing.Point(393, 19);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 2;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnPull
			// 
			this.btnPull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPull.Location = new System.Drawing.Point(474, 19);
			this.btnPull.Name = "btnPull";
			this.btnPull.Size = new System.Drawing.Size(75, 23);
			this.btnPull.TabIndex = 1;
			this.btnPull.Text = "Pull";
			this.btnPull.UseVisualStyleBackColor = true;
			this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
			// 
			// lvModels
			// 
			this.lvModels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lvModels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvModels.ContextMenuStrip = this.ModelContextMenu;
			this.lvModels.ForeColor = System.Drawing.Color.White;
			this.lvModels.FullRowSelect = true;
			this.lvModels.GridLines = true;
			this.lvModels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvModels.HideSelection = false;
			this.lvModels.Location = new System.Drawing.Point(6, 48);
			this.lvModels.MultiSelect = false;
			this.lvModels.Name = "lvModels";
			this.lvModels.ShowItemToolTips = true;
			this.lvModels.Size = new System.Drawing.Size(543, 372);
			this.lvModels.TabIndex = 0;
			this.lvModels.UseCompatibleStateImageBehavior = false;
			this.lvModels.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Model Name";
			this.columnHeader1.Width = 370;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Model Size";
			this.columnHeader2.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Digest";
			this.columnHeader3.Width = 84;
			// 
			// ModelContextMenu
			// 
			this.ModelContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.openChatToolStripMenuItem});
			this.ModelContextMenu.Name = "ModelContextMenu";
			this.ModelContextMenu.Size = new System.Drawing.Size(132, 70);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// openChatToolStripMenuItem
			// 
			this.openChatToolStripMenuItem.Name = "openChatToolStripMenuItem";
			this.openChatToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.openChatToolStripMenuItem.Text = "Open Chat";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Ollama UI";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ModelContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView lvModels;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnPull;
		private System.Windows.Forms.Label lbHost;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ContextMenuStrip ModelContextMenu;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openChatToolStripMenuItem;
		private System.Windows.Forms.Label lbVersion;
	}
}

