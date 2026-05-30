using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        /* 
         * EXCEEDING REQUIREMENTS:
         * To go beyond the core requirements, I have implemented a library of scriptures.
         * The program randomly selects a scripture from the list for the user to memorize.
         * Additionally, it only hides words that are currently visible, making the progression 
         * easier and more natural for the user to learn.
         */
        ScriptureLibrary library = new ScriptureLibrary();
        library.LoadDefaultScriptures();

        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nCongratulations on memorizing the scripture!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // Hides 3 random words at a time
        }
    }
}

// ==============================
// Reference Class
// ==============================
class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private bool _isRange;
    private bool _hasChapter;

    // Constructor for a single verse without a chapter
    public Reference(string book, int verse)
    {
        _book = book;
        _chapter = 0;
        _startVerse = verse;
        _endVerse = verse;
        _isRange = false;
        _hasChapter = false;
    }

    // Constructor for a single verse with a chapter
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
        _isRange = false;
        _hasChapter = true;
    }

    // Constructor for a range of verses within a chapter
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _isRange = true;
        _hasChapter = true;
    }

    public string GetDisplayText()
    {
        if (_isRange)
        {
            if (_hasChapter)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
            return $"{_book} {_startVerse}-{_endVerse}";
        }

        if (_hasChapter)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        return $"{_book} {_startVerse}";
    }
}

// ==============================
// Word Class
// ==============================
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}

// ==============================
// Scripture Class
// ==============================
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into individual words
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = new List<Word>();

        // Find all words that are not already hidden
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // If there are fewer visible words than the requested count, hide all of them
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex); // Remove to prevent hiding the same word again in this step
        }
    }

    public void Display()
    {
        Console.Write($"{_reference.GetDisplayText()} - ");
        foreach (Word word in _words)
        {
            Console.Write($"{word.GetDisplayText()} ");
        }
        Console.WriteLine();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

// ==============================
// Scripture Library Class
// ==============================
class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
    }

    public void LoadDefaultScriptures()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        ));

        _scriptures.Add(new Scripture(
            new 
            Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all this through him who gives me strength."
        ));
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}