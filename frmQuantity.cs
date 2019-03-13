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
    public partial class frmQuantity : Form
    {
        public frmQuantity()
        {
            InitializeComponent();
        }

        private void frmQuantity_Load(object sender, EventArgs e)
        {
            tbxQtyCSV.Text = btnGridQ.Text;
        }

        private void tbxQtyCSV_TextChanged(object sender, EventArgs e)
        {
            btnGridQ.Text = tbxQtyCSV.Text;
        }

        /// <summary>
        /// Cache la fenêtre lors d'un alt-tab
        /// Source : http://www.csharp411.com/hide-form-from-alttab/
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
    }
}
