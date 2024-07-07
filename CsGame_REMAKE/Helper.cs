using Spectre.Console;
using System;
using System.Collections.Generic;
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
        public void Combat(int combatIndex, List<string> type, Style color)
        {
            int Run = generator.Next(0, 200);
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
                        else { goto combat; }
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
                Console.WriteLine("You won");
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
            var tableInv = new Table();
            tableInv.BorderColor(borderColor);
            tableInv.Border(TableBorder.AsciiDoubleHead);
            tableInv.AddColumn("Name");
            tableInv.AddColumn($"{Player.playerName}");
            tableInv.AddColumn("Pockets");
            tableInv.AddRow("LVL", $"{Player.lvl}");
            tableInv.AddRow("Progress", $"{Player.progressLvl}");
            tableInv.AddRow("HP", $"{Player.playerHP}");
            tableInv.AddRow("MP", $"{Player.mana}");
            tableInv.AddRow("Hunger", $"{Player.hunger}");
            tableInv.AddRow("Thirst", $"{Player.thirst}");
            tableInv.AddRow("Stamina", $"{Player.stamina}");
            tableInv.AddRow("Armor", $"{Player.armor}");
            tableInv.AddRow("Damage", $"{Player.playerAttack}");
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

//make like 1x leather 4x meat etc extract from list "pockets"