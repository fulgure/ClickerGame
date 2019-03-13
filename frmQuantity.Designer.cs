namespace clickerGame
{
    partial class frmQuantity
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
            this.tbxQtyCSV = new System.Windows.Forms.TextBox();
            this.btnGridQ = new clickerGame.btnGrid();
            this.SuspendLayout();
            // 
            // tbxQtyCSV
            // 
            this.tbxQtyCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxQtyCSV.Location = new System.Drawing.Point(4, 61);
            this.tbxQtyCSV.Name = "tbxQtyCSV";
            this.tbxQtyCSV.Size = new System.Drawing.Size(318, 20);
            this.tbxQtyCSV.TabIndex = 1;
            this.tbxQtyCSV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxQtyCSV.TextChanged += new System.EventHandler(this.tbxQtyCSV_TextChanged);
            // 
            // btnGridQ
            // 
            this.btnGridQ.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGridQ.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.btnGridQ.BorderSize = 2;
            this.btnGridQ.Location = new System.Drawing.Point(4, 3);
            this.btnGridQ.Name = "btnGridQ";
            this.btnGridQ.NumberOfButtons = 5;
            this.btnGridQ.SelectedIndex = 2;
            this.btnGridQ.SelectedValue = "25";
            this.btnGridQ.Size = new System.Drawing.Size(318, 52);
            this.btnGridQ.TabIndex = 0;
            this.btnGridQ.ToggledColor = System.Drawing.Color.Turquoise;
            this.btnGridQ.ToggledForeColor = System.Drawing.Color.Brown;
            this.btnGridQ.UntoggledColor = System.Drawing.Color.Brown;
            this.btnGridQ.UntoggledForeColor = System.Drawing.Color.Turquoise;
            // 
            // frmQuantity
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(334, 86);
            this.Controls.Add(this.tbxQtyCSV);
            this.Controls.Add(this.btnGridQ);
            this.Name = "frmQuantity";
            this.ShowInTaskbar = false;
            this.Text = "frmQuantity";
            this.Load += new System.EventHandler(this.frmQuantity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxQtyCSV;
        public btnGrid btnGridQ;
    }
}