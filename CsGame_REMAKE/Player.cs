﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Player
    {
        #region Player
        public static string playerName { get; set; }
        public static int hunger = 100;
        public static int thirst = 100;
        public static int playerHP = 100;
        public static int lvl = 0;
        public static int maxlvl = 5;
        public static int progressLvl;
        public static int mana = 0;
        public static int armor = 0;
        public static int stamina = 50;
        public static int maxStamina = 50;
        public static int healAmount;
        public static int playerAttack = 2;
        #endregion
        #region Enemy
        public static int enemyHP = 20;
        public static int enemyAttack = 3;
        public static int enemyMana;
        public static int enemyLvl;
        #endregion
    }
}