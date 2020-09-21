using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexMalic_1._0v
{
    public class Shop
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int foodP;
            int armorP;
            int weaponP;
            int levelP;

            while (true)
            {
                foodP = 10 + 10 * p.mods;
                armorP = 50 + 20 * (p.armorValue + 1);
                weaponP = 100 + p.weaponValue;
                levelP = 300 + 100 * p.mods;

                Console.Clear();
                Console.WriteLine("            Shop           ");
                Console.WriteLine("===========================");
                Console.WriteLine("| (F)ood:        $" + foodP);
                Console.WriteLine("| (A)rmor:       $" + armorP);
                Console.WriteLine("| (W)eapons:     $" + weaponP);
                Console.WriteLine("| (L)evel Mod:   $" + levelP);
                Console.WriteLine("============================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(p.Name + "   Stats          ");
                Console.WriteLine("===========================");
                Console.WriteLine("Dollars :" + p.Zenii);
                Console.WriteLine("| Current Health: " + p.Health);
                Console.WriteLine("| Armor Touhness: " + p.armorValue);
                Console.WriteLine("| Weapon Strenght: " + p.weaponValue);
                Console.WriteLine("| Food: " + p.Food);
                Console.WriteLine("| Level DIfficulty: " + p.mods);
                Console.WriteLine("============================");

                Console.WriteLine("XP:");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.xp / (decimal)p.GetLevelUpValue()), 25);
                Console.Write("]");

                Console.WriteLine("Level: " + p.level);
                Console.WriteLine("==================================================");

                string input = Console.ReadLine().ToLower();
                if (input == "f" || input == "Food")
                {
                    TryBuy("food", foodP, p);
                }
                else if (input == "a" || input == "Armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "w" || input == "Weapons")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "l" || input == "Level Mod")
                {
                    TryBuy("level", levelP, p);
                }
                else if(input == "q" || input == "quit")
                {
                    Program.Quit();
                }
                else if (input == "e" || input == "exit")
                    break;
            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.Zenii >= cost)
            {
                if (item == "food")
                    p.Food++;
                else if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "level")
                    p.mods++;

                p.Zenii -= cost;
            }
            else
            {
                Console.WriteLine("What Are You Doing??? Not Enough Dollars Partner!");
                Console.ReadKey();
            }
        }




    }
}

