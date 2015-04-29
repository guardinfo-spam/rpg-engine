using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Algorithms
{
    public sealed class GenericInputItem
    {
        public int ID;
        public int Weight;

        public GenericInputItem()
        {
            this.ID = 0;
            this.Weight = 0;
        }

        public GenericInputItem(int id, int weight)
        {
            this.ID = id;
            this.Weight = weight;
        }
    }
}
