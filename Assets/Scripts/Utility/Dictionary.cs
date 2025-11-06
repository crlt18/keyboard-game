using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public static Dictionary Instance { get; private set; }

    public HashSet<string> wordDictionary;
    public HashSet<string> activeWordList;  //the list of words that are valid in each level of story mode and thematic mode
    public HashSet<string> blacklist;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        wordDictionary = new HashSet<string>();
        blacklist = new HashSet<string>();
        LoadWords();
    }
    public void SetActiveWords(WordListSO wordList)
    {
        activeWordList = new HashSet<string>();
        foreach (string word in wordList.words)
        {
            activeWordList.Add(word.ToLower());
        }
    }

    private void LoadWords()
    {
        TextAsset blacklistFile = Resources.Load<TextAsset>("Blacklist");
        if (blacklistFile == null)
        {
            Debug.LogError("Blacklist.txt not found");
            return;
        }

        string[] blacklistWords = blacklistFile.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in blacklistWords)
        {
            string lower = word.ToLower();
            blacklist.Add(lower);
        }

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
            if (lower.Length >= 5 && !blacklist.Contains(lower)) //only words 3+ letters
            {
                wordDictionary.Add(lower);
            }
        }

        Debug.Log("Loaded " + wordDictionary.Count + " words");
    }

    public bool IsValidWord(string word)
    {
        string lower = word.ToLower();

        if (GameManager.Instance.gameMode == 1)
        {
            return wordDictionary.Contains(lower);
        }

        if (GameManager.Instance.gameMode == 2)
        {
            return activeWordList.Contains(lower);
        }

        return false;
    }
}
