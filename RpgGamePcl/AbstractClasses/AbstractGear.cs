using RpgGamePcl.Actor;
using RpgGamePcl.Interfaces;
using RpgGamePcl.Inventory;
using RpgGamePcl.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RpgGamePcl.AbstractClasses
{
    public abstract class AbstractGear
    {
        public readonly List<GearSlot> Slots;
        private readonly ActorBase Owner;

        private void InitialiseSlots()
        {
            this.Slots.Add(new GearSlot(ItemsEnums.ItemSlot.Chest, null));
            this.Slots.Add(new GearSlot(ItemsEnums.ItemSlot.Feet, null));
            this.Slots.Add(new GearSlot(ItemsEnums.ItemSlot.Hands, null));
            this.Slots.Add(new GearSlot(ItemsEnums.ItemSlot.Head, null));
            this.Slots.Add(new GearSlot(ItemsEnums.ItemSlot.Legs, null));
        }

        public AbstractGear(ActorBase owner)
        {
            this.Owner = owner;
            this.Slots = new List<GearSlot>();
            this.InitialiseSlots();
        }

        public virtual void EquipItem(IItem item)
        {
            var slot = this.Slots.ToList().Where(p => p.Slot == item.Slot).ToList();

            if (slot != null && slot.Count == 1)
            {
                slot.First().EquipItem(item);
                this.Owner.RecalculateStats();
            }
        }
    }
}
