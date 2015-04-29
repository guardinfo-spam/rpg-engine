using RpgGamePcl.Interfaces;
using RpgGamePcl.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Inventory
{
    public sealed class GearSlot
    {
        public ItemsEnums.ItemSlot Slot { get; private set; }
        public IItem Item { get; private set; }

        public GearSlot(ItemsEnums.ItemSlot slot, IItem item)
        {
            this.Slot = slot;
            this.Item = item;
        }

        public void EquipItem(IItem item)
        {
            if (this.Slot == item.Slot)
            {
                this.Item = item;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
