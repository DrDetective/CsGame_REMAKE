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
            public int mana = 0;
            public int armor = 0;
            public int stamina;
            public int healAmount;
            public int playerAttack;
            public int enemyHP;
            public int enemyAttack;
            public int enemyMana;
            public int enemyLvl;
    }
}