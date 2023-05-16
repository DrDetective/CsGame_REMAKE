global using CsGame_REMAKE;
using Spectre.Console;
using System;
#region
Lists list = new Lists();
Player stats = new Player();
Helper help = new Helper();
SpectreC design = new SpectreC();
#endregion ENTRY
var colorRed = new Style().Foreground(Color.Red);
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
}
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
AnsiConsole.Write(new FigletText("Desert").Centered());
Thread.Sleep(1700);
Console.Clear();
travel:
var desert = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Travel through desert", "Search near you for resources", "Inventory" }));
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
    stats.progressLvl = 0;
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
            var ruins = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Explore", "Travel more" }));
            if (ruins == "Explore")
            {
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
            //ADD LVL FUNCTION TO ENEMY AND PLAYER (RANDOM LVL ENEMY) ??????????
            Console.WriteLine($"While traveling you found dead rat and you see a {list.combat[combatRng]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (stats.playerHP > 0 && stats.enemyHP > 0)
            {
                combat:
                Console.WriteLine($"{stats.playerName} HP: {stats.playerHP}\n{list.combat[combatRng]} HP: {stats.enemyHP}");
                var combatDesert = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Attack", "Run" }));
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
            var pyramid = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Explore", "Travel more" }));
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
else //INVERNTORY
{
    design.inventory();
    goto travel;
}
#endregion DESERT
#region
stats.stamina = 100;
AnsiConsole.Write(new FigletText("Ocean").Centered());
Thread.Sleep(1700);
Console.Clear();
Console.WriteLine("Your stamina is now 100");
Thread.Sleep(1500);
Console.Clear();
oceanTravel:
var ocean = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "", "Search near you for resources", "Inventory" }));
while (stats.stamina == 0)
{
    Console.WriteLine("You passed out, because you were out of stamina");
    Thread.Sleep(2000);
    Console.Clear();
    stats.stamina += 100;
    goto oceanTravel;
}
while (stats.progressLvl >= 200)
{
    stats.lvl++;
    stats.progressLvl = 0;
}
if (ocean == "")
{
    int combatOcean = help.generator.Next(0,list.combatOcean.Count());
    int Index = help.generator.Next(0, 2);
}
else if (ocean == "Search near you for resources")
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
else if ("Inventory") //INVERNTORY
{
    design.inventory();
    goto oceanTravel;
}
#endregion OCEAN










//FIX GOTO FROM DESERT TO OCEAN
//ITEM DESIGN EITHER WITH PANEL OR TABLE
//MAYBE ADD TIMER FROM VISUAL TIME SPENT PLUGIN
//https://www.geeksforgeeks.org/console-setwindowsize-method-in-c-sharp/