using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Ocean
    {
        //#region OCEAN
        //stats.stamina = 100;
        //AnsiConsole.Write(new FigletText("Ocean").Color(Color.DodgerBlue2).Centered());
        //Thread.Sleep(1700);
        //Console.Clear();
        //Console.WriteLine("Your stamina is now 100");
        //Thread.Sleep(1500);
        //Console.Clear();
        //oceanTravel:
        //var ocean = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Travel near ocean", "Search near you for resources", "Inventory" }));
        //while (stats.stamina == 0)
        //{
        //    Console.WriteLine("You passed out, because you were out of stamina");
        //    Thread.Sleep(2000);
        //    Console.Clear();
        //    stats.stamina += 100;
        //    goto oceanTravel;
        //} //OUT OF STAMINA
        //while (stats.progressLvl >= 200)
        //{
        //    stats.lvl++;
        //    stats.progressLvl -= 200;
        //} //EXP TO 200 TO ADD NEW LEVEL
        //if (ocean == "Travel near ocean")
        //{
        //wrectedTravel:
        //    stats.stamina -= 10;
        //    stats.hunger -= 5;
        //    stats.thirst -= 5;
        //    int oceanTravel = help.generator.Next(0, 3);
        //    int combatOcean = help.generator.Next(0, Lists.combatOcean.Count());
        //    int oceanindex = help.generator.Next(0, Lists.desert.Count());
        //    int Index = help.generator.Next(0, 2);
        //    int enemyLvlRandom = help.generator.Next(0, 20);
        //    switch (oceanTravel)
        //    {
        //        case 0: //MAKE A BOAT STORY CONTINUE
        //            if (Lists.pockets.Contains("Boat"))
        //            {
        //                goto oceanTravel;
        //            }
        //            else
        //            {
        //                goto oceanTravel;
        //            }

        //        case 1: //WRECKED BOAT
        //            Console.WriteLine($"While traveling near the ocean you saw a wrecked boat\nRemaining stamina: {stats.stamina}");
        //            var wrected = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
        //            if (wrected == "Explore")
        //            {
        //                Console.Clear();
        //                Console.WriteLine($"You found {Lists.desert[oceanindex]}");
        //                Thread.Sleep(2000);
        //                Console.Clear();
        //                goto oceanTravel;
        //            }
        //            else
        //            {
        //                goto wrectedTravel;
        //            }

        //        case 2: //OCEAN COMBAT
        //            help.Combat(combatOcean, colorOcean);
        //            break;
        //            #region OceanCombat
        //            //stats.enemyAttack = 8;
        //            //stats.enemyHP = 35;
        //            //int Run = help.generator.Next(0, 200);
        //            //Console.WriteLine($"While traveling you see a {Lists.combatOcean[combatOcean]} coming towards you");
        //            //Thread.Sleep(2000);
        //            //Console.Clear();
        //            //while (stats.playerHP > 0 && stats.enemyHP > 0)
        //            //{
        //            //combat:
        //            //    Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{Lists.combatOcean[combatOcean]} HP: {stats.enemyHP}");
        //            //    var oceanCombat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Attack", "Run" }));
        //            //    switch (oceanCombat)
        //            //    {
        //            //        case "Attack":
        //            //            stats.enemyHP -= stats.playerAttack;
        //            //            Console.WriteLine($"You dealt {stats.playerAttack} damage to {Lists.combatOcean[combatOcean]}");
        //            //            Thread.Sleep(1500);
        //            //            Console.Clear();
        //            //            break;
        //            //        case "Run":
        //            //            if (Run <= 30)
        //            //            {
        //            //                Console.WriteLine("You ran away");
        //            //            }
        //            //            else
        //            //            {
        //            //                goto combat;
        //            //            }
        //            //            break;
        //            //    } //PLAYER TURN
        //            //    if (stats.enemyHP > 0)
        //            //    {
        //            //        stats.playerHP -= stats.enemyAttack;
        //            //        Console.WriteLine($"{Lists.combatOcean[combatOcean]} dealt {stats.enemyAttack} damage");
        //            //        Thread.Sleep(1500);
        //            //        Console.Clear();
        //            //    } //ENEMY TURN
        //            //} //OCEAN COMBAT
        //            //if (stats.playerHP > 0)
        //            //{
        //            //    stats.progressLvl += Run;
        //            //    Console.WriteLine("You won");
        //            //    Thread.Sleep(1500);
        //            //    Console.Clear();
        //            //    goto oceanTravel;
        //            //} //W
        //            //else
        //            //{
        //            //    Console.WriteLine("You lost");
        //            //    Thread.Sleep(1500);
        //            //    Console.Clear();
        //            //    return;
        //            //} //L
        //            #endregion
        //    } //OCEAN TRAVEL OPTIONS
        //} //OCEAN TRAVEL
        //else if (ocean == "Search near you for resources")
        //{
        //    stats.stamina -= 10;
        //    stats.hunger -= 5;
        //    stats.thirst -= 5;
        //    int rng = help.generator.Next(0, 2);
        //    int searchDesert = help.generator.Next(0, Lists.desert.Count);
        //    int secretIndex = help.generator.Next(0, Lists.secret.Count);
        //    switch (rng)
        //    {
        //        case 0: //SECRET CODE
        //            if (Lists.secret.Contains(Lists.secret[secretIndex]))
        //            {
        //                goto code;
        //            } //SECRET CODE CHECK
        //            else
        //            {
        //                Console.WriteLine($"You found a piece of paper\nIt says: {Lists.secret[secretIndex]}");
        //                Thread.Sleep(1750);
        //                Console.Clear();
        //                goto oceanTravel;
        //            } //SECRET CODE
        //        case 1: //FOUND MATERIALS
        //        code:
        //            Console.WriteLine($"You searched for few hours and found {Lists.desert[searchDesert]}\nRemaining stamina {stats.stamina}");
        //            Thread.Sleep(2000);
        //            Console.Clear();
        //            goto oceanTravel;
        //    }
        //} //SEARCH NEAR YOU
        //#endregion
    }
}
