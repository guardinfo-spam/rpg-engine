using RpgGamePcl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Items
{
    public class CraftDetail : ICraftable
    {
        public IEnumerable<ItemCraftSource> SourceItems { get; set; }
        public int CraftItemID { get; set; }
    }
}
