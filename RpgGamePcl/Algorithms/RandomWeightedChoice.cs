using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGamePcl.AbstractClasses;


namespace RpgGamePcl.Algorithms
{
    public sealed class RandomWeightedChoice : RandomWeightedSelector
    {
        public RandomWeightedChoice(List<GenericInputItem> input) : base(input)
        {
        }

        /// <summary>
        /// returns the id of the randomly selected item
        /// </summary>
        /// <returns></returns>
        public override int GenerateRandomPick()
        {
            int result = 0;
            
            if (this.InputItems != null && this.InputItems.Count > 0)
            {
                int maxWeight = 0;
                
                foreach (var item in this.InputItems)
                {
                    if ( maxWeight < item.Weight )
                    {
                        maxWeight = item.Weight;
                    }
                }

                Random randomGen = new Random();
                
                //this works because we already ordered our list by desc so the max value will be at the bottom
                int rnd = randomGen.Next(-1, this.InputItems.Last().Weight);

                foreach (var item in this.InputItems)
                {
                    if (rnd < item.Weight)
                    {
                        result = item.ID;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
