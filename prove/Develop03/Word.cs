using System;

class Word
{
    // Private fields
    private string _word;
    private bool _wordHidden;

    // Constructor initializes the word and sets it as visible
    public Word(string word)
    {
        _word = word;
        _wordHidden = false;
    }

    // Hides the word
    public void Hide()
    {
        _wordHidden = true;
    }

    // Shows the word again
    public void Show()
    {
        _wordHidden = false;
    }

    // Returns true if the word is hidden
    public bool IsHidden()
    {
        return _wordHidden;
    }

    // Returns either the word or underscores if hidden
    public string GetDisplayWord()
    {
        if (_wordHidden)
        {
            return new string('_', _word.Length);
        }
        else
        {
            return _word;
        }
    }
}