using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clickerGame
{
    class Upgrade
    {
        private Item _referencedItem;
        private double _valModifier;
        private string _name;
        private string _description;
        private bool _locked = true;
        private int _price;
        public Upgrade(Item referencedItem, int price, double valModifier, string name, string description)
        {
            ReferencedItem = referencedItem;
            ValModifier = valModifier;
            Name = name;
            Description = description;
            Price = price;
        }
        /// <summary>
        /// Le multiplicateur de la stat
        /// </summary>
        public double ValModifier { get => _valModifier; set => _valModifier = value; }
        /// <summary>
        /// Le nom de l'upgrade
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// La description de l'upgrade
        /// </summary>
        public string Description { get => _description; set => _description = value; }
        /// <summary>
        /// Est-ce que l'upgrade est bloquée
        /// </summary>
        public bool Locked { get => _locked; set => _locked = value; }
        public int Price { get => _price; set => _price = value; }

        /// <summary>
        /// L'item à améliorer
        /// </summary>
        internal Item ReferencedItem { get => _referencedItem; set => _referencedItem = value; }
    }
}
