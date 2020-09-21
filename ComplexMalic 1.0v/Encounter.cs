using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexMalic_1._0v
{
   public  class Encounter
    {
        static Random rand = new Random();

        //Encounter Generics
        public static void FirstEncounter()
        {
            Console.WriteLine("You see a knife stuck into a rotting body, and slowly pulls it out while trying not to gag. " +
                "You move slowly towards his direction until you mistakenly step on a skull.");
            Console.WriteLine();
            Console.WriteLine("He turns around......");
            Console.ReadKey();
            Combat(false, "The Skinner", 10, 1);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("Silently, Your walking down the corridor until you seen an enemy go around the corner.........");
            Console.WriteLine();
            Console.WriteLine("Following them your stomach growls, alerting the curious enemy.... ");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void TyrantEncounter()
        {
            int p = Program.currentPlayer.pName;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("**Rumbling and Destruction Is Heard Throughout The Building**");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Dead bodies and splatter of blood is everywhere as you keep walking hoping whatever is destorying stays in that area until you can leave.");
            Console.WriteLine();
            Console.WriteLine("You walk towards a door. Uses the door handle to enter and see stairs leading to a new room.");
            Console.WriteLine();
            Console.WriteLine("After reaching the final steps, You enter into a hummid, mysterious room..... Reminds you of a airport lounge without the horrible smell and dead bodies");
            Console.WriteLine();
            Console.WriteLine("You walk towards a receptionist desk to see if any information is displayed on where you are located.");
            Console.WriteLine("Until........................**RUMBLING AND DESTRUCTION SOUNDS COMMING CLOSER**");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("**Busting Through The Walls** a very tall figure, 6ft 7inches, appears in front of you, wearing bloody stain boots, long black ripped pants and no shirt," +
                "but has grey skin with many scars. Notibly it has scar in the shape of a BIG M over it's heart");
            Console.ResetColor();
            Console.WriteLine("HOLY SHIT!, you gotta kidding me?!? I know you been drinking your milk daily,says" + p + ".");
            Console.WriteLine("You ARE not ALLOWED here, say Mr.Mal.... Prepare for trouble...");
            Console.WriteLine("Or Make It Double?? I know you not qouting team Rockect, says" + p + ". Mr.Mal looks at you displeased and confused  " +
                "clenching his fist ready to strike. You say Well I guess I'm not a comedian then lets get this over with bub.");
            Console.ReadKey();
            Combat(false, "Mr. Mal", 30, 6);

        }

          public static void PuzzleEncounter()
          { int p = Program.currentPlayer.pName;
            Console.Clear();
            Console.WriteLine("**Mr.Mal is defeated leaving an open path to explore**");
            Console.WriteLine("**Grabbing an flashlight from the desk** You decide to go through the open wall to explore." +
                "Little is known about this area as you slowly walk in the dark with your flashlight.");
            Console.WriteLine();
            Console.WriteLine("Upon walking the quiet halls, you bump into something that seems to be hanging from the cieling.");
            Console.WriteLine();
            Console.WriteLine("You shine the flashlight up and see a nun hanging from a noose,with his eyes gouged out and a note on her chest" +
                "saying : Welcome AT Your Own Dismise!");
            Console.WriteLine();
            Console.WriteLine("Geez thats a nice way to welcome someone. I need to get out of this hell-hole says" + p + " Continuing to walk" +
                "You see a trial of blood in your path, hoping it'll lead you into an exit.");
            Console.WriteLine();
            Console.WriteLine("You come upon a two dead cops laying against bot sides of a wall near a door with there intestines ripped out and there eyes gouged out.");
            Console.WriteLine();
            Console.WriteLine("You inspect one of the dead bodies and find a note pertaining to the door");
            Console.WriteLine();

            List<int> list = new List<int>();
            Random ran = new Random();
            int swapOne, swapTwo;

            for (int i = 0; i < 7; i++)
            {
                list.Add(ran.Next(0, 100));

            }

            Console.WriteLine("You read the note that says to swap the numbers on the door in a list until they're in ascending numerical order.");

            while (true)
            {
                swapOne = -1;
                swapTwo = -1;

                WriteOutList(list);

                while (list.Contains(swapOne) == false)
                {
                    Console.WriteLine("What first number would you like to swap?");
                    swapOne = Convert.ToInt32(Console.ReadLine());
                }

                while (list.Contains(swapTwo) == false)
                {
                    Console.WriteLine("What second number would you like to swap?");
                    swapTwo = Convert.ToInt32(Console.ReadLine());

                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == swapOne)
                    {
                        list[i] = swapTwo;
                    }
                    else if(list[i] == swapTwo)
                    { 
                        list[i] = swapOne; 
                    }

                }

                List<int> sortedList = new List<int>(list);
                sortedList.Sort();

                if (list.SequenceEqual(sortedList) == true)
                {
                    WriteOutList(list);
                    Console.WriteLine("Door is now open.");
                    break;
                }
            }

            Console.ReadLine();

            static void WriteOutList(List<int> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i] + ", ");
                }
                Console.WriteLine();
            }
          }




        //Encounter






        //Encounter Tools
        public static void RandomEncounter()
        {
            switch (rand.Next(0, 3))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    TyrantEncounter();
                    break;
                case 2:
                    PuzzleEncounter();
                break;
            }
        }
        public static void Combat(bool random, string name, int health, int power)
        {

            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {    
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;

            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=======================");
                Console.WriteLine("| (A)ttack   (D)efend |");
                Console.WriteLine("| (R)un      (H)eal   |");
                Console.WriteLine("=======================");
                Console.WriteLine(" Food: " + Program.currentPlayer.Food + " Health: " + Program.currentPlayer.Health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("With courage you stab the enemy with your knife!! Gruesome Hit but, " + n + " strikes you back.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4) + ((Program.currentPlayer.currentClass == Player.PlayerCLass.StreetFigher)?2:0);

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.Health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("As" + n + " perpares to strike. You cover yourself in a defensive pose.");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.Health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if (Program.currentPlayer.currentClass != Player.PlayerCLass.RookieCop && rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you run away from the " + n + ", its strike catches your back ankle making you sprawl on the ground");
                        int damage = Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and is UNABLE to ESCAPE!!!");
                        Program.currentPlayer.Health -= damage;
                        
                    }
                    else
                    {
                        Console.WriteLine("You envade the " + n + " and succesfully escape. (!!FOR NOW!!)");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (Program.currentPlayer.Food == 0)
                    {
                        Console.WriteLine("You Look In Bag And No Food Is Availible; Only Thing Left Is HOPE.....");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " strikes you with an alarming blow, making you lose " + damage + " health.");

                    }
                    else
                    {
                        Console.WriteLine("You reach in the bag and pulls out a Turkey Leg. You begin to intake it,**munch munch munch**");
                        int foodV = 5;
                        Console.WriteLine("You gain " + foodV + " health");
                        Program.currentPlayer.Health += foodV;
                        Program.currentPlayer.Food--;
                        Console.WriteLine("As you were occupied " + n + " went ahead and hit you.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health.");
                    }
                    
                }
                if (Program.currentPlayer.Health <= 0)
                {
                    //Death Code :)
                    Console.WriteLine("**BLOODY aNd Menacingly** .....The " + n + " stands over your body ready to dismember it!!....WELCOME TO MALICE");
                    Console.WriteLine("YOUR DEAD!");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();


            }
            int z = Program.currentPlayer.GetDollars();
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("As you stand covered in blood victories over " + n + ", its body dissovles into " + z + " dollars.You have gain "+ x +" XP!");
            Program.currentPlayer.Zenii += z;
            Program.currentPlayer.xp += x;

            if (Program.currentPlayer.CanLevelUp())
                Program.currentPlayer.levelUP();

           Console.ReadKey();
        }
        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Creepers";
                case 1:
                    return "Skinners";
                case 2:
                    return "Chimera";
                case 3:
                    return " Scarlett";
            }
            return "Infected-Human";

        }
        
        
    }
}

