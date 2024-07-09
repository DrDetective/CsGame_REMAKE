using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Helper
    {
        public static Random generator = new Random();
        public void TestPlayer()
        {
            if (Player.playerName == "test")
            {
                Player.stamina = 9999;
                Player.playerHP = 9999;
                Player.playerAttack = 9999;
            } //TESTING NAME
        }
        public void LevelUP(int requirment)
        {
            if (Player.progressLvl >= requirment)
            {
                Player.lvl++;
                Player.progressLvl -= requirment;
                Console.WriteLine($"You leveled up!\nYou currently have {Player.lvl}/{Player.maxlvl} LVLs");
                Thread.Sleep(2000);
                Console.Clear();
            } //NEW LEVEL
        }
        public void OutOfStamina(int stamina)
        {
            if (Player.stamina == 0)
            {
                Console.WriteLine("You passed out, because you were out of stamina");
                Thread.Sleep(2000);
                Console.Clear();
                Player.stamina += stamina;
                //RuinsChecker = false;
                //PyramidChecker = false;
                //Desert_Start();
            } //OUT OF STAMINA
        }
        public void Combat(int combatIndex, List<string> type, Style color, List<string> Items, int ItemsIndex, int EnemyHP, int EnemyATT)
        {
            int Run = generator.Next(0, 200);
            Player.enemyHP = EnemyHP;
            Player.enemyAttack = EnemyATT;
            Console.WriteLine($"While traveling you see a {type[combatIndex]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (Player.playerHP > 0 && Player.enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{Player.playerName}'s HP: {Player.playerHP}\n{type[combatIndex]}'s HP: {Player.enemyHP}");
                var oceanCombat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(color).AddChoices(new[] { "Attack", "Run" }));
                switch (oceanCombat)
                {
                    case "Attack":
                        Player.enemyHP -= Player.playerAttack;
                        Console.WriteLine($"You dealt {Player.playerAttack} damage to {type[combatIndex]}");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "Run":
                        if (Run <= 30) { Console.WriteLine("You ran away"); }
                        else { Console.Clear(); goto combat; }
                        break;
                } //PLAYER TURN
                if (Player.enemyHP > 0)
                {
                    Player.playerHP -= Player.enemyAttack;
                    Console.WriteLine($"{type[combatIndex]} dealt {Player.enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                } //ENEMY TURN
            } //OCEAN COMBAT
            if (Player.playerHP > 0)
            {
                Player.progressLvl += Run;
                Console.WriteLine($"You won against {type[combatIndex]} and found {Items[ItemsIndex]}");
                Lists.pockets.Add(Items[ItemsIndex]);
                Thread.Sleep(1500);
                Console.Clear();
            } //W
            else
            {
                Console.WriteLine("You lost");
                Thread.Sleep(1500);
                Console.Clear();
                return;
            } //L
        }
        public void Inventory(Style color, Color borderColor)
        {
            //var colorInv = new Style().Foreground(Color.White);
            #region Table Info
            int i = 0;
            var tableInv = new Table();
            tableInv.BorderColor(borderColor);
            tableInv.Border(TableBorder.AsciiDoubleHead);
            tableInv.AddColumn($"{Player.playerName}");
            tableInv.AddColumn("");
            tableInv.AddColumn("Pockets");
            tableInv.AddRow("LVL", $"{Player.lvl}");
            tableInv.AddRow("Progress", $"{Player.progressLvl}/{Player.LVLRequirment}");
            tableInv.AddRow("HP", $"{Player.playerHP}");
            tableInv.AddRow("MP", $"{Player.mana}");
            tableInv.AddRow("Hunger", $"{Player.hunger}");
            tableInv.AddRow("Thirst", $"{Player.thirst}");
            tableInv.AddRow("Stamina", $"{Player.stamina}");
            tableInv.AddRow("Armor", $"{Player.armor}");
            tableInv.AddRow("Damage", $"{Player.playerAttack}");
            foreach (var multiItem in Lists.pockets.GroupBy(x => x).Where(g => g.Count() >= 1).Select(g => new { Value = g.Key, Count = g.Count() }))
            {
                Debug.WriteLine($"{multiItem.Count}x {multiItem.Value}");
                tableInv.UpdateCell(i, 2, $"{multiItem.Count}x {multiItem.Value}");
                i++;
            }
            //foreach (var item in Lists.pockets) { Debug.WriteLine($"{item}"); }
            AnsiConsole.Write(tableInv);
            #endregion
            var inventory = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(color).AddChoices(new[] { "Crafting", "Cooking", "Go back" }));
            switch (inventory)
            {
                case "Crafting":
                    Console.WriteLine("Coming Soon!");
                    break;

                case "Cooking":
                    Console.WriteLine("Coming Soon!");
                    break;
            }
            Console.Clear();
        }
    }
}