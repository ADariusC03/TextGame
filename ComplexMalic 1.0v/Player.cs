using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexMalic_1._0v
{[Serializable]
    public class Player
    {
        //Random rand = new Random();

        public string Name;
        public int saveId;
        public int level = 1;
        public int xp = 0;
        public int Health = 15;
        public int Damage = 1;
        public int Zenii = 1000;
        public int Food = 5;
        public int armorValue = 0;
        public int weaponValue = 1;

        public int mods = 0;

        public enum PlayerCLass {RookieCop, StreetFigher };
        public PlayerCLass currentClass = PlayerCLass.RookieCop;

        public int pName { get; private set; }

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return Program.rand.Next(lower, upper);
        }
        public int GetDollars()
        {
            int upper = (10 * mods + 50);
            int lower = (10 * mods + 10);
            return Program.rand.Next(lower, upper);
        }

        public int GetXP() 
        {
            int upper = (20 * mods + 50);
            int lower = (15 * mods + 10);
            return Program.rand.Next(lower, upper);
        }

        public int GetLevelUpValue()
        {
            return 100 * level + 400;
        }

        public bool CanLevelUp()
        {
            if (xp >= GetLevelUpValue())
                return true;
            else
                return false;
        }

        public void levelUP()
        {
            while (CanLevelUp())
            {
                xp -= GetLevelUpValue();
                level++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Program.Print("You Are Now Level" + level + "!.!.!",40);
            Console.ResetColor();
        }

        public static int GetName()
        {
            return Program.currentPlayer.pName;
        }
    }
}

