using RpgGamePcl.Actor;
using RpgGamePcl.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgGamePcl.Items;
using RpgGamePcl.Drops;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCombatSystem();
            //TestDropGenerator();
        }

        static void TestDropGenerator()
        {
            Player player = new Player("Arnold");

            DropItem item1 = new DropItem(1, 100, 200, 10);
            DropItem item2 = new DropItem(2, 1, 1, 100);
            DropItem item3 = new DropItem(3, 1, 1, 80);
            DropItem item4 = new DropItem(4, 1, 1, 1);

            LootTable lootTable = new LootTable(1, 1, 2, new List<DropItem> { item1, item2, item3, item4 });
            player.AttachLootTable(lootTable);
            var dropOnDeath = player.GenerateDropsOnDeath();
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        static void TestEquipItems()
        {
            Player player = new Player("Arnold");
            Item item1 = new Item("Avenger", ItemsEnums.ItemSlot.Chest, 5, 2, 10);
            Item item2 = new Item("Helm of Power", ItemsEnums.ItemSlot.Head, 4, 1, 5);
            Item item3 = new Item("Armor of the white gargoyle", ItemsEnums.ItemSlot.Chest, 3, 5, 40);

            player.EquipItem(item1);
            player.EquipItem(item2);
            player.EquipItem(item3);

            Console.WriteLine(string.Format("Player has base stats : {0} Damage, {1} Defence, {2} Hit Points.", player.BaseStats.Damage,player.BaseStats.Defence, player.BaseStats.HitPoints));
            Console.WriteLine(string.Format("Item {0}, for slot {1} was equipped. Item stats : {2} Damage, {3} Defence, {4} Hit Points", item1.Name, item1.Slot, item1.Damage, item1.Defence, item1.HitPoints));
            Console.WriteLine(string.Format("Item {0}, for slot {1} was equipped. Item stats : {2} Damage, {3} Defence, {4} Hit Points", item2.Name, item2.Slot, item2.Damage, item2.Defence, item2.HitPoints));
            Console.WriteLine(string.Format("Item {0}, for slot {1} was equipped. Item stats : {2} Damage, {3} Defence, {4} Hit Points", item3.Name, item3.Slot, item3.Damage, item3.Defence, item3.HitPoints));
            Console.WriteLine(string.Format("Player's current stats are : {0} Damage, {1} Defence, {2} Hit Points.", player.CurrentStats.Damage, player.CurrentStats.Defence, player.CurrentStats.HitPoints));
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        static void TestCombatSystem()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Player 1"));
            players.Add(new Player("Player 2"));
            players.Add(new Player("Player 3"));

            List<Player> enemies = new List<Player>();
            enemies.Add(new Player("Enemy 1"));
            enemies.Add(new Player("Enemy 2"));

            players[1].CurrentStats.AddCharacterStatValue(RpgGamePcl.BaseEnums.ActorStatsEnum.HitPoints, 900000);

            CombatFormulas cf = new CombatFormulas();
            CombatScene cs = new CombatScene(players, enemies, cf);
            cs.ActScene();

            Console.WriteLine("winner : " + cs.WinnerSide.ToString() + " in " + cs.TurnCount + " turns");
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
