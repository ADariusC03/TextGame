using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexMalic_1._0v
{
    public class Player
    {
        Random rand = new Random();
        public string Name;
        public int Health = 15;
        public int Damage = 1;
        public int Zenii = 20000;
        public int Food = 5;
        public int armorValue = 0;
        public int weaponValue = 1;

        public int mods = 0;

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }
        public int GetDollars()
        {
            int upper = (10 * mods + 50);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);
        }
    }
}

