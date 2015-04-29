using RpgGamePcl.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.AbstractClasses
{
    public abstract class RandomWeightedSelector
    {
        public readonly List<GenericInputItem> InputItems;

        public RandomWeightedSelector(List<GenericInputItem> input)
        {
            this.InputItems = input.OrderBy( p=>p.Weight).ToList();
        }

        /// <summary>
        /// returns the id of the randomly selected item
        /// </summary>
        /// <returns></returns>
        public abstract int GenerateRandomPick();
    }
}
