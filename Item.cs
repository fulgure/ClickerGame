using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clickerGame
{
    class Item
    {
        private Stats _affectedStat;
        private int _basePrice;
        private double _priceMult;
        private double _baseVal;
        private string _description;
        private string _nom;
        private List<Upgrade> _upgrades;
        public Item(string nom, string description, Stats affectedStat, int basePrice, double priceMult, double baseVal, List<Upgrade> upgrades = null)
        {
            AffectedStat = affectedStat;
            BasePrice = basePrice;
            PriceMult = priceMult;
            BaseVal = baseVal;
            Description = description;
            Nom = nom;
            if (upgrades != null)
                Upgrades = upgrades;
            else
                Upgrades = this.GetDefaultUpgrades();

        }

        internal Stats AffectedStat { get => _affectedStat; set => _affectedStat = value; }
        public int BasePrice { get => _basePrice; set => _basePrice = value; }
        public double PriceMult { get => _priceMult; set => _priceMult = value; }
        public double BaseVal { get => _baseVal; set => _baseVal = value; }
        public string Description { get => _description; set => _description = value; }
        public string Nom { get => _nom; set => _nom = value; }
        internal List<Upgrade> Upgrades { get => _upgrades; set => _upgrades = value; }

        public override string ToString() => Description;

        public static int GetPrice(double priceMultiplier, int basePrice, int owned = 1) => Convert.ToInt32(basePrice * (Math.Pow(priceMultiplier, owned)));
        public int GetPrice(int owned = 1)
        {
            return Item.GetPrice(PriceMult, BasePrice, owned);
        }
        public Upgrade GetNextUpgrade() => Upgrades.FirstOrDefault(x => x.Locked);

        public void UnlockNextUpgrade()
        {
            GetNextUpgrade().Locked = false;
        }

        public List<Upgrade> GetDefaultUpgrades()
        {
            List<Upgrade> result = new List<Upgrade>();
            for (int i = 0; i < Const.DEFAULT_UPGRADE_TIERS; i++)
            {
                Upgrade tmp = new Upgrade(this, GetPrice(i + 1), Const.GPS_VAL_MULT, $"Upgrade {i}", $"DUepfgarualdte {i}");
                result.Add(tmp);
            }
            return result;
        }

    }
}
