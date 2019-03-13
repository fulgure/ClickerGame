namespace clickerGame
{
    partial class frmBonus
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
            this.pBarBonus = new System.Windows.Forms.ProgressBar();
            this.lblCurrentBonus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBarBonus
            // 
            this.pBarBonus.Location = new System.Drawing.Point(12, 12);
            this.pBarBonus.Name = "pBarBonus";
            this.pBarBonus.Size = new System.Drawing.Size(310, 41);
            this.pBarBonus.TabIndex = 0;
            // 
            // lblCurrentBonus
            // 
            this.lblCurrentBonus.AutoSize = true;
            this.lblCurrentBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrentBonus.Location = new System.Drawing.Point(129, 62);
            this.lblCurrentBonus.Name = "lblCurrentBonus";
            this.lblCurrentBonus.Size = new System.Drawing.Size(77, 13);
            this.lblCurrentBonus.TabIndex = 1;
            this.lblCurrentBonus.Text = "30/200 GPS";
            // 
            // frmBonus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 86);
            this.Controls.Add(this.lblCurrentBonus);
            this.Controls.Add(this.pBarBonus);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBonus";
            this.ShowInTaskbar = false;
            this.Text = "frmBonus";
            this.Load += new System.EventHandler(this.frmBonus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBarBonus;
        private System.Windows.Forms.Label lblCurrentBonus;
    }
}