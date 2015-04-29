using RpgGamePcl.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Interfaces
{
    public interface ICraftable
    {
        //items required to complete the craft 
        IEnumerable<ItemCraftSource> SourceItems { get; set; }

        //the resulting item
        int CraftItemID { get; set; }
    }
}
