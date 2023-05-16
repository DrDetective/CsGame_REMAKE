using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre;
using Spectre.Console;
using CsGame_REMAKE;

namespace CsGame_REMAKE
{
    internal class SpectreC
    {
        Player stats = new Player();
        public void inventory()
        {
            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn($"{stats.playerName}");
            table.AddRow("LVL", $"{stats.lvl}");
            table.AddRow("Progress", $"{stats.progressLvl}");
            table.AddRow("HP", $"{stats.playerHP}");
            table.AddRow("MP", $"{stats.mana}");
            table.AddRow("Hunger", $"{stats.hunger}");
            table.AddRow("Thirst", $"{stats.thirst}");
            table.AddRow("Stamina", $"{stats.stamina}");
            table.AddRow("Armor", $"{stats.armor}");
            table.AddRow("Damage", $"{stats.playerAttack}");
            AnsiConsole.Write(table);
            Thread.Sleep(2800);
            Console.Clear();
        }
    }
}