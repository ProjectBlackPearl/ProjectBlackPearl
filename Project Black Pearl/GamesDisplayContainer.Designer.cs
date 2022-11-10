namespace Project_Black_Pearl
{
    partial class GamesDisplayContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamesDisplayContainer));
            this.NextPageBTN = new System.Windows.Forms.Button();
            this.PreviousPageBTN = new System.Windows.Forms.Button();
            this.NoGamesMessage = new System.Windows.Forms.Label();
            this.LibraryPage = new System.Windows.Forms.Label();
            this.Panel1 = new Project_Black_Pearl.GameLibraryDisplayPanel();
            this.Panel2 = new Project_Black_Pearl.GameLibraryDisplayPanel();
            this.RefreshPageButton = new System.Windows.Forms.Button();
            this.EditBTN1 = new System.Windows.Forms.Button();
            this.EditBTN2 = new System.Windows.Forms.Button();
            this.EditBTN3 = new System.Windows.Forms.Button();
            this.EditBTN4 = new System.Windows.Forms.Button();
            this.EditBTN5 = new System.Windows.Forms.Button();
            this.EditBTN6 = new System.Windows.Forms.Button();
            this.EditGameScreen = new Project_Black_Pearl.EditGameScreen();
            this.EditGameScreen2 = new Project_Black_Pearl.EditGameScreen();
            this.EditGameScreen3 = new Project_Black_Pearl.EditGameScreen();
            this.EditGameScreen4 = new Project_Black_Pearl.EditGameScreen();
            this.EditGameScreen5 = new Project_Black_Pearl.EditGameScreen();
            this.EditGameScreen6 = new Project_Black_Pearl.EditGameScreen();
            this.SuspendLayout();
            // 
            // NextPageBTN
            // 
            this.NextPageBTN.FlatAppearance.BorderSize = 0;
            this.NextPageBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextPageBTN.Image = ((System.Drawing.Image)(resources.GetObject("NextPageBTN.Image")));
            this.NextPageBTN.Location = new System.Drawing.Point(917, 13);
            this.NextPageBTN.Name = "NextPageBTN";
            this.NextPageBTN.Size = new System.Drawing.Size(10, 20);
            this.NextPageBTN.TabIndex = 15;
            this.NextPageBTN.UseVisualStyleBackColor = true;
            this.NextPageBTN.Click += new System.EventHandler(this.NextPageBTN_Click);
            // 
            // PreviousPageBTN
            // 
            this.PreviousPageBTN.FlatAppearance.BorderSize = 0;
            this.PreviousPageBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousPageBTN.Image = ((System.Drawing.Image)(resources.GetObject("PreviousPageBTN.Image")));
            this.PreviousPageBTN.Location = new System.Drawing.Point(882, 13);
            this.PreviousPageBTN.Name = "PreviousPageBTN";
            this.PreviousPageBTN.Size = new System.Drawing.Size(10, 20);
            this.PreviousPageBTN.TabIndex = 16;
            this.PreviousPageBTN.UseVisualStyleBackColor = true;
            this.PreviousPageBTN.Click += new System.EventHandler(this.PreviousPageBTN_Click);
            // 
            // NoGamesMessage
            // 
            this.NoGamesMessage.AutoSize = true;
            this.NoGamesMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoGamesMessage.ForeColor = System.Drawing.Color.White;
            this.NoGamesMessage.Location = new System.Drawing.Point(319, 169);
            this.NoGamesMessage.Name = "NoGamesMessage";
            this.NoGamesMessage.Size = new System.Drawing.Size(319, 20);
            this.NoGamesMessage.TabIndex = 18;
            this.NoGamesMessage.Text = "You currently have no games in your Library.";
            this.NoGamesMessage.Visible = false;
            // 
            // LibraryPage
            // 
            this.LibraryPage.AutoSize = true;
            this.LibraryPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LibraryPage.ForeColor = System.Drawing.Color.White;
            this.LibraryPage.Location = new System.Drawing.Point(899, 16);
            this.LibraryPage.Name = "LibraryPage";
            this.LibraryPage.Size = new System.Drawing.Size(14, 15);
            this.LibraryPage.TabIndex = 19;
            this.LibraryPage.Text = "1";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Panel1.CoverImagePath = "";
            this.Panel1.GamePathString = "";
            this.Panel1.GameTitleDisplay = "Game Title";
            this.Panel1.LastLaunchDisplay = "-";
            this.Panel1.Location = new System.Drawing.Point(9, 56);
            this.Panel1.Name = "Panel1";
            this.Panel1.PlaytimeDisplay = "-";
            this.Panel1.Size = new System.Drawing.Size(956, 60);
            this.Panel1.SizeDisplay = "-";
            this.Panel1.TabIndex = 20;
            this.Panel1.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.Panel1.Visible = false;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Panel2.CoverImagePath = "";
            this.Panel2.GamePathString = "";
            this.Panel2.GameTitleDisplay = "Game Title";
            this.Panel2.LastLaunchDisplay = "-";
            this.Panel2.Location = new System.Drawing.Point(9, 122);
            this.Panel2.Name = "Panel2";
            this.Panel2.PlaytimeDisplay = "-";
            this.Panel2.Size = new System.Drawing.Size(956, 60);
            this.Panel2.SizeDisplay = "-";
            this.Panel2.TabIndex = 21;
            this.Panel2.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.Panel2.Visible = false;
            // 
            // RefreshPageButton
            // 
            this.RefreshPageButton.FlatAppearance.BorderSize = 0;
            this.RefreshPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshPageButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshPageButton.Image")));
            this.RefreshPageButton.Location = new System.Drawing.Point(823, 13);
            this.RefreshPageButton.Name = "RefreshPageButton";
            this.RefreshPageButton.Size = new System.Drawing.Size(10, 20);
            this.RefreshPageButton.TabIndex = 26;
            this.RefreshPageButton.UseVisualStyleBackColor = true;
            this.RefreshPageButton.Click += new System.EventHandler(this.RefreshPageButton_Click);
            // 
            // EditBTN1
            // 
            this.EditBTN1.FlatAppearance.BorderSize = 0;
            this.EditBTN1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN1.Image = ((System.Drawing.Image)(resources.GetObject("EditBTN1.Image")));
            this.EditBTN1.Location = new System.Drawing.Point(899, 75);
            this.EditBTN1.Name = "EditBTN1";
            this.EditBTN1.Size = new System.Drawing.Size(28, 25);
            this.EditBTN1.TabIndex = 27;
            this.EditBTN1.UseVisualStyleBackColor = true;
            this.EditBTN1.Visible = false;
            this.EditBTN1.Click += new System.EventHandler(this.EditBTN1_Click);
            // 
            // EditBTN2
            // 
            this.EditBTN2.FlatAppearance.BorderSize = 0;
            this.EditBTN2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN2.Image = ((System.Drawing.Image)(resources.GetObject("EditBTN2.Image")));
            this.EditBTN2.Location = new System.Drawing.Point(899, 140);
            this.EditBTN2.Name = "EditBTN2";
            this.EditBTN2.Size = new System.Drawing.Size(28, 25);
            this.EditBTN2.TabIndex = 33;
            this.EditBTN2.UseVisualStyleBackColor = true;
            this.EditBTN2.Visible = false;
            this.EditBTN2.Click += new System.EventHandler(this.EditBTN2_Click);
            // 
            // EditBTN3
            // 
            this.EditBTN3.FlatAppearance.BorderSize = 0;
            this.EditBTN3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN3.Image = ((System.Drawing.Image)(resources.GetObject("EditBTN3.Image")));
            this.EditBTN3.Location = new System.Drawing.Point(899, 207);
            this.EditBTN3.Name = "EditBTN3";
            this.EditBTN3.Size = new System.Drawing.Size(28, 25);
            this.EditBTN3.TabIndex = 34;
            this.EditBTN3.UseVisualStyleBackColor = true;
            this.EditBTN3.Visible = false;
            this.EditBTN3.Click += new System.EventHandler(this.EditBTN3_Click);
            // 
            // EditBTN4
            // 
            this.EditBTN4.FlatAppearance.BorderSize = 0;
            this.EditBTN4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN4.Image = ((System.Drawing.Image)(resources.GetObject("EditBTN4.Image")));
            this.EditBTN4.Location = new System.Drawing.Point(899, 273);
            this.EditBTN4.Name = "EditBTN4";
            this.EditBTN4.Size = new System.Drawing.Size(28, 25);
            this.EditBTN4.TabIndex = 35;
            this.EditBTN4.UseVisualStyleBackColor = true;
            this.EditBTN4.Visible = false;
            this.EditBTN4.Click += new System.EventHandler(this.EditBTN4_Click);
            // 
            // EditBTN5
            // 
            this.EditBTN5.FlatAppearance.BorderSize = 0;
            this.EditBTN5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN5.Image = ((System.Drawing.Image)(resources.GetObject("EditBTN5.Image")));
            this.EditBTN5.Location = new System.Drawing.Point(899, 339);
            this.EditBTN5.Name = "EditBTN5";
            this.EditBTN5.Size = new System.Drawing.Size(28, 25);
            this.EditBTN5.TabIndex = 36;
            this.EditBTN5.UseVisualStyleBackColor = true;
            this.EditBTN5.Visible = false;
            this.EditBTN5.Click += new System.EventHandler(this.EditBTN5_Click);
            // 
            // EditBTN6
            // 
            this.EditBTN6.FlatAppearance.BorderSize = 0;
            this.EditBTN6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN6.Image = ((System.Drawing.Image)(resources.GetObject("EditBTN6.Image")));
            this.EditBTN6.Location = new System.Drawing.Point(899, 405);
            this.EditBTN6.Name = "EditBTN6";
            this.EditBTN6.Size = new System.Drawing.Size(28, 25);
            this.EditBTN6.TabIndex = 37;
            this.EditBTN6.UseVisualStyleBackColor = true;
            this.EditBTN6.Visible = false;
            this.EditBTN6.Click += new System.EventHandler(this.EditBTN6_Click);
            // 
            // EditGameScreen
            // 
            this.EditGameScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.EditGameScreen.GameAccount = "";
            this.EditGameScreen.GameID = 0;
            this.EditGameScreen.GameLauncher = "";
            this.EditGameScreen.GameName = "...";
            this.EditGameScreen.GamePath = "";
            this.EditGameScreen.GamePlaytime = 0D;
            this.EditGameScreen.GameSize = 0D;
            this.EditGameScreen.Location = new System.Drawing.Point(3, 0);
            this.EditGameScreen.Name = "EditGameScreen";
            this.EditGameScreen.Size = new System.Drawing.Size(985, 528);
            this.EditGameScreen.TabIndex = 38;
            this.EditGameScreen.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.EditGameScreen.Visible = false;
            // 
            // EditGameScreen2
            // 
            this.EditGameScreen2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.EditGameScreen2.GameAccount = "";
            this.EditGameScreen2.GameID = 0;
            this.EditGameScreen2.GameLauncher = "";
            this.EditGameScreen2.GameName = "...";
            this.EditGameScreen2.GamePath = "";
            this.EditGameScreen2.GamePlaytime = 0D;
            this.EditGameScreen2.GameSize = 0D;
            this.EditGameScreen2.Location = new System.Drawing.Point(3, 3);
            this.EditGameScreen2.Name = "EditGameScreen2";
            this.EditGameScreen2.Size = new System.Drawing.Size(985, 528);
            this.EditGameScreen2.TabIndex = 39;
            this.EditGameScreen2.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.EditGameScreen2.Visible = false;
            // 
            // EditGameScreen3
            // 
            this.EditGameScreen3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.EditGameScreen3.GameAccount = "";
            this.EditGameScreen3.GameID = 0;
            this.EditGameScreen3.GameLauncher = "";
            this.EditGameScreen3.GameName = "...";
            this.EditGameScreen3.GamePath = "";
            this.EditGameScreen3.GamePlaytime = 0D;
            this.EditGameScreen3.GameSize = 0D;
            this.EditGameScreen3.Location = new System.Drawing.Point(9, 3);
            this.EditGameScreen3.Name = "EditGameScreen3";
            this.EditGameScreen3.Size = new System.Drawing.Size(985, 528);
            this.EditGameScreen3.TabIndex = 40;
            this.EditGameScreen3.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.EditGameScreen3.Visible = false;
            // 
            // EditGameScreen4
            // 
            this.EditGameScreen4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.EditGameScreen4.GameAccount = "";
            this.EditGameScreen4.GameID = 0;
            this.EditGameScreen4.GameLauncher = "";
            this.EditGameScreen4.GameName = "...";
            this.EditGameScreen4.GamePath = "";
            this.EditGameScreen4.GamePlaytime = 0D;
            this.EditGameScreen4.GameSize = 0D;
            this.EditGameScreen4.Location = new System.Drawing.Point(3, 3);
            this.EditGameScreen4.Name = "EditGameScreen4";
            this.EditGameScreen4.Size = new System.Drawing.Size(985, 528);
            this.EditGameScreen4.TabIndex = 41;
            this.EditGameScreen4.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.EditGameScreen4.Visible = false;
            // 
            // EditGameScreen5
            // 
            this.EditGameScreen5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.EditGameScreen5.GameAccount = "";
            this.EditGameScreen5.GameID = 0;
            this.EditGameScreen5.GameLauncher = "";
            this.EditGameScreen5.GameName = "...";
            this.EditGameScreen5.GamePath = "";
            this.EditGameScreen5.GamePlaytime = 0D;
            this.EditGameScreen5.GameSize = 0D;
            this.EditGameScreen5.Location = new System.Drawing.Point(0, 3);
            this.EditGameScreen5.Name = "EditGameScreen5";
            this.EditGameScreen5.Size = new System.Drawing.Size(985, 528);
            this.EditGameScreen5.TabIndex = 42;
            this.EditGameScreen5.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.EditGameScreen5.Visible = false;
            // 
            // EditGameScreen6
            // 
            this.EditGameScreen6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.EditGameScreen6.GameAccount = "";
            this.EditGameScreen6.GameID = 0;
            this.EditGameScreen6.GameLauncher = "";
            this.EditGameScreen6.GameName = "...";
            this.EditGameScreen6.GamePath = "";
            this.EditGameScreen6.GamePlaytime = 0D;
            this.EditGameScreen6.GameSize = 0D;
            this.EditGameScreen6.Location = new System.Drawing.Point(3, 3);
            this.EditGameScreen6.Name = "EditGameScreen6";
            this.EditGameScreen6.Size = new System.Drawing.Size(985, 528);
            this.EditGameScreen6.TabIndex = 43;
            this.EditGameScreen6.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.EditGameScreen6.Visible = false;
            // 
            // GamesDisplayContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.EditBTN6);
            this.Controls.Add(this.EditBTN5);
            this.Controls.Add(this.EditBTN4);
            this.Controls.Add(this.EditBTN3);
            this.Controls.Add(this.EditBTN2);
            this.Controls.Add(this.EditBTN1);
            this.Controls.Add(this.RefreshPageButton);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.LibraryPage);
            this.Controls.Add(this.NoGamesMessage);
            this.Controls.Add(this.PreviousPageBTN);
            this.Controls.Add(this.NextPageBTN);
            this.Controls.Add(this.EditGameScreen2);
            this.Controls.Add(this.EditGameScreen3);
            this.Controls.Add(this.EditGameScreen4);
            this.Controls.Add(this.EditGameScreen5);
            this.Controls.Add(this.EditGameScreen6);
            this.Controls.Add(this.EditGameScreen);
            this.Name = "GamesDisplayContainer";
            this.Size = new System.Drawing.Size(985, 550);
            this.Load += new System.EventHandler(this.GamesDisplayContainer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button NextPageBTN;
        private Button PreviousPageBTN;
        private Label NoGamesMessage;
        private Label LibraryPage;
        private GameLibraryDisplayPanel Panel1;
        private GameLibraryDisplayPanel Panel2;
        private Button RefreshPageButton;
        private Button EditBTN1;
        private Button EditBTN2;
        private Button EditBTN3;
        private Button EditBTN4;
        private Button EditBTN5;
        private Button EditBTN6;
        private EditGameScreen EditGameScreen;
        private EditGameScreen EditGameScreen2;
        private EditGameScreen EditGameScreen3;
        private EditGameScreen EditGameScreen4;
        private EditGameScreen EditGameScreen5;
        private EditGameScreen EditGameScreen6;
    }
}
