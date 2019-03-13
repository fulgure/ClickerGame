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
                Point titleLabelPos = new Point(0, Const.SHOP_BLOCK_MARGIN);
                int lblHeight = Const.SHOP_ITEM_SIZE.Height - Const.SHOP_BLOCK_MARGIN;
                Label titleLabel = new Label() {
                    Tag = categories.Nom,
                    Text = categories.Description,
                    Location = titleLabelPos,
                    Font = Const.SHOP_SMALL_FONT,
                    AutoSize = true,
                    Size = new Size(Const.SHOP_TITLE_WIDTH, Const.SHOP_ITEM_SIZE.Height - Const.SHOP_BLOCK_MARGIN),
                    Name = categories.Nom
                };
                Point descLabelPos = titleLabel.Location + new Size(titleLabel.Width, 0);
                Label descLabel = new Label()
                {
                    Tag = categories.Description,
                    Text = categories.Description,
                    Location = descLabelPos,
                    Font = Const.SHOP_TITLE_FONT,
                    AutoSize = true,
                    Size = new Size(Const.SHOP_DESC_WIDTH, lblHeight)
                };
                Button buyButton = new Button()
                {
                    Text = "Acheter",
                    Tag = categories.Nom 
                };
            }
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
