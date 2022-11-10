namespace Project_Black_Pearl
{
    partial class GameLibraryDisplayPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameLibraryDisplayPanel));
            this.GameTitleDisplayLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlaytimeDisplayLabel = new System.Windows.Forms.Label();
            this.GameCoverPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeDisplayLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LastLaunchDisplayLabel = new System.Windows.Forms.Label();
            this.LaunchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameCoverPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTitleDisplayLabel
            // 
            this.GameTitleDisplayLabel.AutoSize = true;
            this.GameTitleDisplayLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameTitleDisplayLabel.ForeColor = System.Drawing.Color.White;
            this.GameTitleDisplayLabel.Location = new System.Drawing.Point(132, 15);
            this.GameTitleDisplayLabel.Name = "GameTitleDisplayLabel";
            this.GameTitleDisplayLabel.Size = new System.Drawing.Size(120, 30);
            this.GameTitleDisplayLabel.TabIndex = 0;
            this.GameTitleDisplayLabel.Text = "Game Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(372, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Playtime:";
            // 
            // PlaytimeDisplayLabel
            // 
            this.PlaytimeDisplayLabel.AutoSize = true;
            this.PlaytimeDisplayLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlaytimeDisplayLabel.ForeColor = System.Drawing.Color.White;
            this.PlaytimeDisplayLabel.Location = new System.Drawing.Point(441, 22);
            this.PlaytimeDisplayLabel.Name = "PlaytimeDisplayLabel";
            this.PlaytimeDisplayLabel.Size = new System.Drawing.Size(13, 17);
            this.PlaytimeDisplayLabel.TabIndex = 2;
            this.PlaytimeDisplayLabel.Text = "-";
            // 
            // GameCoverPictureBox
            // 
            this.GameCoverPictureBox.Location = new System.Drawing.Point(0, 0);
            this.GameCoverPictureBox.Name = "GameCoverPictureBox";
            this.GameCoverPictureBox.Size = new System.Drawing.Size(60, 60);
            this.GameCoverPictureBox.TabIndex = 3;
            this.GameCoverPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.panel1.Location = new System.Drawing.Point(76, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(27, 69);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(504, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Size:";
            // 
            // SizeDisplayLabel
            // 
            this.SizeDisplayLabel.AutoSize = true;
            this.SizeDisplayLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SizeDisplayLabel.ForeColor = System.Drawing.Color.White;
            this.SizeDisplayLabel.Location = new System.Drawing.Point(544, 22);
            this.SizeDisplayLabel.Name = "SizeDisplayLabel";
            this.SizeDisplayLabel.Size = new System.Drawing.Size(13, 17);
            this.SizeDisplayLabel.TabIndex = 6;
            this.SizeDisplayLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(615, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Last Launch:";
            // 
            // LastLaunchDisplayLabel
            // 
            this.LastLaunchDisplayLabel.AutoSize = true;
            this.LastLaunchDisplayLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LastLaunchDisplayLabel.ForeColor = System.Drawing.Color.White;
            this.LastLaunchDisplayLabel.Location = new System.Drawing.Point(703, 22);
            this.LastLaunchDisplayLabel.Name = "LastLaunchDisplayLabel";
            this.LastLaunchDisplayLabel.Size = new System.Drawing.Size(13, 17);
            this.LastLaunchDisplayLabel.TabIndex = 12;
            this.LastLaunchDisplayLabel.Text = "-";
            // 
            // LaunchButton
            // 
            this.LaunchButton.FlatAppearance.BorderSize = 0;
            this.LaunchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchButton.Image = ((System.Drawing.Image)(resources.GetObject("LaunchButton.Image")));
            this.LaunchButton.Location = new System.Drawing.Point(893, 0);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Padding = new System.Windows.Forms.Padding(32);
            this.LaunchButton.Size = new System.Drawing.Size(63, 63);
            this.LaunchButton.TabIndex = 27;
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // GameLibraryDisplayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.LastLaunchDisplayLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SizeDisplayLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GameCoverPictureBox);
            this.Controls.Add(this.PlaytimeDisplayLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameTitleDisplayLabel);
            this.Name = "GameLibraryDisplayPanel";
            this.Size = new System.Drawing.Size(956, 60);
            ((System.ComponentModel.ISupportInitialize)(this.GameCoverPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label GameTitleDisplayLabel;
        private Label label2;
        private Label PlaytimeDisplayLabel;
        private PictureBox GameCoverPictureBox;
        private Panel panel1;
        private Label label3;
        private Label SizeDisplayLabel;
        private Label label6;
        private Label LastLaunchDisplayLabel;
        private Button LaunchButton;
    }
}