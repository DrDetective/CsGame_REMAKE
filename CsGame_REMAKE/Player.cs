using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Player
    {
        public string playerName { get; set; }
        public int hunger = 100;
        public int thirst = 100;
        public int playerHP = 100;
        public int lvl = 0;
        public int progressLvl;
        public int mana = 0;
        public int armor = 0;
        public int stamina;
        public int healAmount;
        public int playerAttack;
        public int enemyHP;
        public int enemyAttack;
        public int enemyMana;
        public int enemyLvl;

        public void Combat() //MAYBE COULD WORK
        {
            while (playerHP > 0 && enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{playerName} HP: {playerHP}\n{list.combatOcean[combatOcean]} HP: {enemyHP}");
                var oceanCombat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Attack", "Run" }));
                switch (oceanCombat)
                {
                    case "Attack":
                        enemyHP -= playerAttack;
                        Console.WriteLine($"You dealt {playerAttack} damage to {combatOcean[combatOcean]}");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "Run":
                        if (Run <= 30) {Console.WriteLine("You ran away"); }
                        else { goto combat;}
                        break;
                } //PLAYER TURN
                if (enemyHP > 0)
                {
                    playerHP -= enemyAttack;
                    Console.WriteLine($"{list.combatOcean[combatOcean]} dealt {enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                } //ENEMY TURN
            } //OCEAN COMBAT
            if (playerHP > 0)
            {
                progressLvl += Run;
                Console.WriteLine("You won");
                Thread.Sleep(1500);
                Console.Clear();
                goto oceanTravel;
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