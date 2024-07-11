using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Collections;

namespace CsGame_REMAKE
{
    internal class Helper
    {
        public static Random generator = new Random();
        public string InputCode;
        private string ItemName;
        private string ItemDes;
        private string ItemSkill;
        private int ItemDamage;
        private int ItemCritDamage;
        private int ItemCritChance;
        private int ItemDefense;

        private void ShowSecretItem()
        {
            var tableItem = new Table();
            tableItem.AsciiDoubleHeadBorder();
            tableItem.AddColumn(ItemName);
            tableItem.AddRow($"Damage: {ItemDamage.ToString()}");
            tableItem.AddRow($"Critical Damage: {ItemCritDamage.ToString()}");
            tableItem.AddRow($"Critical Chance: {ItemCritChance.ToString()}%");
            if (InputCode == "fullsetberserk") { tableItem.AddRow($"Defense: {ItemDefense.ToString()}"); tableItem.AddRow($"Item Skill: {ItemSkill}"); }
            if (InputCode == "hl") { tableItem.AddRow($"Item Description: {ItemDes}"); }
            AnsiConsole.Write(tableItem);
        }
        private void Crafting(Style color, Color borderColor)
        {
            var treeCraft = new Tree("Crafting").Guide(TreeGuide.Line).Style(color);
            var axe = treeCraft.AddNode("Axe");
            axe.AddNodes(new[] { "2x Wooden sticks", "1x Stone", "1x Rope" });
            //var tableCraft = treeCraft.AddNode(new Table().Ascii2Border().BorderColor(borderColor).AddColumn("Backpack").AddRow("10x Cloth").AddRow("5x Rope"));
            var backpack = treeCraft.AddNode("Backpack");
            backpack.AddNodes(new[] { "20x Cloth", "5x Rope" });
            var boat = treeCraft.AddNode("Boat");
            boat.AddNode("10x Wood");
            //var fireplace = treeCraft.AddNode("Fireplace");
            //fireplace.AddNodes(new[] { "5x Hay", "5x Wooden sticks", "10x Bricks" });
            AnsiConsole.Write(treeCraft);
            var craftingItem = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(color).AddChoices(new[] { "Axe", "Backpack" })); //"Fireplace"
            switch (craftingItem)
            {
                case "Axe":
                    if(Lists.pockets.Count(item => item == "Wooden sticks") >= 2 && Lists.pockets.Count(item => item == "Rocks") >= 1 && Lists.pockets.Count(item => item == "Rope") >= 1)
                    {
                        Lists.pockets.Remove("Wooden sticks");
                        Lists.pockets.Remove("Wooden sticks");
                        Lists.pockets.Remove("Rocks");
                        Lists.pockets.Remove("Rope");
                        ItemName = "Axe";
                        ItemDamage = 10;
                        ItemCritDamage = 26;
                        ItemCritChance = 54;
                        ShowSecretItem();
                        Console.Read();
                    }
                    break;

                case "Backpack":
                    if (Lists.pockets.Count(item => item == "Cloth") >= 10 && Lists.pockets.Count(item => item == "Rope") >= 5) //either do +20 more spaces for pockets or another space for resources
                    {
                        for (int i = 0; i <= 10; i++) { Lists.pockets.Remove("Cloth"); }
                        for (int i = 0; i <= 5; i++) { Lists.pockets.Remove("Rope"); }
                        //Lists.pockets.RemoveRange(Lists.pockets.IndexOf("Cloth"), 20);
                        //Lists.pockets.RemoveRange(Lists.pockets.IndexOf("Rope"), 5);
                        foreach (var item in Lists.pockets) { Debug.WriteLine(item); }
                        Player.hasBackpack = true;
                        Console.WriteLine("You crafted a backpack, now you have more space for resources");
                    }
                    break;

                case "Fireplace": //unlock cooking with this
                    Console.WriteLine("Coming Soon");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
            Console.Clear();

        }
        private void Cooking()
        {

        }
        public void TestPlayer()
        {
            if (Player.playerName == "test")
            {
                Player.stamina = 9999;
                Player.playerHP = 9999;
                Player.playerAttack = 9999;
            } //TESTING NAME
        }
        public void LevelUP(int requirment)
        {
            if (Player.progressLvl >= requirment)
            {
                Player.lvl++;
                Player.progressLvl -= requirment;
                Console.WriteLine($"You leveled up!\nYou currently have {Player.lvl}/{Player.maxlvl} LVLs");
                Thread.Sleep(2000);
                Console.Clear();
            } //NEW LEVEL
        }
        public void OutOfStamina(int maxstamina)
        {
            if (Player.stamina == 0)
            {
                Console.WriteLine("You passed out, because you were out of stamina");
                Thread.Sleep(2000);
                Console.Clear();
                Player.stamina += maxstamina;
                //RuinsChecker = false;
                //PyramidChecker = false;
                //Desert_Start();
            } //OUT OF STAMINA
            else if (Player.stamina <= maxstamina / 2)
            {
                Console.WriteLine("You are feeling tired, you should rest");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        public void Hunger()
        {
            if (Player.hunger == 0) { GameOver(); }
            else if (Player.hunger <= 50)
            {
                Console.WriteLine("You are staring to feel hungry, you should eat something");
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
        public void Thirsty()
        {
            if (Player.thirst == 0) { GameOver(); }
            else if (Player.thirst <= 50)
            {
                Console.WriteLine("You are starting to feel thirty, you should drink something");
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
        public void GameOver() //check this later for better function
        {
            if (Player.playerHP <= 0 || Player.hunger <= 0 || Player.thirst <= 0)
            {
                Player.hasDied = true;
                Lists.endings.Add("Dead");
                Console.WriteLine("You died");
                Thread.Sleep(2000);
                Restart();
                return;
            }
            //either close window or start again from start
        }
        public void Restart() //this too
        {
            Desert restart = new Desert();
            Console.WriteLine("Do you want to play again\n(Y/N)");
            string yn = Console.ReadLine().ToLower();
            if (yn == "y") { Console.Clear(); restart.Desert_Start(); }
            else { return; }
        }
        public void BasicCombat(int combatIndex, List<string> type, Style color, List<string> Items, int ItemsIndex, int EnemyHP, int EnemyATT, int EnemyBoostHP, int EnemyBoostATT)
        {
            #region Variables
            int Run = generator.Next(0, 100);
            if (Player.noobDiff == true)
            {
                Player.enemyHP = EnemyHP / 2;
                Player.enemyAttack = EnemyATT - 2; //for rn cuz EnemyAtt is 3
            } //easy
            else if (Player.hardDiff == true)
            {
                Player.enemyHP = EnemyHP * EnemyBoostHP;
                Player.enemyAttack = EnemyATT + EnemyBoostATT;
            } //hard
            else
            {
                Player.enemyHP = EnemyHP;
                Player.enemyAttack = EnemyATT;
            } //normal
            #endregion
            Console.WriteLine($"While traveling you see a {type[combatIndex]} coming towards you");
            Thread.Sleep(2000);
            Console.Clear();
            while (Player.playerHP > 0 && Player.enemyHP > 0)
            {
            combat:
                Console.WriteLine($"{Player.playerName}'s HP: {Player.playerHP}\n{type[combatIndex]}'s HP: {Player.enemyHP}");
                var Combat = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(color).AddChoices(new[] { "Attack", "Run" }));
                switch (Combat)
                {
                    case "Attack":
                        Player.enemyHP -= Player.playerAttack;
                        Console.WriteLine($"You dealt {Player.playerAttack} damage to {type[combatIndex]}");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "Run": //40% chance to run
                        if (Run <= 40) { Console.WriteLine("You ran away"); return; }
                        else { Console.Clear(); goto combat; }
                } //PLAYER TURN
                if (Player.enemyHP > 0)
                {
                    Player.playerHP -= Player.enemyAttack;
                    Console.WriteLine($"{type[combatIndex]} dealt {Player.enemyAttack} damage");
                    Thread.Sleep(1500);
                    Console.Clear();
                } //ENEMY TURN
            } //OCEAN COMBAT
            if (Player.playerHP > 0)
            {
                Player.progressLvl += Run;
                Console.WriteLine($"You won against {type[combatIndex]} and found {Items[ItemsIndex]}");
                Lists.pockets.Add(Items[ItemsIndex]);
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
        public void AdvanceCombat(int combatIndex, List<string> type, Style color, int EnemyHP, int EnemyATT, int EnemyBoostHP, int EnemyBoostATT )
        {
            #region Variables
            int Run = generator.Next(0, 100);
            if (Player.noobDiff == true)
            {
                Player.enemyHP = EnemyHP / 2;
                Player.enemyAttack = EnemyATT - 2; //for rn cuz EnemyAtt is 3
            } //easy
            else if (Player.hardDiff == true)
            {
                Player.enemyHP = EnemyHP * EnemyBoostHP;
                Player.enemyAttack = EnemyATT + EnemyBoostATT;
            } //hard
            else
            {
                Player.enemyHP = EnemyHP;
                Player.enemyAttack = EnemyATT;
            } //normal
            #endregion

        }
        public void Inventory(Style color, Color borderColor)
        {
            //var colorInv = new Style().Foreground(Color.White);
            #region Table Info
            int i = 0;
            var tableInv = new Table();
            tableInv.BorderColor(borderColor);
            tableInv.Border(TableBorder.AsciiDoubleHead);
            tableInv.AddColumn($"{Player.playerName}");
            tableInv.AddColumn("");
            tableInv.AddColumn($"Pockets {Lists.pockets.Count()}/20");
            tableInv.AddRow("LVL", $"{Player.lvl}");
            tableInv.AddRow("Progress", $"{Player.progressLvl}/{Player.LVLRequirment}");
            tableInv.AddRow("HP", $"{Player.playerHP}");
            tableInv.AddRow("MP", $"{Player.mana}");
            tableInv.AddRow("Hunger", $"{Player.hunger}");
            tableInv.AddRow("Thirst", $"{Player.thirst}");
            tableInv.AddRow("Stamina", $"{Player.stamina}");
            tableInv.AddRow("Armor", $"{Player.armor}");
            tableInv.AddRow("Damage", $"{Player.playerAttack}");
            foreach (var multiItem in Lists.pockets.GroupBy(x => x).Where(g => g.Count() >= 1).Select(g => new { Value = g.Key, Count = g.Count() }))
            {
                Debug.WriteLine($"{multiItem.Count}x {multiItem.Value}");
                tableInv.UpdateCell(i, 2, $"{multiItem.Count}x {multiItem.Value}");
                i++;
            }
            if (Player.hasBackpack)
            {
                tableInv.AddColumn("Backpack");
                foreach (var backpackItems in Lists.backpack.GroupBy(x => x).Where(g => g.Count() >= 1).Select(g => new { Value = g.Key, Count = g.Count() }))
                {
                    Debug.WriteLine($"{backpackItems.Count}x {backpackItems.Value}");
                    tableInv.UpdateCell(i, 3, $"{backpackItems.Count}x {backpackItems.Value}");
                    i++;
                }
            }
            AnsiConsole.Write(tableInv);
            #endregion
            var inventory = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(3).HighlightStyle(color).AddChoices(new[] { "Crafting", "Cooking", "Go back" }));
            Console.Clear();
            switch (inventory)
            {
                case "Crafting":
                    Crafting(color, borderColor);
                    break;

                case "Cooking":
                    Cooking();
                    Console.WriteLine("Coming Soon!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
            Console.Clear();
        } //rest option here maybe
        public void CodeChanger()
        {
            if (!Lists.secret.Contains(InputCode))
            {
                Debug.WriteLine(InputCode);
                switch (InputCode.ToLower())
                {
                    //case "energysword":
                    //    ItemName = "Energy Sword";
                    //    ItemDamage = 200;
                    //    ItemCritDamage = 450;
                    //    ItemCritChance = 35;
                    //    break;

                    case "hl":
                        ItemName = "Crowbar";
                        ItemDamage = 50;
                        ItemCritDamage = 110;
                        ItemCritChance = 48;
                        ItemDes = "Stolen crowbar from some guy named G. Freeman";
                        break;

                    case "fullsetberserk":
                        ItemName = "Dragon Slayer";
                        ItemSkill = "Berserk Mode";
                        ItemDamage = 550;
                        ItemCritDamage = 1270;
                        ItemCritChance = 20;
                        ItemDefense = 250;
                        break;

                    case "zenith":
                        ItemName = "Zenith";
                        ItemDamage = 478;
                        ItemCritDamage = 678;
                        ItemCritChance = 39;
                        break;

                    case "bloodmoon":
                        Console.WriteLine("You unlocked hard difficulty");
                        Player.hardDiff = true;
                        Player.EnemyDamageBooster = 10;
                        Player.EnemyHPBooster = 5;
                        return;

                    case "noob":
                        Console.WriteLine("You unlocked easy difficulty");
                        Player.noobDiff = true;
                        return;

                    case "tansazangetsu":
                        ItemName = "Tansa Zangetsu";
                        ItemDamage = 386;
                        ItemCritDamage = 756;
                        ItemCritChance = 40;
                        break;

                    case "livinghell":
                        Console.WriteLine("You unlocked short story for ending Living hell\n(Find the ending again to play it)");
                        Livinghell.OpenHell = true;
                        break;
                }
                ShowSecretItem();
            }
            else { Debug.WriteLine(InputCode); Console.Clear(); return; }
        }
    }
}