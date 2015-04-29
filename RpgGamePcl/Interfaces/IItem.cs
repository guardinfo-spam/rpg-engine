using RpgGamePcl.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Interfaces
{
    public interface IItem : IStats
    {
        string ID { get; set; }
        string Name { get; set; }
        ItemsEnums.ItemSlot Slot { get; set; }
    }
}
