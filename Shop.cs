using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clickerGame
{
    static class Shop
    {
        private static List<Item> _unlockedInventory = new List<Item>();
        private static Queue<Item> _lockedInventory = new Queue<Item>();

        internal static List<Item> UnlockedInventory { get => _unlockedInventory; set => _unlockedInventory = value; }
        internal static Queue<Item> LockedInventory { get => _lockedInventory; set => _lockedInventory = value; }

        public static void Initialize(Queue<Item> upgrades)
        {
            _lockedInventory = upgrades;
            UnlockedInventory.Add(LockedInventory.Dequeue());
        }

        public static void Initialize(Item[] upgrades)
        {
            Initialize(new Queue<Item>(upgrades));
        }

        public static List<Upgrade> GetUnlockedUpgrades()
        {
            List<Upgrade> tmp = new List<Upgrade>();
            foreach (Item item in UnlockedInventory)
            {
                tmp.AddRange(item.Upgrades.FindAll(x => !x.Locked));
            }
            return tmp;
        }
    }
}
