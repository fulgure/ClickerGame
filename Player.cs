using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clickerGame
{
    static class Player
    {
        private static int _gold;
        private static List<Item> _ownedItems;

        public static int Gold { get => _gold; set
            {
                if (value > _gold)
                    Game.GoldSinceLastTick += value - _gold;
                _gold = value;
            } }

        internal static List<Item> OwnedItems { get => _ownedItems; set => _ownedItems = value; }

        public static void Initialize() => Initialize(new List<Item>(), Const.STARTING_GOLD);

        public static void Initialize(List<Item> ownedItems, int gold)
        {
            OwnedItems = ownedItems;
            Gold = gold;
        }
        public static void Initialize(List<Item> items) => Initialize(items, Const.STARTING_GOLD);
        public static void Initialize(int gold) => Initialize(new List<Item>(), gold);
    }
}
