using RpgGamePcl.Actor;
using RpgGamePcl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Combat
{
    /// <summary>
    /// min dmg is 100. if attacker's attack is higher then enemy defence then the difference is addded to the damage.
    /// </summary>
    public sealed class CombatFormulas : ICombatFormulas
    {
        public int ApplyDamage(ActorBase attacker, ActorBase defender)
        {
            int result = 100;

            if (attacker.CurrentStats.Damage > defender.CurrentStats.Defence)
            {
                result += attacker.CurrentStats.Damage - defender.CurrentStats.Defence;
                defender.CurrentStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.HitPoints, -result);
            }
            else
            {
                defender.CurrentStats.AddCharacterStatValue(BaseEnums.ActorStatsEnum.HitPoints, -result);
            }

            return result;
        }
    }
}
