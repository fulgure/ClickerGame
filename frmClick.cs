using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clickerGame
{
    public partial class frmClick : Form
    {
        public frmClick()
        {
            InitializeComponent();
        }

        private void frmClick_Load(object sender, EventArgs e)
        {
            Forms.ClickForm = this;
            Forms.CreateForms();
            Forms.UpdateFormPositions();
            Game.Start();
        }

        private void frmClick_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                Forms.FocusForms();
        }

        /// <summary>
        /// Cache la fenêtre lors d'un alt-tab
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            Game.Increment();
        }
    }
}
