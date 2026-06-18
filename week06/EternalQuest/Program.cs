using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Optional: Clears out old terminal output for a clean UI look
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("    Welcome to the Eternal Quest Program    ");
            Console.WriteLine("=============================================");

            // 1. Create an instance of your GoalManager class
            GoalManager manager = new GoalManager();

            // 2. Start the main game/menu loop
            manager.Start();

            // 3. This executes only after the user chooses to "Quit" (Option 6)
            Console.WriteLine("\nThank you for using Eternal Quest. Goodbye!");
            Console.WriteLine("Press any key to close this window...");
            Console.ReadKey();
        }
    }
}