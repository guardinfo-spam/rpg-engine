using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGamePcl;
using RpgGamePcl.Interfaces;

namespace RpgGamePcl.Actor
{
    public sealed class ActorStats : IStats
    {
        public int Defence { get;  set; }
        public int HitPoints { get;  set; }
        public int Damage { get;  set; }

        private void InitialiseStats()
        {
            this.Defence = 0;
            this.HitPoints = 0;
            this.Damage = 0;
        }

        public void AddCharacterStatValue( BaseEnums.ActorStatsEnum stat, int value )
        {
            switch ( stat)
            {
                case BaseEnums.ActorStatsEnum.Damage:
                    this.Damage += value;
                    break;
                case BaseEnums.ActorStatsEnum.HitPoints:
                    this.HitPoints += value;
                    break;
                case BaseEnums.ActorStatsEnum.Defence:
                    this.Defence += value;
                    break;
            }
        }

        public ActorStats()
        {
            this.InitialiseStats();
        }

        public void CopyFrom(ActorStats stats)
        {
            if (stats != null)
            {
                this.Damage = stats.Damage;
                this.Defence = stats.Defence;
                this.HitPoints = stats.HitPoints;
            }
        }
    }
}
