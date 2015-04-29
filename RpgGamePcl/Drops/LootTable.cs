using RpgGamePcl.Algorithms;
using RpgGamePcl.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Drops
{
    public class LootTable
    {
        /// <summary>
        /// which loot table is it
        /// </summary>
        public int LootTableID;

        /// <summary>
        /// who does it belong to
        /// </summary>
        public int OwnerActorID;

        /// <summary>
        /// the possible drops
        /// </summary>
        public List<DropItem> Drops;

        /// <summary>
        /// how many different items can drop in one go
        /// </summary>
        public int MaxDropsCount { get; set; }

        public LootTable(int id, int ownerID, int maxDropsCount, List<DropItem> drops)
        {
            this.LootTableID = id;
            this.OwnerActorID = ownerID;
            this.Drops = drops;
            this.MaxDropsCount = maxDropsCount;

            if (this.Drops == null)
            {
                this.Drops = new List<DropItem>();
            }
        }

        public List<DropItem> GenerateDrop()
        {
            List<DropItem> result = new List<DropItem>();

            int dropCount = 0;
            
            //if an item has a 100% chance to drop then add it straight away
            var maxDropChanceItems = this.Drops.Where(p => p.ChanceToDrop == 100).ToList();

            if (maxDropChanceItems != null)
            {
                    foreach (var maxDropChanceItem in maxDropChanceItems)
                    {
                        if (dropCount < this.MaxDropsCount)
                        {
                            result.Add(maxDropChanceItem);
                            dropCount++;
                        }
                        else
                        {
                            break;
                        }
                    }                
            }

            var remainingDropItems = this.Drops.Where(p => p.ChanceToDrop < 100).ToList();
            
            //if we need any more drops, generate them here
            if (dropCount < this.MaxDropsCount && remainingDropItems != null && remainingDropItems.Count > 0)
            {
                var selectionAlgorithm = ObjectFactory.CreateRandomWeightImplementation((from p in remainingDropItems select new GenericInputItem(p.ItemID, p.ChanceToDrop)).ToList());
                var selectedItemID = selectionAlgorithm.GenerateRandomPick();

                result.Add(this.Drops.Where(p => p.ItemID == selectedItemID).First());
                dropCount++;
            }

            return result;
        }
    }
}
