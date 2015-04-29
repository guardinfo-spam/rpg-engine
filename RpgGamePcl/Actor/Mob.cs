using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Actor
{
    public class Mob: ActorBase
    {
        public Mob(string name) : base(name)
        {
        }

        public override void PopulateStats()
        {
            this.BaseStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.Defence, 10);
            this.BaseStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.HitPoints, 20);
            this.BaseStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.Damage, 10);
        }
    }
}
