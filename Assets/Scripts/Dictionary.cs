using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public HashSet<string> wordDictionary;

    void Awake()
    {
        wordDictionary = new HashSet<string>();
        LoadWords();
    }

    private void LoadWords()
    {
        TextAsset wordFile = Resources.Load<TextAsset>("Words");
        if (wordFile == null )
        {
            Debug.LogError("Words.txt not found");
            return;
        }

        string[] words = wordFile.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            string lower = word.ToLower().Trim();
            if (lower.Length >= 5) //only words 3+ letters
            {
                wordDictionary.Add(lower);
            }
        }

        Debug.Log("Loaded " + wordDictionary.Count + " words");
    }
    public bool IsValidWord(string word)
    {
        return wordDictionary.Contains(word.ToLower());
    }
}
