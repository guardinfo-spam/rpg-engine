using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGamePcl.AbstractClasses;
using RpgGamePcl.Interfaces;
using RpgGamePcl.Factories;
using RpgGamePcl.Drops;

namespace RpgGamePcl.Actor
{
    public abstract class ActorBase
    {
        public string Name { get; private set; }
        
        public ActorStats BaseStats { get; private set; }
        public ActorStats CurrentStats { get; private set; }
        
        public AbstractGear GearInventory { get; private set;}
        public LootTable LootTable { get; set; }
        
        public Combat.CombatEnums.ActorController ControlledBy { get; set; }
        public Combat.CombatEnums.SideEnum CombatSide { get; set; }

        public virtual void PopulateStats()
        {
            this.BaseStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.Defence, 10);
            this.BaseStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.HitPoints, 20);
            this.BaseStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.Damage, 10);

            this.ResetCurrentStats();
        }

        public void RecalculateStats()
        {
            this.ResetCurrentStats();
            
            if (this.GearInventory != null && this.GearInventory.Slots != null)
            {
                foreach (var gearItem in this.GearInventory.Slots)
                {
                    if (gearItem.Item != null)
                    {
                        this.CurrentStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.Damage, gearItem.Item.Damage);
                        this.CurrentStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.Defence, gearItem.Item.Defence);
                        this.CurrentStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.HitPoints, gearItem.Item.HitPoints);
                    }                                        
                }
            }
        }

        /// <summary>
        /// resets the current stats for a new calculation. The current stats depend on the base stats and all the equipped items
        /// </summary>
        public virtual void ResetCurrentStats()
        {
            this.CurrentStats.CopyFrom(this.BaseStats);
        }

        /// <summary>
        /// the base constructor
        /// </summary>
        /// <param name="name"></param>
        public ActorBase(string name)
        {
            this.Name = name;
            this.BaseStats = new ActorStats();
            this.CurrentStats = new ActorStats();
            this.GearInventory = ObjectFactory.CreateGearImplementation(this);

            this.PopulateStats();
        }

        public virtual void EquipItem(IItem item)
        {
            this.GearInventory.EquipItem(item);
        }

        
        public virtual void AttachLootTable(LootTable lootTable)
        {
            this.LootTable = lootTable;
        }

        /// <summary>
        /// generates the drops on the actor's death
        /// </summary>
        /// <returns></returns>
        public virtual List<DropItem> GenerateDropsOnDeath()
        {
            return this.LootTable.GenerateDrop();
        }
    }   
}
