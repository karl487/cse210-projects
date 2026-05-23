using System;



using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // =========================================================================
    // ENTRY CLASS
    // =========================================================================
    public class Entry
    {
        // Member variables (using encapsulation with private fields and public properties)
        private string _date;
        private string _promptText;
        private string _entryText;

        public string Date 
        { 
            get => _date; 
            set => _date = value; 
        }
        public string PromptText 
        { 
            get => _promptText; 
            set => _promptText = value; 
        }
        public string EntryText 
        { 
            get => _entryText; 
            set => _entryText = value; 
        }

        // Constructor for clean object initialization
        public Entry(string date, string promptText, string entryText)
        {
            _date = date;
            _promptText = promptText;
            _entryText = entryText;
        }

        // Displays a single entry
        public void Display()
        {
            Console.WriteLine($"\nDate: {_date}");
            Console.WriteLine($"Prompt: {_promptText}");
            Console.WriteLine($"Response: {_entryText}");
            Console.WriteLine(new string('-', 30));
        }
    }

    // =========================================================================
    // PROMPT GENERATOR CLASS
    // =========================================================================
    public class PromptGenerator
    {
        private List<string> _prompts;
        private Random _random;

        public PromptGenerator()
        {
            _random = new Random();
            // Initialize with sample prompts
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }

        // Selects and returns a random prompt from the list
        public string GetRandomPrompt()
        {
            if (_prompts.Count == 0) return "No prompts available.";
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }

    // =========================================================================
    // JOURNAL CLASS
    // =========================================================================
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        // Adds a new entry object to the internal list
        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        // Iterates through and displays every entry
        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nYour journal is empty.");
                return;
            }

            foreach (var entry in _entries)
            {
                entry.Display();
            }
        }

        // Saves current entries to a flat comma-separated values (CSV) file
        public void SaveToFile(string file)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (var entry in _entries)
                    {
                        // Escape pipes to prevent file corruption if user types a pipe symbol
                        string date = entry.Date.Replace("|", "~");
                        string prompt = entry.PromptText.Replace("|", "~");
                        string response = entry.EntryText.Replace("|", "~");

                        writer.WriteLine($"{date}|{prompt}|{response}");
                    }
                }
                Console.WriteLine($"\nJournal successfully saved to: {file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError saving file: {ex.Message}");
            }
        }

        // Loads entries from a text file, clearing any unsaved memory states first
        public void LoadFromFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"\nError: The file '{file}' does not exist.");
                return;
            }

            try
            {
                _entries.Clear(); // Refresh internal memory state
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                        _entries.Add(loadedEntry);
                    }
                }
                Console.WriteLine($"\nJournal successfully loaded from: {file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError reading file: {ex.Message}");
            }
        }
    }

    // =========================================================================
    // PROGRAM ENTRY POINT (DRIVER CODE)
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            PromptGenerator promptGen = new PromptGenerator();
            bool runProgram = true;

            Console.WriteLine("Welcome to the Digital Journal App!");

            while (runProgram)
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Write Entry
                        string prompt = promptGen.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string userResponse = Console.ReadLine();
                        string currentDate = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(currentDate, prompt, userResponse);
                        myJournal.AddEntry(newEntry);
                        break;

                    case "2": // Display Entries
                        myJournal.DisplayAll();
                        break;

                    case "3": // Load File
                        Console.Write("\nWhat is the filename? ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        break;

                    case "4": // Save File
                        Console.Write("\nWhat is the filename? ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        break;

                    case "5": // Quit
                        runProgram = false;
                        Console.WriteLine("\nGoodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }
    }
}