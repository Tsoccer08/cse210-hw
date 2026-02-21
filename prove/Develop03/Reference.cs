using System;

class Reference
{
    // Private fields
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private bool _multipleVerses;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
        _multipleVerses = false;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _multipleVerses = true;
    }

    // Returns the formatted reference as a string
    public string GetDisplayText()
    {
        if (_multipleVerses)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}