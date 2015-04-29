using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Drops
{
    public sealed class DropItem
    {
        /// <summary>
        /// identifies the drop item
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// whats the min quantity - for example it could be 200 gold
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// max quantity
        /// </summary>
        public int MaxQuantity { get; set; }

        /// <summary>
        /// what's the percentage chance this item will drop
        /// </summary>
        public int ChanceToDrop { get; set; }

        public DropItem(int itemID, int minQuantity, int maxQuantity, int chanceToDrop)
        {
            this.ItemID = itemID;
            this.MinQuantity = minQuantity;
            this.MaxQuantity = maxQuantity;
            this.ChanceToDrop = chanceToDrop;
        }
    }
}
