global using CsGame_REMAKE;
using Spectre.Console;
using System;
Lists list = new Lists();
Player stats = new Player();
Helper help = new Helper();
#region
var colorRed = new Style().Foreground(Color.Red);
var colorYellow = new Style().Foreground(Color.Yellow);
var colorOcean = new Style().Foreground(Color.DodgerBlue2);
var colorInv = new Style().Foreground(Color.White);
#endregion COLORS
while (true)
{
menu:
    AnsiConsole.Write(new FigletText("Wanderer's Tale").Centered().Color(Color.Red));
    var menu = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Start Game", "Credits", "Exit" }));
    if (menu == "Start Game")
    {
        Console.Clear();
        break;
    }
    if (menu == "Credits")
    {
        AnsiConsole.Write(new Rows(new Text("Total time of code : 4h")));
        var credits = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Endings", "Go back to title screen" }));
        if (credits == "Endings")
        {
            list.endings.Add("test");
            var endingsPanel = new Panel(" ");
            endingsPanel.Header = new PanelHeader("Endings");
            endingsPanel.Border = BoxBorder.Square;
            AnsiConsole.Write(endingsPanel);
            Thread.Sleep(2500);
            Console.Clear();
            goto menu;
        }
        else
        {
            Console.Clear();
            goto menu;
        }
    }
    else
    {
        return;
    }
} //START MENU
stats.stamina = 50;
stats.playerAttack = 2;
Console.WriteLine("Enter your name wanderer");
stats.playerName = Console.ReadLine();
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
#region
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
}
while (stats.progressLvl >= 100)
{
    stats.lvl++;
    stats.progressLvl -= 100;
}
if (desert == "Travel through desert") //TRAVEL
{
ruinsTravel:
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int randomTravel = help.generator.Next(0,4);
    int ruinsRandom = help.generator.Next(0, 2);
    int ruinsItem = help.generator.Next(0, list.desert.Count);
    int combatRng = help.generator.Next(0, list.combat.Count);
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
                        if (list.endings.Contains("Living Hell"))
                        {
                            goto normalRuins;
                        }
                        else
                        {
                            list.endings.Add("Living Hell");
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
                        }
                    case 1: //NORMAL EXPLORE RUINS
                        normalRuins:
                        Console.WriteLine($"You found {list.desert[ruinsItem]}");
                        Thread.Sleep(1750);
                        Console.Clear();
                        goto travel;
                }
            }
            else
            {
                goto ruinsTravel;
            }
            break;
        case 2: //FIRST COMBAT
            stats.enemyAttack = 3;
            stats.enemyHP = 20;
            int Run = help.generator.Next(0, 100);
            Console.WriteLine($"{stats.enemyAttack}\n{stats.enemyHP}");
            Console.WriteLine($"While traveling you found dead rat and you see a {list.combat[combatRng]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (stats.playerHP > 0 && stats.enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{list.combat[combatRng]} HP: {stats.enemyHP}");
                var combatDesert = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Attack", "Run" }));
                switch (combatDesert)
                {
                    case "Attack":
                        stats.enemyHP -= stats.playerAttack;
                        Console.WriteLine($"You dealt {stats.playerAttack} damage to {list.combat[combatRng]}");
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
                }
                if (stats.enemyHP > 0)
                {
                    stats.playerHP -= stats.enemyAttack;
                    Console.WriteLine($"{list.combat[combatRng]} dealt {stats.enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            if (stats.playerHP > 0)
            {
                stats.progressLvl += Run;
                Console.WriteLine("You won");
                Thread.Sleep(1500);
                Console.Clear();
                goto travel;
            }
            else
            {
                Console.WriteLine("You lost");
                Thread.Sleep(1500);
                Console.Clear();
                return;
            }
        case 3: //PALM TREE CONTINUE
            Console.WriteLine("As You traveled for what felt like years you see a palm tree in distance\nyou feel as if you got your life back and made a run for it\nYou are in a new area");
            Thread.Sleep(1600);
            Console.Clear();
            break;
        case 4: //PYRAMID
            int pyramidIndex = help.generator.Next(0, list.pyramid.Count);
            Console.WriteLine($"While traveling you found a pyramid\nRemaining stamina: {stats.stamina}");
            Thread.Sleep(1500);
            Console.Clear();
            var pyramid = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
            if (pyramid == "Explore")
            {
                Console.WriteLine($"You found {list.pyramid[pyramidIndex]}");
                Thread.Sleep(1750);
                Console.Clear();
                goto travel;
            }
            else
            {
                goto travel;
            }
    }
}
else if (desert == "Search near you for resources") //SEARCH NEAR YOU
{
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int rng = help.generator.Next(0, 2);
    int searchDesert = help.generator.Next(0, list.desert.Count);
    int secretIndex = help.generator.Next(0, list.secret.Count);
    switch (rng)
    {
        case 0:
            if (list.secret.Contains(list.secret[secretIndex]))
            {
                goto code;
            }
            else
            {
                list.codes.Add(list.secret[secretIndex]);
                Console.WriteLine($"You found a piece of paper\nIt says: {list.secret[secretIndex]}");
                Thread.Sleep(1750);
                Console.Clear();
                goto travel;
            }
        case 1:
        code:
            Console.WriteLine($"You searched for few hours and found {list.desert[searchDesert]}\nRemaining stamina {stats.stamina}");
            Thread.Sleep(2000);
            Console.Clear();
            goto travel;
    }
}
#endregion DESERT

#region
stats.stamina = 100;
AnsiConsole.Write(new FigletText("Ocean").Color(Color.DodgerBlue2).Centered());
Thread.Sleep(1700);
Console.Clear();
Console.WriteLine("Your stamina is now 100");
Thread.Sleep(1500);
Console.Clear();
oceanTravel:
var ocean = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorOcean).AddChoices(new[] { "Travel near ocean", "Search near you for resources", "Inventory" }));
while (stats.stamina == 0) //OUT OF STAMINA
{
    Console.WriteLine("You passed out, because you were out of stamina");
    Thread.Sleep(2000);
    Console.Clear();
    stats.stamina += 100;
    goto oceanTravel;
}
while (stats.progressLvl >= 200) //EXP TO 200 TO ADD NEW LEVEL
{
    stats.lvl++;
    stats.progressLvl -= 200;
}
if (ocean == "Travel near ocean") //TRAVEL
{
    int combatOcean = help.generator.Next(0,list.combatOcean.Count());
    int Index = help.generator.Next(0, 2);
    int oceanTravel = help.generator.Next(0,4);
    int enemyLvlRandom = help.generator.Next(0,20);
    switch (oceanTravel)
    {
        case 1: //MAKE A BOAT STORY CONTINUE
            goto oceanTravel;
            break;

        case 2: //
            goto oceanTravel;
            break;
        
        case 3: //WRECKED BOAT
            goto oceanTravel;
            break;
        
        case 4: //OCEAN COMBAT
            stats.enemyAttack = 8;
            stats.enemyHP = 35;
            int Run = help.generator.Next(0, 200);
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
                }
                if (stats.enemyHP > 0)
                {
                    stats.playerHP -= stats.enemyAttack;
                    Console.WriteLine($"{list.combatOcean[combatOcean]} dealt {stats.enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            if (stats.playerHP > 0)
            {
                stats.progressLvl += Run;
                Console.WriteLine("You won");
                Thread.Sleep(1500);
                Console.Clear();
                goto oceanTravel;
            }
            else
            {
                Console.WriteLine("You lost");
                Thread.Sleep(1500);
                Console.Clear();
                return;
            }
    }
}
else if (ocean == "Search near you for resources") //SEARCH NEAR YOU
{
    stats.stamina -= 10;
    stats.hunger -= 5;
    stats.thirst -= 5;
    int rng = help.generator.Next(0, 2);
    int searchDesert = help.generator.Next(0, list.desert.Count);
    int secretIndex = help.generator.Next(0, list.secret.Count);
    switch (rng)
    {
        case 0:
            if (list.secret.Contains(list.secret[secretIndex]))
            {
                goto code;
            }
            else
            {
                Console.WriteLine($"You found a piece of paper\nIt says: {list.secret[secretIndex]}");
                Thread.Sleep(1750);
                Console.Clear();
                goto oceanTravel;
            }
        case 1:
        code:
            Console.WriteLine($"You searched for few hours and found {list.desert[searchDesert]}\nRemaining stamina {stats.stamina}");
            Thread.Sleep(2000);
            Console.Clear();
            goto oceanTravel;
    }
}
#endregion OCEAN
else if (ocean == "Inventory" || desert  == "Inventory") //INVENTORY
{
    var tableInv = new Table();
    tableInv.AddColumn("Name");
    tableInv.AddColumn($"{stats.playerName}");
    tableInv.AddColumn("Pockets");
    tableInv.AddRow("LVL", $"{stats.lvl}");
    tableInv.AddRow("Progress", $"{stats.progressLvl}");
    tableInv.AddRow("HP", $"{stats.playerHP}");
    tableInv.AddRow("MP", $"{stats.mana}");
    tableInv.AddRow("Hunger", $"{stats.hunger}");
    tableInv.AddRow("Thirst", $"{stats.thirst}");
    tableInv.AddRow("Stamina", $"{stats.stamina}");
    tableInv.AddRow("Armor", $"{stats.armor}");
    tableInv.AddRow("Damage", $"{stats.playerAttack}");
    AnsiConsole.Write(tableInv);
    var inventory = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorInv).AddChoices(new[] { "Crafting", "Cooking", "Go back" }));
    if (inventory == "Crafting")
    {

    }
    else if (inventory == "Cooking")
    {

    }
    else
    {
        if (ocean == "Inventory")
        {
            Console.Clear();
            goto oceanTravel;
        }
        else
        {
            Console.Clear();
            goto travel;
        }
    }
}





//ADD 2-3H
//FIX INVENTORY
//ADD RANDOM CHANCE OF ENCOUNTRE? KRAKEN
//ADD LVL FUNCTION TO ENEMY AND PLAYER (RANDOM LVL ENEMY) ??????????
//ADD COOKING
//ADD CRAFTING
//ITEM DESIGN EITHER WITH PANEL OR TABLE
//MAYBE ADD TIMER FROM VISUAL TIME SPENT PLUGIN
//https://www.geeksforgeeks.org/console-setwindowsize-method-in-c-sharp/