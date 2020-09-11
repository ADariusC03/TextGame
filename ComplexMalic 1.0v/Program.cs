using System;

namespace ComplexMalic_1._0v
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounter.FirstEncounter();
            while (mainLoop)
            {
                Encounter.RandomEncounter();
            }

        }


        static void Start()
        {
            Print("Complex MALICE!", 60);
            Console.WriteLine();
            Console.WriteLine("Name:");
            currentPlayer.Name = Console.ReadLine();
            Console.Clear();
            Print("Welcome! MALICE Awaits The Weak Soul!", 30);
            Console.WriteLine();
            Print("**Thundering and Stormy Night**  You awake from a lucid dream with your long, lost love." +
                "Only to find yourself in a cold, dark eerie room.", 40);
            Print("You decided to get up, but feel light-headed, having trouble remembering how you got there.", 40);
            if (currentPlayer.Name == "")
                Console.WriteLine("You barley remember your own name......");
            else
                Console.WriteLine("Funny, You do remember your name is ." + currentPlayer.Name);
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
    }
}

