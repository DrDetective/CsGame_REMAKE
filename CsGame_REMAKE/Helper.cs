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
        public void Combat()
        {
            Player stats = new Player();
            int Run = generator.Next(0, 200);
            Console.WriteLine($"While traveling you see a {list.combatOcean[combatOcean]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (stats.playerHP > 0 && stats.enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{list.combatOcean[combatOcean]} HP: {stats.enemyHP}");
                var oceanCombat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Attack", "Run" }));
                switch (oceanCombat)
                {
                    case "Attack":
                        stats.enemyHP -= stats.playerAttack;
                        Console.WriteLine($"You dealt {stats.playerAttack} damage to {list.combatOcean[combatOcean]}");
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
                    Console.WriteLine($"{list.combatOcean[combatOcean]} dealt {stats.enemyAttack} damage");
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