using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGamePcl.Actor;
using RpgGamePcl.Interfaces;

namespace RpgGamePcl.Combat
{
    public sealed class CombatScene
    {
        /// <summary>
        /// which formulas we are using, to change them simply write another implementation of ICombatFormulas and plug it in
        /// </summary>
        private ICombatFormulas CombatFormulas;

        private IEnumerable<ActorBase> Actors;
        private IEnumerable<ActorBase> Enemies;
        public CombatEnums.SideEnum WinnerSide;

        public CombatEnums.SideEnum CurrentSide { get; private set; }
        public ActorBase CurrentActor { get; private set; }
        public ActorBase CurrentEnemy { get; private set; }

        public int TurnCount { get; private set; }

        public CombatScene(IEnumerable<ActorBase> actors, IEnumerable<ActorBase> enemies, ICombatFormulas combatFormulas)
        {
            this.Actors = actors;
            this.Enemies = enemies;
            this.CombatFormulas = combatFormulas;
            this.TurnCount = 1;
        }

        public void ActScene()
        {
            //if invalid data is received just assume a winner to avoid a crash
            if (!ActorFunctionality.ActorListHasMembers(this.Actors) && !ActorFunctionality.ActorListHasMembers(this.Enemies))
            {
                this.WinnerSide = CombatEnums.SideEnum.Left;
                return;
            }

            this.SetSides();

            //determine which side starts;
            this.CurrentSide = CombatEnums.SideEnum.Left;

            //determine which combatants start, on both sides
            this.CurrentActor = this.Actors.First();
            this.CurrentEnemy = this.Enemies.First();

            //main combat loop, runs until one side is obliterated
            bool combatContinues = true;
            
            while (combatContinues)
            {
                combatContinues = this.Act();
            }
        }

        private void ContinueCombat()
        {
            this.TurnCount++;
            this.SwitchSides();
            this.ActivateFirstAliveActor();
        }

        private IEnumerable<ActorBase> DetermineEnemyData()
        {
            IEnumerable<ActorBase> result;

            if (this.CurrentSide == CombatEnums.SideEnum.Left)
            {
                result = this.Enemies;
            }
            else
            {
                result = this.Actors;
            }

            return result;
        }

        private bool Act()
        {
            bool result = false;
            this.CombatFormulas.ApplyDamage(this.CurrentActor, this.CurrentEnemy);

            if (this.CurrentEnemy.CurrentStats.HitPoints <= 0)
            {
                if ( ActorFunctionality.ActorListHasOtherAliveMembers(this.DetermineEnemyData(), this.CurrentEnemy))
                {
                    result = true;
                    this.ContinueCombat();
                }
                else
                {
                    this.WinnerSide = this.CurrentSide;
                }
            }
            else
            {
                result = true;
                this.ContinueCombat();
            }

            return result;
        }

        private void SwitchSides()
        {
            if (this.CurrentSide == CombatEnums.SideEnum.Left)
            {
                this.CurrentSide = CombatEnums.SideEnum.Right;
            }
            else
            {
                this.CurrentSide = CombatEnums.SideEnum.Left;
            }
        }

        private void ActivateFirstAliveActor()
        {
            if (this.CurrentSide == CombatEnums.SideEnum.Left)
            {
                this.CurrentActor = ActorFunctionality.DetermineFirstAliveActor(this.Actors);
                this.CurrentEnemy = ActorFunctionality.DetermineFirstAliveActor(this.Enemies);
            }
            else
            {
                this.CurrentActor = ActorFunctionality.DetermineFirstAliveActor(this.Enemies);
                this.CurrentEnemy = ActorFunctionality.DetermineFirstAliveActor(this.Actors);
            }
        }

        /// <summary>
        /// this allows us to add spells which cause a combatant to switch sides for a while, for example
        /// </summary>
        private void SetSides()
        {
            if (ActorFunctionality.ActorListHasMembers(this.Actors))
            {
                foreach (var actor in this.Actors)
                {
                    actor.CombatSide = CombatEnums.SideEnum.Left;
                }
            }

            if (ActorFunctionality.ActorListHasMembers(this.Enemies))
            {
                foreach (var enemy in this.Enemies)
                {
                    enemy.CombatSide = CombatEnums.SideEnum.Right;
                }
            }
        }

        private bool ActorsStillAlive(IEnumerable<ActorBase> actors)
        {
            bool result = false;
            
            foreach (var actor in actors)
            {
                if (actor.CurrentStats.HitPoints > 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool WaitForUserInput(ActorBase actor)
        {
            bool result = false;
            return result;
        }

        private bool OtherSideStillAlive()
        {
            IEnumerable<ActorBase> otherSide;

            if (this.CurrentSide == CombatEnums.SideEnum.Left)
            {
                otherSide = this.Enemies;
            }
            else
            {
                otherSide = this.Actors;
            }

            return this.ActorsStillAlive(otherSide);
        }
    }
}
