using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clickerGame
{
    static class Extensions
    {
        /// <summary>
        /// Retourne le Point haut-droit d'une Form
        /// </summary>
        /// <param name="rct">La form désirée</param>
        /// <param name="getHorizontalGraphicalBounds">
        /// Exclure la zone de resize du résultat ?
        /// (Se réferer à la description de RESIZE_ZONE_SIZE si pas clair)
        /// </param>
        /// <returns>Le Point haut-droit d'une form</returns>
        public static Point GetPoint(this Rectangle rct, Corners desiredCorner ,bool getHorizontalGraphicalBounds = false)
        {
            int x = 0, y = 0;
            switch (desiredCorner)
            {
                case Corners.TopLeft:
                    x = rct.Left;
                    y = rct.Top;
                    break;
                case Corners.TopRight:
                    x = rct.Right;
                    y = rct.Top;
                    break;
                case Corners.BottomLeft:
                    x = rct.Left;
                    y = rct.Bottom;
                    break;
                case Corners.BottomRight:
                    x = rct.Right;
                    y = rct.Bottom;
                    break;
            }
            Point result = new Point(x, y);
            if (getHorizontalGraphicalBounds)
                result.X -= Const.RESIZE_ZONE_SIZE;
            return result;
        }

        public static int ToPercentage(this int value, int maxValue)
        {
            return (int)Math.Ceiling((double)value / maxValue * 100d);
        }

        public static int ToPercentage(this ulong value, ulong maxValue)
        {
            return (int)Math.Ceiling((double)value / maxValue * 100d);
        }
        /// <summary>
        /// Retourne un string formatté correspondant aux valeurs des buttons de la liste
        /// </summary>
        /// <param name="buttons">La liste de boutons</param>
        /// <returns>La valeur de tous les boutons, délimités par un ','</returns>
        public static string ToCSV(this List<Button> buttons)
        {
            const char delimiter = ',';
            List<string> values = new List<string>();
            buttons.ForEach(btn => values.Add(btn.Text));
            return values.Aggregate((first, second) => first + delimiter + second);
        }


        public static string[] CSVToArray(this string csv)
        {
            return csv.Split(',');
        }

        public static int GetNextBonus(this int[] thresholds)
        {
            return thresholds.First(x => x > Game.PassiveGold);
        }

        public static FormWindowState ToggleVisibility(this FormWindowState currentState)
        {
            return (currentState == FormWindowState.Minimized) ? FormWindowState.Normal : FormWindowState.Minimized;
        }

        public static void UpdateToggleButtonColor(this Button btn, bool Toggled)
        {
            Color backColor, foreColor;
            if (Toggled)
            {
                backColor = Const.TOGGLED_BUTTON_DEFAULT_BACKGROUND;
                foreColor = Const.TOGGLED_BUTTON_DEFAULT_FORE;
            }
            else
            {
                backColor = Const.UNTOGGLED_BUTTON_DEFAULT_BACKGROUND;
                foreColor = Const.UNTOGGLED_BUTTON_DEFAULT_FORE;
            }
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
        }
    }
}
