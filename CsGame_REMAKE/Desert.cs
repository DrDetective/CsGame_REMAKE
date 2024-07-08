global using CsGame_REMAKE;
using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Desert
    {
        private bool intro = false;
        private bool endingCheck = false;
        //private bool RuinsChecker = false;
        //private bool PyramidChecker = false;

        private void DesertIntro()
        {
            if (!intro) { return; }
            AnsiConsole.Write(new FigletText("Desert").Color(Color.Yellow).Centered());
            Thread.Sleep(1700);
            Console.Clear();
            intro = true;
        }

        public void Desert_Start()
        {
            Lists list = new Lists();
            Helper help = new Helper();
            var colorYellow = new Style().Foreground(Color.Yellow);
            int desertItemsIndex = Helper.generator.Next(0, list.desertItems.Count);
            bool OceanChecker = false;
            DesertIntro();
            var desert = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Travel through desert", "Search near you for resources", "Inventory" }));
            help.LevelUP(100);
            help.OutOfStamina(50);

            switch (desert)
            {
                case "Travel through desert":
                ruinsTravel:
                    #region Variables
                    Player.stamina -= 10;
                    Player.hunger -= 5;
                    Player.thirst -= 5;
                    int randomTravel = Helper.generator.Next(0, 100);
                    int ruinsRandom = Helper.generator.Next(0, 100);
                    int combatRng = Helper.generator.Next(0, list.combatDesert.Count);
                    #endregion
                    if (randomTravel > 0 && randomTravel <= 20)
                    {
                        Console.WriteLine($"You traveled for few hours and found nothing\nRemaining stamina: {Player.stamina}/{Player.maxStamina}");
                        Thread.Sleep(2500);
                        Console.Clear();
                        Desert_Start();
                    } //Found Nothing
                    else if (randomTravel > 20 && randomTravel <= 50)
                    {
                        //if (RuinsChecker == true) { goto ruinsTravel; }
                        Console.WriteLine($"You found old ruins\nRemaining stamina: {Player.stamina}/{Player.maxStamina}");
                        var ruins = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
                        //RuinsChecker = true;
                        if (ruins == "Explore")
                        {
                            if (ruinsRandom > 90)
                            {
                                if (endingCheck == true) { return; } //ENDING CHECK
                                else
                                {
                                    list.endings.Add("Living Hell");
                                    endingCheck = true;
                                    Console.Clear();
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
                                    Desert_Start();
                                } //SECRET ENDING
                            }
                            else if (ruinsRandom <= 90)
                            {
                                Console.WriteLine($"You found {list.desertItems[desertItemsIndex]}");
                                //list.pockets.Add(list.desertItems[desertItemsIndex]);
                                Thread.Sleep(1750);
                                Console.Clear();
                                Desert_Start();
                            }
                        } //EXPLORE RUINS
                        else { goto ruinsTravel; } //RETURN TO TRAVEL MORE
                    } //Found Ruins
                    else if (randomTravel > 50 && randomTravel <= 70)
                    {
                        //if (PyramidChecker == true) { goto ruinsTravel; }
                        int pyramidIndex = Helper.generator.Next(0, list.pyramidItems.Count);
                        Console.WriteLine($"While traveling you found a pyramid\nRemaining stamina: {Player.stamina}/{Player.maxStamina}");
                        Thread.Sleep(1500);
                        var pyramid = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(colorYellow).AddChoices(new[] { "Explore", "Travel more" }));
                        //PyramidChecker = true;
                        if (pyramid == "Explore")
                        {
                            Console.WriteLine($"You found {list.pyramidItems[pyramidIndex]}");
                            list.pockets.Add(list.pyramidItems[pyramidIndex]);
                            Thread.Sleep(1750);
                            Console.Clear();
                            Desert_Start();
                        } //EXPLORE PYRAMIDS
                        else { goto ruinsTravel; } //RETURN TO TRAVEL MORE
                    } //Found Pyramid
                    else if (randomTravel > 70 && randomTravel <= 95)
                    {
                        help.Combat(combatRng, list.combatDesert, colorYellow, list.desertItems, desertItemsIndex, 20, 3);
                    } //Combat
                    else if (randomTravel > 95 && randomTravel <= 100)
                    {
                        OceanChecker = true;
                        Console.WriteLine("As You traveled for what felt like years you see a palm tree in distance\nyou feel as if you got your life back and made a run for it\nYou are in a new area");
                        Thread.Sleep(1600);
                        Console.Clear();
                        return;
                    } //Found Ocean
                    break;

                case "Search near you for resources":
                    #region Variables
                    Player.stamina -= 10;
                    Player.hunger -= 5;
                    Player.thirst -= 5;
                    int rng = Helper.generator.Next(0, 100);
                    //int secretIndex = Helper.generator.Next(0, list.secret.Count);
                    #endregion
                    //if (rng <= 20) FIX with better statement
                    //{
                    //    if (list.secret.Contains(list.secret[secretIndex])) { return; } //SECRET CODE CHECK
                    //    else
                    //    {
                    //        list.codes.Add(list.secret[secretIndex]);
                    //        Console.WriteLine($"You found a piece of paper\nIt says: {list.secret[secretIndex]}");
                    //        Thread.Sleep(1750);
                    //        Console.Clear();
                    //        Desert_Start();
                    //    } //SECRET CODE
                    //} //Found Secret Code
                    if (rng >= 0)
                    {
                        Console.WriteLine($"You searched for few hours and found {list.desertItems[desertItemsIndex]}\nRemaining stamina {Player.stamina}/{Player.maxStamina}");
                        list.pockets.Add(list.desertItems[desertItemsIndex]);
                        Thread.Sleep(2000);
                        Console.Clear();
                        Desert_Start();
                    } //Found resources
                    break;

                case "Inventory":
                    help.Inventory(colorYellow, Color.Yellow, list.pockets);
                    break;
            }
            if (OceanChecker == true) { return; }
            else { Desert_Start(); }
        }
    }
}

//after secret ending make it to start of the game instead of start of desert and maybe save ending in txt file
//AnsiConsole.Write(new FigletText("Coming soon").Color(Color.Yellow).Centered());
//Thread.Sleep(1500);
//Console.Clear();
//Desert_Start();
//var tableInv = new Table();
//tableInv.AddColumn("Name");
//tableInv.AddColumn($"{Player.playerName}");
//tableInv.AddColumn("Pockets");
//tableInv.AddRow("LVL", $"{Player.lvl}");
//tableInv.AddRow("Progress", $"{Player.progressLvl}");
//tableInv.AddRow("HP", $"{Player.playerHP}");
//tableInv.AddRow("MP", $"{Player.mana}");
//tableInv.AddRow("Hunger", $"{Player.hunger}");
//tableInv.AddRow("Thirst", $"{Player.thirst}");
//tableInv.AddRow("Stamina", $"{Player.stamina}");
//tableInv.AddRow("Armor", $"{Player.armor}");
//tableInv.AddRow("Damage", $"{Player.playerAttack}");
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