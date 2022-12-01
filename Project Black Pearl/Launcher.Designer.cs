namespace Project_Black_Pearl
{
    partial class LauncherForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DownloadsSideBTN2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PreferencesBtn = new System.Windows.Forms.Button();
            this.BrowseSideBTN = new System.Windows.Forms.Button();
            this.LibrarySideBTN = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.DraggablePanel = new System.Windows.Forms.Panel();
            this.MinimizeBTN = new System.Windows.Forms.Button();
            this.ShutDownBTN = new System.Windows.Forms.Button();
            this.LibraryScreen = new Project_Black_Pearl.Library();
            this.DownloadsPage = new Project_Black_Pearl.DownloadsPage();
            this.PreferencesScreen = new Project_Black_Pearl.PreferencesScreen();
            this.preferencesScreen1 = new Project_Black_Pearl.PreferencesScreen();
            this.DLManager = new Project_Black_Pearl.DLManager();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.DraggablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.DownloadsSideBTN2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.PreferencesBtn);
            this.panel1.Controls.Add(this.BrowseSideBTN);
            this.panel1.Controls.Add(this.LibrarySideBTN);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 645);
            this.panel1.TabIndex = 0;
            // 
            // DownloadsSideBTN2
            // 
            this.DownloadsSideBTN2.FlatAppearance.BorderSize = 0;
            this.DownloadsSideBTN2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadsSideBTN2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DownloadsSideBTN2.ForeColor = System.Drawing.Color.White;
            this.DownloadsSideBTN2.Location = new System.Drawing.Point(10, 230);
            this.DownloadsSideBTN2.Name = "DownloadsSideBTN2";
            this.DownloadsSideBTN2.Size = new System.Drawing.Size(210, 60);
            this.DownloadsSideBTN2.TabIndex = 8;
            this.DownloadsSideBTN2.Text = "Downloads";
            this.DownloadsSideBTN2.UseVisualStyleBackColor = true;
            this.DownloadsSideBTN2.Click += new System.EventHandler(this.DownloadsSideBTN2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(125, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dev Build";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 60);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // PreferencesBtn
            // 
            this.PreferencesBtn.FlatAppearance.BorderSize = 0;
            this.PreferencesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreferencesBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PreferencesBtn.ForeColor = System.Drawing.Color.White;
            this.PreferencesBtn.Location = new System.Drawing.Point(10, 553);
            this.PreferencesBtn.Name = "PreferencesBtn";
            this.PreferencesBtn.Size = new System.Drawing.Size(210, 60);
            this.PreferencesBtn.TabIndex = 5;
            this.PreferencesBtn.Text = "Preferences";
            this.PreferencesBtn.UseVisualStyleBackColor = true;
            this.PreferencesBtn.Click += new System.EventHandler(this.PreferencesBtn_Click);
            // 
            // BrowseSideBTN
            // 
            this.BrowseSideBTN.FlatAppearance.BorderSize = 0;
            this.BrowseSideBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseSideBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BrowseSideBTN.ForeColor = System.Drawing.Color.White;
            this.BrowseSideBTN.Location = new System.Drawing.Point(10, 164);
            this.BrowseSideBTN.Name = "BrowseSideBTN";
            this.BrowseSideBTN.Size = new System.Drawing.Size(210, 60);
            this.BrowseSideBTN.TabIndex = 4;
            this.BrowseSideBTN.Text = "Browse";
            this.BrowseSideBTN.UseVisualStyleBackColor = true;
            this.BrowseSideBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // LibrarySideBTN
            // 
            this.LibrarySideBTN.FlatAppearance.BorderSize = 0;
            this.LibrarySideBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LibrarySideBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LibrarySideBTN.ForeColor = System.Drawing.Color.White;
            this.LibrarySideBTN.Location = new System.Drawing.Point(10, 98);
            this.LibrarySideBTN.Name = "LibrarySideBTN";
            this.LibrarySideBTN.Size = new System.Drawing.Size(210, 60);
            this.LibrarySideBTN.TabIndex = 3;
            this.LibrarySideBTN.Text = "Library";
            this.LibrarySideBTN.UseVisualStyleBackColor = true;
            this.LibrarySideBTN.Click += new System.EventHandler(this.LibrarySideBTN_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.White;
            this.SidePanel.Location = new System.Drawing.Point(0, 98);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 60);
            this.SidePanel.TabIndex = 2;
            // 
            // DraggablePanel
            // 
            this.DraggablePanel.Controls.Add(this.MinimizeBTN);
            this.DraggablePanel.Controls.Add(this.ShutDownBTN);
            this.DraggablePanel.Location = new System.Drawing.Point(210, -2);
            this.DraggablePanel.Name = "DraggablePanel";
            this.DraggablePanel.Size = new System.Drawing.Size(1009, 41);
            this.DraggablePanel.TabIndex = 1;
            this.DraggablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DraggablePanel_MouseDown);
            // 
            // MinimizeBTN
            // 
            this.MinimizeBTN.FlatAppearance.BorderSize = 0;
            this.MinimizeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBTN.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBTN.Image")));
            this.MinimizeBTN.Location = new System.Drawing.Point(930, 7);
            this.MinimizeBTN.Name = "MinimizeBTN";
            this.MinimizeBTN.Size = new System.Drawing.Size(30, 31);
            this.MinimizeBTN.TabIndex = 3;
            this.MinimizeBTN.UseVisualStyleBackColor = true;
            this.MinimizeBTN.Click += new System.EventHandler(this.MinimizeBTN_Click);
            // 
            // ShutDownBTN
            // 
            this.ShutDownBTN.FlatAppearance.BorderSize = 0;
            this.ShutDownBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShutDownBTN.Image = ((System.Drawing.Image)(resources.GetObject("ShutDownBTN.Image")));
            this.ShutDownBTN.Location = new System.Drawing.Point(966, 7);
            this.ShutDownBTN.Name = "ShutDownBTN";
            this.ShutDownBTN.Size = new System.Drawing.Size(30, 31);
            this.ShutDownBTN.TabIndex = 2;
            this.ShutDownBTN.UseVisualStyleBackColor = true;
            this.ShutDownBTN.Click += new System.EventHandler(this.ShutDownBTN_Click);
            // 
            // LibraryScreen
            // 
            this.LibraryScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.LibraryScreen.Location = new System.Drawing.Point(234, 42);
            this.LibraryScreen.Name = "LibraryScreen";
            this.LibraryScreen.Size = new System.Drawing.Size(985, 586);
            this.LibraryScreen.TabIndex = 2;
            this.LibraryScreen.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            // 
            // DownloadsPage
            // 
            this.DownloadsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.DownloadsPage.Location = new System.Drawing.Point(226, 42);
            this.DownloadsPage.Name = "DownloadsPage";
            this.DownloadsPage.Size = new System.Drawing.Size(985, 586);
            this.DownloadsPage.TabIndex = 3;
            this.DownloadsPage.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.DownloadsPage.Visible = false;
            // 
            // PreferencesScreen
            // 
            this.PreferencesScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.PreferencesScreen.Location = new System.Drawing.Point(0, 0);
            this.PreferencesScreen.Name = "PreferencesScreen";
            this.PreferencesScreen.Size = new System.Drawing.Size(985, 586);
            this.PreferencesScreen.TabIndex = 0;
            // 
            // preferencesScreen1
            // 
            this.preferencesScreen1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.preferencesScreen1.Location = new System.Drawing.Point(226, 42);
            this.preferencesScreen1.Name = "preferencesScreen1";
            this.preferencesScreen1.Size = new System.Drawing.Size(985, 586);
            this.preferencesScreen1.TabIndex = 4;
            this.preferencesScreen1.Visible = false;
            // 
            // DLManager
            // 
            this.DLManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.DLManager.DownloadURLs = ((System.Collections.Generic.List<string>)(resources.GetObject("DLManager.DownloadURLs")));
            this.DLManager.GameName = "";
            this.DLManager.Location = new System.Drawing.Point(221, 45);
            this.DLManager.Name = "DLManager";
            this.DLManager.Size = new System.Drawing.Size(993, 586);
            this.DLManager.TabIndex = 5;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1218, 644);
            this.Controls.Add(this.DLManager);
            this.Controls.Add(this.preferencesScreen1);
            this.Controls.Add(this.DownloadsPage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DraggablePanel);
            this.Controls.Add(this.LibraryScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LauncherForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.DraggablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel SidePanel;
        private Button LibrarySideBTN;
        private Panel DraggablePanel;
        private Button ShutDownBTN;
        private Button MinimizeBTN;
        private Button BrowseSideBTN;
        private Library LibraryScreen;
        private DownloadsPage DownloadsPage;
        private PreferencesScreen PreferencesScreen;
        private Button PreferencesBtn;
        private PreferencesScreen preferencesScreen1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button DownloadsSideBTN2;
        private DLManager DLManager;
    }
}