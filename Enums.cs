using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clickerGame
{
    enum Corners
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
    [Flags]
    enum Stats
    {
        GoldPerClick = 1 << 0,
        PriceMult = 1 << 1,
        BasePrice = 1 << 2,
        BaseVal = 1 << 3
    }
}
