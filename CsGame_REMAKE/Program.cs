global using CsGame_REMAKE;
using Spectre.Console;
using System.Diagnostics;

Helper help = new Helper();
Desert desert = new Desert();

#region Colors
var colorRed = new Style().Foreground(Color.Red);
var colorOcean = new Style().Foreground(Color.DodgerBlue2);
#endregion

while (true)
{
menu:
    AnsiConsole.Write(new FigletText("Wanderer's Tale").Centered().Color(Color.Red));
    var menu = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(4).HighlightStyle(colorRed).AddChoices(new[] { "Start Game", "Credits", "Report a bug", "Exit" }));

    if (menu == "Start Game") { Console.Clear(); break; } //START
    else if (menu == "Credits")
    {
        var credits = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorRed).AddChoices(new[] { "Endings", "Updates", "Go back to title screen" }));
        if (credits == "Endings") //fix by inserting text under Header "Endings" or something
        {
            var PanelEnd = new Panel("Endings");
            PanelEnd.AsciiBorder();
            //PanelEnd.Header = new PanelHeader();
            foreach (var item in Lists.endings)
            {
                Debug.WriteLine(item);
                PanelEnd = new Panel(item);
            }
            AnsiConsole.Write(PanelEnd);
            Thread.Sleep(2500);
            Console.Clear();
            goto menu;
        } //ENDINGS
        else if (credits == "Updates")
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
    else if (menu == "Report a bug")
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
#region Starting Info
Console.WriteLine("Enter your name wanderer");
Player.playerName += Console.ReadLine();
Console.Clear();
Console.WriteLine($"Welcome {Player.playerName}\nyou found yourself in desert and your goal is to find civilization");
Thread.Sleep(2250);
Console.Clear();
Console.WriteLine("Collect resources and survive, your stamina is limited to 50 per day");
Thread.Sleep(2250);
Console.Clear();
#endregion

help.TestPlayer();
desert.Desert_Start();
















//else if (ocean == "Inventory")
//{
//    AnsiConsole.Write(new FigletText("Coming soon").Color(Color.DodgerBlue2).Centered());
//    Thread.Sleep(1500);
//    Console.Clear();
//    goto oceanTravel;
//    //var tableInv = new Table();
//    //tableInv.AddColumn("Name");
//    //tableInv.AddColumn($"{stats.playerName}");
//    //tableInv.AddColumn("Pockets");
//    //tableInv.AddRow("LVL", $"{stats.lvl}");
//    //tableInv.AddRow("Progress", $"{stats.progressLvl}");
//    //tableInv.AddRow("HP", $"{stats.playerHP}");
//    //tableInv.AddRow("MP", $"{stats.mana}");
//    //tableInv.AddRow("Hunger", $"{stats.hunger}");
//    //tableInv.AddRow("Thirst", $"{stats.thirst}");
//    //tableInv.AddRow("Stamina", $"{stats.stamina}");
//    //tableInv.AddRow("Armor", $"{stats.armor}");
//    //tableInv.AddRow("Damage", $"{stats.playerAttack}");
//    //AnsiConsole.Write(tableInv);
//    //var inventory = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorInv).AddChoices(new[] { "Crafting", "Cooking", "Go back" }));
//    //if (inventory == "Crafting")
//    //{

//    //} //CRAFTING
//    //else if (inventory == "Cooking")
//    //{

//    //} //COOKING
//    //else
//    //{
//    //    if (ocean == "Inventory")
//    //    {
//    //        Console.Clear();
//    //        goto oceanTravel;
//    //    }
//    //    else
//    //    {
//    //        Console.Clear();
//    //        goto travel;
//    //    }
//    //}
//} //INVENTORY




//var values = new string[6] { "red", "green", "blue", "red", "red", "green" };
//foreach (var itemm in values.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => new { Value = g.Key, Count = g.Count() }))
//    Debug.WriteLine($"{itemm.Value} x {itemm.Count}");



//endings
//FIX INVENTORY
//ADD RANDOM CHANCE OF ENCOUNTER? KRAKEN
//ADD LVL FUNCTION TO ENEMY AND PLAYER (RANDOM LVL ENEMY) ??????????
//ADD COOKING
//ADD CRAFTING
//ITEM DESIGN EITHER WITH PANEL OR TABLE
//https://www.geeksforgeeks.org/console-setwindowsize-method-in-c-sharp/