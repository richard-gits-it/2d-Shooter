namespace BulletBox
{
    partial class MainMenu
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
            this.lblPlay = new System.Windows.Forms.Label();
            this.lblLead = new System.Windows.Forms.Label();
            this.lblQuit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlay
            // 
            this.lblPlay.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlay.ForeColor = System.Drawing.Color.White;
            this.lblPlay.Location = new System.Drawing.Point(294, 259);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(680, 93);
            this.lblPlay.TabIndex = 0;
            this.lblPlay.Text = "PLAY";
            this.lblPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlay.Click += new System.EventHandler(this.lblPlay_Click);
            this.lblPlay.MouseEnter += new System.EventHandler(this.MouseEntered);
            this.lblPlay.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // lblLead
            // 
            this.lblLead.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLead.ForeColor = System.Drawing.Color.White;
            this.lblLead.Location = new System.Drawing.Point(294, 379);
            this.lblLead.Name = "lblLead";
            this.lblLead.Size = new System.Drawing.Size(680, 93);
            this.lblLead.TabIndex = 0;
            this.lblLead.Text = "LEADERBOARD";
            this.lblLead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLead.Click += new System.EventHandler(this.lblLead_Click);
            this.lblLead.MouseEnter += new System.EventHandler(this.MouseEntered);
            this.lblLead.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // lblQuit
            // 
            this.lblQuit.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuit.ForeColor = System.Drawing.Color.White;
            this.lblQuit.Location = new System.Drawing.Point(294, 499);
            this.lblQuit.Name = "lblQuit";
            this.lblQuit.Size = new System.Drawing.Size(680, 93);
            this.lblQuit.TabIndex = 0;
            this.lblQuit.Text = "QUIT GAME";
            this.lblQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuit.Click += new System.EventHandler(this.lblQuit_Click);
            this.lblQuit.MouseEnter += new System.EventHandler(this.MouseEntered);
            this.lblQuit.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BulletBox.Properties.Resources.logo_game;
            this.pictureBox1.Location = new System.Drawing.Point(394, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lblQuit);
            this.Controls.Add(this.lblLead);
            this.Controls.Add(this.lblPlay);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BulletBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblPlay;
        private Label lblLead;
        private Label lblQuit;
        private PictureBox pictureBox1;
    }
}