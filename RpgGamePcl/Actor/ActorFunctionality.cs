using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Actor
{
    public static class ActorFunctionality
    {
        public static bool ActorListHasMembers(IEnumerable<ActorBase> actors)
        {
            return (actors != null && actors.Count() > 0);
        }

        public static bool ActorListHasOtherAliveMembers(IEnumerable<ActorBase> actors, ActorBase currentActor)
        {
            bool result = false;

            if (actors.Count() > 1)
            {
                foreach (var actor in actors)
                {
                    if (!actor.Equals(currentActor) && actor.CurrentStats.HitPoints > 0)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public static ActorBase DetermineFirstAliveActor(IEnumerable<ActorBase> actors)
        {
            ActorBase result = null;

            foreach (var actor in actors)
            {
                if (actor.CurrentStats.HitPoints > 0)
                {
                    result = actor;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// returns the next item in a list. If there are no more items then return the first, thus creating a circular reference
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="currentItem"></param>
        /// <returns></returns>
        public static T GetNext<T>(IEnumerable<T> list, T currentItem)
        {
            T result = default(T);
            bool found = false;

            using (var iter = list.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    if (found)
                    {
                        result = iter.Current;
                    }

                    if (currentItem.Equals(iter.Current))
                    {
                        found = true;
                    }
                }
            }

            if (found && result == null)
            {
                result = list.First();
            }

            return result;
        }
    }
}
