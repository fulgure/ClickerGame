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
    public partial class frmBonus : Form
    {
        public frmBonus()
        {
            InitializeComponent();
        }

        private void frmBonus_Load(object sender, EventArgs e)
        {
            pBarBonus.Value = 30.ToPercentage(200);
        }

        public void UpdateUI()
        {
            pBarBonus.Value = Game.PassiveGold.ToPercentage(Game.BonusThresholds.GetNextBonus());
            lblCurrentBonus.Text = $"{Game.PassiveGold} \\ {Game.BonusThresholds.GetNextBonus()} GPS";
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
    }
}
