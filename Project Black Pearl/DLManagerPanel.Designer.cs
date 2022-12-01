namespace Project_Black_Pearl
{
    partial class DLManagerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DLManagerPanel));
            this.TitleLBL = new System.Windows.Forms.Label();
            this.StartBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.StatusLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLBL
            // 
            this.TitleLBL.AutoSize = true;
            this.TitleLBL.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLBL.ForeColor = System.Drawing.Color.White;
            this.TitleLBL.Location = new System.Drawing.Point(15, 10);
            this.TitleLBL.Name = "TitleLBL";
            this.TitleLBL.Size = new System.Drawing.Size(69, 23);
            this.TitleLBL.TabIndex = 0;
            this.TitleLBL.Text = "label1";
            // 
            // StartBTN
            // 
            this.StartBTN.FlatAppearance.BorderSize = 0;
            this.StartBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBTN.Image = ((System.Drawing.Image)(resources.GetObject("StartBTN.Image")));
            this.StartBTN.Location = new System.Drawing.Point(912, 10);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(15, 13);
            this.StartBTN.TabIndex = 1;
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.FlatAppearance.BorderSize = 0;
            this.CancelBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBTN.Image = ((System.Drawing.Image)(resources.GetObject("CancelBTN.Image")));
            this.CancelBTN.Location = new System.Drawing.Point(933, 10);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(15, 13);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Status.ForeColor = System.Drawing.Color.White;
            this.Status.Location = new System.Drawing.Point(15, 43);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(50, 17);
            this.Status.TabIndex = 3;
            this.Status.Text = "Status:";
            // 
            // StatusLBL
            // 
            this.StatusLBL.AutoSize = true;
            this.StatusLBL.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusLBL.ForeColor = System.Drawing.Color.White;
            this.StatusLBL.Location = new System.Drawing.Point(71, 43);
            this.StatusLBL.Name = "StatusLBL";
            this.StatusLBL.Size = new System.Drawing.Size(58, 17);
            this.StatusLBL.TabIndex = 4;
            this.StatusLBL.Text = "Waiting";
            // 
            // DLManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.Controls.Add(this.StatusLBL);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.TitleLBL);
            this.Name = "DLManagerPanel";
            this.Size = new System.Drawing.Size(964, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TitleLBL;
        private Button StartBTN;
        private Button CancelBTN;
        private Label Status;
        private Label StatusLBL;
    }
}
