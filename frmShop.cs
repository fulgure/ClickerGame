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
    public partial class frmShop : Form
    {
        public frmShop()
        {
            InitializeComponent();
        }

        public void CreateUI()
        {
            foreach (Item categories in Shop.UnlockedInventory)
            {
                Point descLabelPos = new Point(Const.SHOP_BLOCK_MARGIN, Const.SHOP_BLOCK_MARGIN);
                Label descLabel = createLabel(categories.Nom, categories.Description, descLabelPos);
                Button buyButton = new Button()
                {
                    Text = "Acheter",
                    Tag = categories.Nom 
                };
            }
        }
        
        private Label createLabel(string name, string text, Point position)
        {
            return new Label()
            {
                Text = text,
                Location = position,
                Font = Const.SHOP_DEFAULT_FONT
            };
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
