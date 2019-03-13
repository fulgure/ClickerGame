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
    public partial class frmModularUI : Form
    {
        public frmModularUI()
        {
            InitializeComponent();
        }

        private void frmModularUI_Load(object sender, EventArgs e)
        {
            btnQuantity.Tag = subButtons.Quantite;
            btnBonus.Tag = subButtons.Bonus;
            btnShop.Tag = subButtons.Shop;
            btnMain.Tag = subButtons.Main;
            btnGold.Tag = subButtons.Gold;
            btnGPC.Tag = subButtons.GPC;
            btnPassive.Tag = subButtons.Passive;
            btnGPS.Tag = subButtons.GPS;
            btnOptions.Tag = subButtons.Options;
            btnResetPos.Tag = subButtons.ResetPos;
            btnToggleSticky.Tag = subButtons.ToggleSticky;
            btnToggleSticky.UpdateToggleButtonColor(Forms.IsSticky);
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Form targetForm = null;
            Button snd = sender as Button;
            switch (snd.Tag)
            {
                case subButtons.Quantite:
                    targetForm = Forms.QuantityForm;
                    break;
                case subButtons.Bonus:
                    targetForm = Forms.BonusForm;
                    break;
                case subButtons.Shop:
                    break;
                case subButtons.Main:
                    targetForm = Forms.ClickForm;
                    break;
                case subButtons.Gold:
                    targetForm = Forms.GoldForm;
                    break;
                case subButtons.GPC:
                    targetForm = Forms.GPCForm;
                    break;
                case subButtons.Passive:
                    targetForm = Forms.PassiveForm;
                    break;
                case subButtons.GPS:
                    targetForm = Forms.TotalGPSForm;
                    break;
                case subButtons.Options:
                    break;
                case subButtons.ResetPos:
                    Forms.UpdateFormPositions();
                    break;
                case subButtons.ToggleSticky:
                    Forms.IsSticky = !Forms.IsSticky;
                    btnToggleSticky.UpdateToggleButtonColor(Forms.IsSticky);
                    break;
                default:
                    break;
            }
            if(targetForm != null)
            {
                targetForm.WindowState = targetForm.WindowState.ToggleVisibility();
                snd.UpdateToggleButtonColor(targetForm.WindowState == FormWindowState.Minimized);
            }
        }

        private void frmModularUI_Activated(object sender, EventArgs e)
        {
        }

    }

    public enum subButtons
    {
        Quantite = 0,
        Bonus = 1,
        Shop = 2,
        Main = 3,
        Gold = 4,
        GPC = 5,
        Passive = 6,
        GPS = 7,
        Options = 8,
        ResetPos = 9,
        ToggleSticky = 10
    }
}
