using RpgGamePcl.AbstractClasses;
using RpgGamePcl.Actor;
using RpgGamePcl.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Factories
{
    public static class ObjectFactory
    {
        /// <summary>
        /// returns an implementation of the AbstractGear class
        /// </summary>
        /// <param name="actorBase"></param>
        /// <returns></returns>
        public static AbstractGear CreateGearImplementation(ActorBase actorBase)
        {
            return new Gear(actorBase);
        }

        public static RandomWeightedSelector CreateRandomWeightImplementation(List<GenericInputItem> input)
        {
            return new RandomWeightedChoice(input);
        }
    }
}
