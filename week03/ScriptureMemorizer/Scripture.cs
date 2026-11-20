using System;
using System.Text;

public class Word
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

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Replace letters with underscores while keeping punctuation visible
        StringBuilder maskedWord = new StringBuilder();
        foreach (char character in _text)
        {
            if (char.IsLetter(character))
            {
                maskedWord.Append('_');
            }
            else
            {
                maskedWord.Append(character);
            }
        }

        return maskedWord.ToString();
    }
}

