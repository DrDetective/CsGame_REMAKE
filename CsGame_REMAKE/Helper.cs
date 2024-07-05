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
        public Random generator = new Random();
        public void Combat(int combat, Style color) //pridat parametr na list combat
        {
            Player stats = new Player();
            int Run = generator.Next(0, 200);
            Console.WriteLine($"While traveling you see a {Lists.combatOcean[combat]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (stats.playerHP > 0 && stats.enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{Lists.combatOcean[combat]} HP: {stats.enemyHP}");
                var oceanCombat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(color).AddChoices(new[] { "Attack", "Run" }));
                switch (oceanCombat)
                {
                    case "Attack":
                        stats.enemyHP -= stats.playerAttack;
                        Console.WriteLine($"You dealt {stats.playerAttack} damage to {Lists.combatOcean[combat]}");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "Run":
                        if (Run <= 30)
                        {
                            Console.WriteLine("You ran away");
                        }
                        else
                        {
                            goto combat;
                        }
                        break;
                } //PLAYER TURN
                if (stats.enemyHP > 0)
                {
                    stats.playerHP -= stats.enemyAttack;
                    Console.WriteLine($"{Lists.combatOcean[combat]} dealt {stats.enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                } //ENEMY TURN
            } //OCEAN COMBAT
            if (stats.playerHP > 0)
            {
                stats.progressLvl += Run;
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
    }
}