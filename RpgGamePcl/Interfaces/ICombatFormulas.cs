using RpgGamePcl.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgGamePcl.Interfaces
{
    public interface ICombatFormulas
    {
        int ApplyDamage(ActorBase attacker, ActorBase defender);
    }
}
