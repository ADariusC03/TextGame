using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComplexMalic_1._0v
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            currentPlayer = Load(out bool newP);
            if(newP)
                Encounter.FirstEncounter();

            while (mainLoop)
            {
                Encounter.RandomEncounter();
            }

        }


        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Print("Complex MALICE!", 60);
            Console.WriteLine();
            Console.WriteLine("Name:");
            p.Name = Console.ReadLine();
            p.saveId = i;
            Console.Clear();
            Print("Welcome! MALICE Awaits The Weak Soul!", 30);
            Console.WriteLine();
            Print("**Thundering and Stormy Night**  You awake from a lucid dream with your long, lost love." +
                "Only to find yourself in a cold, dark eerie room.", 50);
            Print("You decided to get up, but feel light-headed, having trouble remembering how you got there.", 40);
            if (p.Name == "")
                Console.WriteLine("You barley remember your own name......");
            else
                Console.WriteLine("Funny, You do remember your name is ." + p.Name);
            Console.ReadKey();
            Console.Clear();
            Print("**Thunder RUMBLES and Lighting EMMITS The Dark Room From The Tall Window On The Wall**", 40);
            Console.WriteLine();
            Print("In the brief moment of given light you see a door with a handle........" +
                "You grope around in the dark to the find the door. Lucky YOU the door handle isn't rusted........" +
                "Unlucky YOU the door itself is locked from the otherside. Sadly, hitting and banging the door doesn't do the trick." +
                "So you grope around along the walls in darkness.", 30);
            Console.WriteLine();
            Print("**Lighting Emmits The Room Again**", 40);
            Console.WriteLine("There you see an small, dirty vintage rug, whcih has one end flipped up.");
            Print("**Curious** You make your way to the small rug, and feel underneath its a old metal grate. " +
                "You lift the grate open and jump in.", 40);
            Print(" Underneath lays an illuminated stone room with what appears to be a religious cross on the floor" +
                "surrounded by skulls and lit candles.", 30);
            Console.WriteLine();
            Print("You slowly creep around, analizing the room until you see across the hall a man in bloody clothes" +
                " occupied cutting, what could be human flesh........?!!?!?!?", 30);
            Console.WriteLine();
            return p;


        }
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }
        public static void Print(string text, int speed)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        public static void Save()
        {
            BinaryFormatter binFore = new BinaryFormatter();
            string path = "saves/" + currentPlayer.saveId.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binFore = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binFore.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose Your Player........If You Have The Will To Fight!!!");


                foreach (Player p in players)
                {
                    Console.WriteLine(p.saveId + ": " + p.Name);

                }
                Console.WriteLine("Please Input Player Name or ID  (id:# or playername). Additionally, 'Create' will start a new save! ");
                string[] data = Console.ReadLine().Split(':');
                try
                {
                   if(data[0] == "id")
                    {
                        if(int.TryParse(data[1],out int saveId))
                        {
                            foreach (Player player in players)
                            {
                                if(player.saveId == saveId)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There Isn't No Player With That ID!!!!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your ID Needs To Be A Number! ...... Press Any Key To Continue!");
                            Console.ReadKey();
                        }
                    }
                   else if(data[0] == "Create")
                    {
                       Player newPlayer =  NewStart(idCount);
                        newP = true;
                        return newPlayer;
                       
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.Name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There Is NO Player With That Name .....");
                        Console.ReadKey();
                    }
                }
                
                catch (IndexOutOfRangeException)
                {

                    Console.WriteLine("Your ID Needs To Be A Number! ...... Press Any Key To Continue!");
                    Console.ReadKey();
                }


             }

        }
    }

}

