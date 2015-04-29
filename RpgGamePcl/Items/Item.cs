using RpgGamePcl.Interfaces;
using RpgGamePcl.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Items
{
    public class Item : IItem
    {
        //IItem
        public string ID { get; set; }
        public string Name { get; set; }
        public ItemsEnums.ItemSlot Slot { get; set; }

        //IStats
        public int Defence { get; set; }
        public int HitPoints { get; set; }
        public int Damage { get; set; }

        public CraftDetail CraftDetail { get; set; }

        public Item(string name, ItemsEnums.ItemSlot slot, int damage, int defence, int hitPoints)
        {
            this.Name = name;
            this.Slot = slot;
            this.Damage = damage;
            this.Defence = defence;
            this.HitPoints = hitPoints;
        }
    }
}
