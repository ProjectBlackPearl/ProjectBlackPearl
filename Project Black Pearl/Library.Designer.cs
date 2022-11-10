namespace Project_Black_Pearl
{
    partial class Library
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
            this.AddGameBTN = new Project_Black_Pearl.CustomizableButton();
            this.GamesDisplayContainer = new Project_Black_Pearl.GamesDisplayContainer();
            this.AddGameScreen = new Project_Black_Pearl.Add_Game_Screen();
            this.SuspendLayout();
            // 
            // AddGameBTN
            // 
            this.AddGameBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.AddGameBTN.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.AddGameBTN.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AddGameBTN.BorderRadius = 20;
            this.AddGameBTN.BorderSize = 0;
            this.AddGameBTN.FlatAppearance.BorderSize = 0;
            this.AddGameBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddGameBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddGameBTN.ForeColor = System.Drawing.Color.White;
            this.AddGameBTN.Location = new System.Drawing.Point(828, 31);
            this.AddGameBTN.Name = "AddGameBTN";
            this.AddGameBTN.Size = new System.Drawing.Size(120, 40);
            this.AddGameBTN.TabIndex = 0;
            this.AddGameBTN.Text = "Add Game";
            this.AddGameBTN.TextColor = System.Drawing.Color.White;
            this.AddGameBTN.UseVisualStyleBackColor = false;
            this.AddGameBTN.Click += new System.EventHandler(this.AddGameBTN_Click);
            // 
            // GamesDisplayContainer
            // 
            this.GamesDisplayContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.GamesDisplayContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GamesDisplayContainer.Location = new System.Drawing.Point(-3, 77);
            this.GamesDisplayContainer.Name = "GamesDisplayContainer";
            this.GamesDisplayContainer.Size = new System.Drawing.Size(985, 552);
            this.GamesDisplayContainer.TabIndex = 1;
            this.GamesDisplayContainer.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            // 
            // AddGameScreen
            // 
            this.AddGameScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.AddGameScreen.Location = new System.Drawing.Point(3, 3);
            this.AddGameScreen.Name = "AddGameScreen";
            this.AddGameScreen.Size = new System.Drawing.Size(985, 515);
            this.AddGameScreen.TabIndex = 2;
            this.AddGameScreen.UIColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.AddGameScreen.Visible = false;
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.GamesDisplayContainer);
            this.Controls.Add(this.AddGameBTN);
            this.Controls.Add(this.AddGameScreen);
            this.Name = "Library";
            this.Size = new System.Drawing.Size(985, 648);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomizableButton AddGameBTN;
        private GamesDisplayContainer GamesDisplayContainer;
        private Add_Game_Screen AddGameScreen;
    }
}
