using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGamePcl.Combat;

namespace RpgGamePcl.Actor
{
    public sealed class Player : ActorBase
    {
        public Player(string name) : base(name)
        {
            this.ControlledBy = CombatEnums.ActorController.Player;
        }
    }
}
