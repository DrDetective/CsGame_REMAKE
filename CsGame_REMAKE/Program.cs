global using CsGame_REMAKE;
using Spectre.Console;
using System.Diagnostics;

Lists list = new Lists();
Player stats = new Player();
Helper help = new Helper();
#region Colors
var colorRed = new Style().Foreground(Color.Red);
var colorYellow = new Style().Foreground(Color.Yellow);
var colorOcean = new Style().Foreground(Color.DodgerBlue2);
var colorInv = new Style().Foreground(Color.White);
#endregion
while (true)
{
menu:
    AnsiConsole.Write(new FigletText("Wanderer's Tale").Centered().Color(Color.Red));
    var menu = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(4).HighlightStyle(colorRed).AddChoices(new[] { "Start Game", "Credits", "Report a bug", "Exit" }));
    if (menu == "Start Game")
    {
        Console.Clear();
        break;
    } //START
    if (menu == "Credits")
    {
        var credits = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Endings", "Updates", "Go back to title screen" }));
        if (credits == "Endings")
        {
            Lists.endings.Add("test");
            var endingsPanel = new Panel(" ");
            endingsPanel.Header = new PanelHeader("Endings");
            endingsPanel.Border = BoxBorder.Square;
            AnsiConsole.Write(endingsPanel);
            Thread.Sleep(2500);
            Console.Clear();
            goto menu;
        } //ENDINGS
        if (credits == "Updates")
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/DrDetective/CsGame_REMAKE/commits/master",
                UseShellExecute = true,
            };
            Process.Start(psi);
            Console.Clear();
            goto menu;
        } //COMMITS
        else
        {
            Console.Clear();
            goto menu;
        } //RETURN
    } //CREDITS
    if (menu == "Report a bug")
    {
        var psi = new ProcessStartInfo
        {
            FileName = "https://www.github.com/DrDetective/CsGame_REMAKE/issues/new",
            UseShellExecute = true,
        };
        Process.Start(psi);
        Console.Clear();
    } //BUGS
    else { return; } //EXIT
} //START MENU
stats.stamina = 50;
stats.playerAttack = 2;
Console.WriteLine("Enter your name wanderer");
stats.playerName += Console.ReadLine();
Console.Clear();
Console.WriteLine($"Welcome {stats.playerName}\nyou found yourself in desert and your goal is to find civilization");
Thread.Sleep(2250);
Console.Clear();
Console.WriteLine("Collect resources and survive, your stamina is limited to 50 per day");
Thread.Sleep(2250);
Console.Clear();
if (stats.playerName == "test")
{
    stats.stamina = 9999;
    stats.playerHP = 9999;
    stats.playerAttack = 9999;
} //TESTING NAME
#region DESERT
AnsiConsole.Write(new FigletText("Desert").Color(Color.Yellow).Centered());
Thread.Sleep(1700);
Console.Clear();
travel:
var desert = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Travel through desert", "Search near you for resources", "Inventory" }));
while (stats.stamina == 0)
{
    Console.WriteLine("You passed out, because you were out of stamina");
    Thread.Sleep(2000);
    Console.Clear();
    stats.stamina += 50;
    goto travel;
} //OUT OF STAMINA
while (stats.progressLvl >= 100)
{
    stats.lvl++;
    stats.progressLvl -= 100;
} //NEW LEVEL
if (desert == "Travel through desert")
{
ruinsTravel:
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int randomTravel = help.generator.Next(0, 4);
    int ruinsRandom = help.generator.Next(0, 2);
    int ruinsItem = help.generator.Next(0, Lists.desert.Count);
    int combatRng = help.generator.Next(0, Lists.combat.Count);
    switch (randomTravel)
    {
        case 0: //FOUND NOTHING
            Console.WriteLine($"You traveled for few hours and found nothing\nRemaining stamina: {stats.stamina}");
            Thread.Sleep(2500);
            Console.Clear();
            goto travel;
        case 1: //FOUND OLD RUINS
            Console.WriteLine($"You found old ruins\nRemaining stamina: {stats.stamina}");
            var ruins = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
            if (ruins == "Explore")
            {
                Console.Clear();
                switch (ruinsRandom)
                {
                    case 0: //LIVING HELL SECRET ENDING
                        if (Lists.endings.Contains("Living Hell"))
                        {
                            goto normalRuins;
                        } //ENDING CHECK
                        else
                        {
                            Lists.endings.Add("Living Hell");
                            Console.WriteLine("You found a mysterious portal\n\rAs you go closer you become more curious to know whats in there");
                            Thread.Sleep(2250);
                            Console.Clear();
                            Console.WriteLine("But the closer you got the more hotter you were as if there was a Sun in front of you\n\rOut of nowhere you tripped over something and looked what it was");
                            Thread.Sleep(2500);
                            Console.Clear();
                            Console.WriteLine("It was Super Shotgun and you felt getting angrier\n\rYou looked through the portal and saw demons and you steped in");
                            Thread.Sleep(2200);
                            Console.Clear();
                            Console.WriteLine("Secret ending: Living Hell");
                            Thread.Sleep(1500);
                            Console.Clear();
                            goto travel;
                        } //SECRET ENDING
                    case 1: //NORMAL EXPLORE RUINS
                    normalRuins:
                        Console.WriteLine($"You found {Lists.desert[ruinsItem]}");
                        Thread.Sleep(1750);
                        Console.Clear();
                        goto travel;
                }
            } //EXPLORE RUINS
            else
            {
                goto ruinsTravel;
            } //RETURN TO TRAVEL MORE
            break;
        case 2: //FIRST COMBAT
            stats.enemyAttack = 3;
            stats.enemyHP = 20;
            int Run = help.generator.Next(0, 100);
            Console.WriteLine($"While traveling you found dead rat and you see a {Lists.combat[combatRng]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (stats.playerHP > 0 && stats.enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{Lists.combat[combatRng]} HP: {stats.enemyHP}");
                var combatDesert = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Attack", "Run" }));
                switch (combatDesert)
                {
                    case "Attack":
                        stats.enemyHP -= stats.playerAttack;
                        Console.WriteLine($"You dealt {stats.playerAttack} damage to {Lists.combat[combatRng]}");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "Run":
                        if (Run <= 10)
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
                    Console.WriteLine($"{Lists.combat[combatRng]} dealt {stats.enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                } //ENEMY TURN
            } //COMBAT
            if (stats.playerHP > 0)
            {
                stats.progressLvl += Run;
                Console.WriteLine("You won");
                Thread.Sleep(1500);
                Console.Clear();
                goto travel;
            } //W
            else
            {
                Console.WriteLine("You lost");
                Thread.Sleep(1500);
                Console.Clear();
                return;
            } //L
        case 3: //PALM TREE CONTINUE
            Console.WriteLine("As You traveled for what felt like years you see a palm tree in distance\nyou feel as if you got your life back and made a run for it\nYou are in a new area");
            Thread.Sleep(1600);
            Console.Clear();
            break;
        case 4: //PYRAMID
            int pyramidIndex = help.generator.Next(0, Lists.pyramid.Count);
            Console.WriteLine($"While traveling you found a pyramid\nRemaining stamina: {stats.stamina}");
            Thread.Sleep(1500);
            Console.Clear();
            var pyramid = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
            if (pyramid == "Explore")
            {
                Console.WriteLine($"You found {Lists.pyramid[pyramidIndex]}");
                Thread.Sleep(1750);
                Console.Clear();
                goto travel;
            } //EXPLORE PYRAMIDS
            else
            {
                goto ruinsTravel;
            } //RETURN TO TRAVEL MORE
    } //TRAVEL OPTIONS
} //TRAVEL
else if (desert == "Search near you for resources")
{
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int rng = help.generator.Next(0, 2);
    int searchDesert = help.generator.Next(0, Lists.desert.Count);
    int secretIndex = help.generator.Next(0, Lists.secret.Count);
    switch (rng)
    {
        case 0: //SECRET CODE
            if (Lists.secret.Contains(Lists.secret[secretIndex]))
            {
                goto code;
            } //SECRET CODE CHECK
            else
            {
                Lists.codes.Add(Lists.secret[secretIndex]);
                Console.WriteLine($"You found a piece of paper\nIt says: {Lists.secret[secretIndex]}");
                Thread.Sleep(1750);
                Console.Clear();
                goto travel;
            } //SECRET CODE
        case 1: //FOUND MATERIALS
        code:
            Console.WriteLine($"You searched for few hours and found {Lists.desert[searchDesert]}\nRemaining stamina {stats.stamina}");
            Thread.Sleep(2000);
            Console.Clear();
            goto travel;
    }
} //SEARCH NEAR YOU
else if (desert == "Inventory")
{
    AnsiConsole.Write(new FigletText("Coming soon").Color(Color.Yellow).Centered());
    Thread.Sleep(1500);
    Console.Clear();
    goto travel;
    //var tableInv = new Table();
    //tableInv.AddColumn("Name");
    //tableInv.AddColumn($"{stats.playerName}");
    //tableInv.AddColumn("Pockets");
    //tableInv.AddRow("LVL", $"{stats.lvl}");
    //tableInv.AddRow("Progress", $"{stats.progressLvl}");
    //tableInv.AddRow("HP", $"{stats.playerHP}");
    //tableInv.AddRow("MP", $"{stats.mana}");
    //tableInv.AddRow("Hunger", $"{stats.hunger}");
    //tableInv.AddRow("Thirst", $"{stats.thirst}");
    //tableInv.AddRow("Stamina", $"{stats.stamina}");
    //tableInv.AddRow("Armor", $"{stats.armor}");
    //tableInv.AddRow("Damage", $"{stats.playerAttack}");
    //AnsiConsole.Write(tableInv);
    //var inventory = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorInv).AddChoices(new[] { "Crafting", "Cooking", "Go back" }));
    //if (inventory == "Crafting")
    //{

    //} //CRAFTING
    //else if (inventory == "Cooking")
    //{

    //} //COOKING
    //else
    //{
    //    if (ocean == "Inventory")
    //    {
    //        Console.Clear();
    //        goto oceanTravel;
    //    }
    //    else
    //    {
    //        Console.Clear();
    //        goto travel;
    //    }
    //}
} //INVENTORY
#endregion

#region OCEAN
stats.stamina = 100;
AnsiConsole.Write(new FigletText("Ocean").Color(Color.DodgerBlue2).Centered());
Thread.Sleep(1700);
Console.Clear();
Console.WriteLine("Your stamina is now 100");
Thread.Sleep(1500);
Console.Clear();
oceanTravel:
var ocean = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Travel near ocean", "Search near you for resources", "Inventory" }));
while (stats.stamina == 0)
{
    Console.WriteLine("You passed out, because you were out of stamina");
    Thread.Sleep(2000);
    Console.Clear();
    stats.stamina += 100;
    goto oceanTravel;
} //OUT OF STAMINA
while (stats.progressLvl >= 200)
{
    stats.lvl++;
    stats.progressLvl -= 200;
} //EXP TO 200 TO ADD NEW LEVEL
if (ocean == "Travel near ocean")
{
wrectedTravel:
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int oceanTravel = help.generator.Next(0, 3);
    int combatOcean = help.generator.Next(0, Lists.combatOcean.Count());
    int oceanindex = help.generator.Next(0, Lists.desert.Count());
    int Index = help.generator.Next(0, 2);
    int enemyLvlRandom = help.generator.Next(0, 20);
    switch (oceanTravel)
    {
        case 0: //MAKE A BOAT STORY CONTINUE
            if (Lists.pockets.Contains("Boat"))
            {
                goto oceanTravel;
            }
            else
            {
                goto oceanTravel;
            }

        case 1: //WRECKED BOAT
            Console.WriteLine($"While traveling near the ocean you saw a wrecked boat\nRemaining stamina: {stats.stamina}");
            var wrected = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
            if (wrected == "Explore")
            {
                Console.Clear();
                Console.WriteLine($"You found {Lists.desert[oceanindex]}");
                Thread.Sleep(2000);
                Console.Clear();
                goto oceanTravel;
            }
            else
            {
                goto wrectedTravel;
            }

        case 2: //OCEAN COMBAT
            help.Combat(combatOcean, colorOcean);
            break;
            #region OceanCombat
            //stats.enemyAttack = 8;
            //stats.enemyHP = 35;
            //int Run = help.generator.Next(0, 200);
            //Console.WriteLine($"While traveling you see a {Lists.combatOcean[combatOcean]} coming towards you");
            //Thread.Sleep(2000);
            //Console.Clear();
            //while (stats.playerHP > 0 && stats.enemyHP > 0)
            //{
            //combat:
            //    Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{Lists.combatOcean[combatOcean]} HP: {stats.enemyHP}");
            //    var oceanCombat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Attack", "Run" }));
            //    switch (oceanCombat)
            //    {
            //        case "Attack":
            //            stats.enemyHP -= stats.playerAttack;
            //            Console.WriteLine($"You dealt {stats.playerAttack} damage to {Lists.combatOcean[combatOcean]}");
            //            Thread.Sleep(1500);
            //            Console.Clear();
            //            break;
            //        case "Run":
            //            if (Run <= 30)
            //            {
            //                Console.WriteLine("You ran away");
            //            }
            //            else
            //            {
            //                goto combat;
            //            }
            //            break;
            //    } //PLAYER TURN
            //    if (stats.enemyHP > 0)
            //    {
            //        stats.playerHP -= stats.enemyAttack;
            //        Console.WriteLine($"{Lists.combatOcean[combatOcean]} dealt {stats.enemyAttack} damage");
            //        Thread.Sleep(1500);
            //        Console.Clear();
            //    } //ENEMY TURN
            //} //OCEAN COMBAT
            //if (stats.playerHP > 0)
            //{
            //    stats.progressLvl += Run;
            //    Console.WriteLine("You won");
            //    Thread.Sleep(1500);
            //    Console.Clear();
            //    goto oceanTravel;
            //} //W
            //else
            //{
            //    Console.WriteLine("You lost");
            //    Thread.Sleep(1500);
            //    Console.Clear();
            //    return;
            //} //L
            #endregion
    } //OCEAN TRAVEL OPTIONS
} //OCEAN TRAVEL
else if (ocean == "Search near you for resources")
{
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int rng = help.generator.Next(0, 2);
    int searchDesert = help.generator.Next(0, Lists.desert.Count);
    int secretIndex = help.generator.Next(0, Lists.secret.Count);
    switch (rng)
    {
        case 0: //SECRET CODE
            if (Lists.secret.Contains(Lists.secret[secretIndex]))
            {
                goto code;
            } //SECRET CODE CHECK
            else
            {
                Console.WriteLine($"You found a piece of paper\nIt says: {Lists.secret[secretIndex]}");
                Thread.Sleep(1750);
                Console.Clear();
                goto oceanTravel;
            } //SECRET CODE
        case 1: //FOUND MATERIALS
        code:
            Console.WriteLine($"You searched for few hours and found {Lists.desert[searchDesert]}\nRemaining stamina {stats.stamina}");
            Thread.Sleep(2000);
            Console.Clear();
            goto oceanTravel;
    }
} //SEARCH NEAR YOU
#endregion
else if (ocean == "Inventory")
{
    AnsiConsole.Write(new FigletText("Coming soon").Color(Color.DodgerBlue2).Centered());
    Thread.Sleep(1500);
    Console.Clear();
    goto oceanTravel;
    //var tableInv = new Table();
    //tableInv.AddColumn("Name");
    //tableInv.AddColumn($"{stats.playerName}");
    //tableInv.AddColumn("Pockets");
    //tableInv.AddRow("LVL", $"{stats.lvl}");
    //tableInv.AddRow("Progress", $"{stats.progressLvl}");
    //tableInv.AddRow("HP", $"{stats.playerHP}");
    //tableInv.AddRow("MP", $"{stats.mana}");
    //tableInv.AddRow("Hunger", $"{stats.hunger}");
    //tableInv.AddRow("Thirst", $"{stats.thirst}");
    //tableInv.AddRow("Stamina", $"{stats.stamina}");
    //tableInv.AddRow("Armor", $"{stats.armor}");
    //tableInv.AddRow("Damage", $"{stats.playerAttack}");
    //AnsiConsole.Write(tableInv);
    //var inventory = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorInv).AddChoices(new[] { "Crafting", "Cooking", "Go back" }));
    //if (inventory == "Crafting")
    //{

    //} //CRAFTING
    //else if (inventory == "Cooking")
    //{

    //} //COOKING
    //else
    //{
    //    if (ocean == "Inventory")
    //    {
    //        Console.Clear();
    //        goto oceanTravel;
    //    }
    //    else
    //    {
    //        Console.Clear();
    //        goto travel;
    //    }
    //}
} //INVENTORY





//FIX INVENTORY
//ADD RANDOM CHANCE OF ENCOUNTER? KRAKEN
//ADD LVL FUNCTION TO ENEMY AND PLAYER (RANDOM LVL ENEMY) ??????????
//ADD COOKING
//ADD CRAFTING
//ITEM DESIGN EITHER WITH PANEL OR TABLE
//https://www.geeksforgeeks.org/console-setwindowsize-method-in-c-sharp/