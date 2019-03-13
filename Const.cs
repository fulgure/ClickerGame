using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clickerGame
{
    static class Const
    {
        /// <summary>
        /// La taille de la zone permettant à l'utilisateur de resize une form
        /// Cette zone est transparente et doit-être soustraite si l'on veut coller deux fenêtres
        /// Form.Size inclut cette zone même pour les form qui ne sont pas resizable
        /// </summary>
        public const int RESIZE_ZONE_SIZE = 15;


        /// <summary>
        /// Le style de bordure par défaut pour les fenêtres a taille fixe
        /// </summary>
        public const FormBorderStyle NON_RESIZABLE = FormBorderStyle.FixedToolWindow;

        /// <summary>
        /// La taille du tableau d'historique de Gold gagné
        /// Utilisé pour calculer le gps
        /// </summary>
        public const int TICK_INTERVAL = 333;
        public const int DESIRED_BUFFER_TIME = 2500;
        public const int TICK_COUNT_FOR_GPS = DESIRED_BUFFER_TIME / TICK_INTERVAL;

        public const int SMALL_WINDOW_WIDTH = 175;
        public const int SMALL_WINDOW_HEIGHT = 125;
        public const int MEDIUM_WINDOW_WIDTH = SMALL_WINDOW_WIDTH * 2;
        public const int MEDIUM_WINDOW_HEIGHT = SMALL_WINDOW_HEIGHT * 2;
        public const int BIG_WINDOW_WIDTH = MEDIUM_WINDOW_WIDTH + SMALL_WINDOW_WIDTH;
        public const int BIG_WINDOW_HEIGHT = MEDIUM_WINDOW_HEIGHT + SMALL_WINDOW_HEIGHT;

        public const int STARTING_GOLD = 0;
        public const int STARTING_GPC = 1;
        public const int STARTING_PASSIVE = 0;

        /// <summary>
        /// Le prix par défaut des upgrades affectant le Gold Per Click
        /// </summary>
        public const int GPC_BASE_PRICE = 10;
        /// <summary>
        /// La valeur par laquelle multiplier le prix d'une upgrade
        /// </summary>
        public const double GPC_PRICE_MULT = 10;
        /// <summary>
        /// Le multiplicateur appliqué à la valeur
        /// </summary>
        public const double GPC_VAL_MULT = 2;

        public const int DEFAULT_UPGRADE_TIERS = 6;

        public const string GPC_DESC = "Multiplie par {0} le nombre de Gold par clic";

        public const int GPS_BASE_PRICE = 10;
        public const double GPS_PRICE_MULT = 1.15;
        public const double GPS_VAL_MULT = 1.25;

        public static readonly Color TOGGLED_BUTTON_DEFAULT_BACKGROUND = Color.Red;
        public static readonly Color TOGGLED_BUTTON_DEFAULT_FORE = Color.Black;
        public static readonly Color UNTOGGLED_BUTTON_DEFAULT_BACKGROUND = Color.DarkCyan;
        public static readonly Color UNTOGGLED_BUTTON_DEFAULT_FORE = Color.White;

        public static readonly Size SHOP_ITEM_SIZE = new Size(350, 125);
        public const int SHOP_BLOCK_MARGIN = 20;
        public const int SHOP_TITLE_WIDTH = 80;
        public const int SHOP_DESC_WIDTH = 150;
        public static readonly Font SHOP_TITLE_FONT = new Font("Lucida Bright", 11.25f, FontStyle.Bold);
        public static readonly Font SHOP_SMALL_FONT = new Font("Lucida Bright", 8f, FontStyle.Bold);

        public static readonly int[] DEFAULT_BONUS_THRESHOLDS = 
        {
            10,
            25,
            75,
            150,
            300,
            800,
            2000
        };
    }
}
