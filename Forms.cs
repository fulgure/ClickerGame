using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clickerGame
{
    static class Forms
    {
        public static frmClick ClickForm;
        public static frmGold GoldForm;
        public static frmGPC GPCForm;
        public static frmPassive PassiveForm;
        public static frmGPS TotalGPSForm;
        public static frmBonus BonusForm;
        public static frmQuantity QuantityForm;
        public static frmModularUI ModularForm;
        private static List<Form> childForms = new List<Form>();
        private static bool _isSticky = true;

        public static bool IsSticky { get => _isSticky; set => _isSticky = value; }

        public static void UpdateUI()
        {
            GoldForm.lblValue.Text = Player.Gold.ToString();
            GPCForm.lblValue.Text = Game.GoldPerClick.ToString();
            PassiveForm.lblValue.Text = Game.PassiveGold.ToString();
            TotalGPSForm.lblValue.Text = Game.GetAverageGPS().ToString();
            BonusForm.UpdateUI();
        }

        public static void UpdateFormPositions()
        {
            UpdatePositions();
            FocusForms();
        }
        /// <summary>
        /// Positionne les forms
        /// </summary>
        public static void UpdatePositions()
        {
            FocusForms();
            GoldForm.Location = ClickForm.Bounds.GetPoint(Corners.BottomLeft);
            GPCForm.Location = GoldForm.Bounds.GetPoint(Corners.TopRight);
            PassiveForm.Location = GPCForm.Bounds.GetPoint(Corners.TopRight);
            TotalGPSForm.Location = PassiveForm.Bounds.GetPoint(Corners.TopRight);
            BonusForm.Location = ClickForm.Bounds.GetPoint(Corners.TopLeft) - new Size(0, BonusForm.Height);
            QuantityForm.Location = BonusForm.Bounds.GetPoint(Corners.TopLeft) - new Size(QuantityForm.Width, 0);
            ModularForm.Location = BonusForm.Bounds.GetPoint(Corners.TopRight);
        }

        /// <summary>
        /// Refocus toutes les forms
        /// </summary>
        public static void FocusForms()
        {
            foreach (Form form in childForms)
            {
                if (form != null && form.WindowState != FormWindowState.Normal)
                    form.WindowState = FormWindowState.Normal;
                form.BringToFront();
            }
        }

        /// <summary>
        /// Crée les forms
        /// </summary>
        public static void CreateForms()
        {
            GoldForm = new frmGold()
            {
                Text = "Gold",
                Width = Const.SMALL_WINDOW_WIDTH,
                Height = Const.SMALL_WINDOW_HEIGHT
            };
            GPCForm = new frmGPC()
            {
                Text = "Clic",
                Width = Const.SMALL_WINDOW_WIDTH,
                Height = Const.SMALL_WINDOW_HEIGHT
            };
            PassiveForm = new frmPassive()
            {
                Text = "Passif",
                Width = Const.SMALL_WINDOW_WIDTH,
                Height = Const.SMALL_WINDOW_HEIGHT
            };
            TotalGPSForm = new frmGPS()
            {
                Text = "Total",
                Width = Const.SMALL_WINDOW_WIDTH,
                Height = Const.SMALL_WINDOW_HEIGHT
            };
            BonusForm = new frmBonus()
            {
                Text = "Bonus",
                Width = Const.MEDIUM_WINDOW_WIDTH,
                Height = Const.SMALL_WINDOW_HEIGHT
            };
            QuantityForm = new frmQuantity()
            {
                Text = "Quantité",
                Width = Const.MEDIUM_WINDOW_WIDTH,
                Height = Const.SMALL_WINDOW_HEIGHT
            };
            ModularForm = new frmModularUI()
            {
                Text = "Modular",
                Width = Const.MEDIUM_WINDOW_WIDTH,
                Height = Const.BIG_WINDOW_HEIGHT
            };
            ClickForm.Width = Const.MEDIUM_WINDOW_WIDTH;

            ClickForm.Move += Forms_Move;

            ClickForm.Text = "rsclient";
            GoldForm.lblDescription.Text = "Gold";
            GPCForm.lblDescription.Text = "Par clic";
            PassiveForm.lblDescription.Text = "Passif / seconde";
            TotalGPSForm.lblDescription.Text = "Total / seconde";

            GoldForm.Show();
            GPCForm.Show();
            PassiveForm.Show();
            TotalGPSForm.Show();
            BonusForm.Show();
            QuantityForm.Show();
            ModularForm.Show();

            childForms = new List<Form>()
            {
                ClickForm,
                GoldForm,
                GPCForm,
                PassiveForm,
                TotalGPSForm,
                BonusForm,
                QuantityForm,
                ModularForm
            };
        }

        private static void Forms_Move(object sender, EventArgs e)
        {
            if (IsSticky && (sender as Form).WindowState == FormWindowState.Normal)
            {
                UpdatePositions();
            }
        }

    }
}
