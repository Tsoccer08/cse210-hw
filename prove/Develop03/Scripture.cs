using System;
using System.Collections.Generic;

class Scripture
{
    // Private fields
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    // Constructor initializes scripture with reference and word list
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    // Returns full scripture display
    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            text += word.GetDisplayWord() + " ";
        }

        return text.TrimEnd();
    }

    // Hides a specified number of random visible words
    public void HideRandomWords(int count)
    {
        // Get list of words that are not already hidden
        List<Word> visibleWords = GetVisibleWords();

        // If no visible words remain, exit
        if (visibleWords.Count == 0)
            return;

        // Adjust count if fewer visible words exist
        if (count > visibleWords.Count)
            count = visibleWords.Count;

        // Hide random visible words
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Helper method that returns only visible words
    private List<Word> GetVisibleWords()
    {
        List<Word> visible = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visible.Add(word);
            }
        }

        return visible;
    }

    // Returns true if any words are still visible
    public bool HasVisibleWords()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return true;
            }
        }

        return false;
    }

    // Returns true if all words are hidden
    public bool IsCompletelyHidden()
    {
        return !HasVisibleWords();
    }
}