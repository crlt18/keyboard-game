using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HashSet<KeyCode> availableKeys = new HashSet<KeyCode>();
    public static GameManager Instance { get; private set; }
    [SerializeField] private Dictionary dictionary;
    [HideInInspector] public int level = 1;
    [HideInInspector] public int score;
    [HideInInspector] public float spawnInterval;
    [HideInInspector] public float bombLife;
    [HideInInspector] public float levelDuration;
    [HideInInspector] public GameMode gameMode;
    [HideInInspector] public HashSet<string> levelWords = new HashSet<string>();
    [SerializeField] private List<WordListSO> levelWordLists;
    public enum GameMode
    {
        Arcade,
        Story,
        Endless,
        Thematic
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        availableKeys.Clear();
        for (int i = 0; i < 26; i++)
        {
            availableKeys.Add(KeyCode.A + i);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ApplyDifficultySettings()
    {
        switch (gameMode)
        {
            case GameMode.Arcade:
                ArcadeModeSettings();
                break;

            case GameMode.Story:
                StoryModeSettings();
                break;

        }
    }

    private void ArcadeModeSettings()
    {
        switch (level)
        {
            case 1: // easy
                spawnInterval = 2.0f;
                bombLife = 1.95f;
                levelDuration = 5f;
                break;
            case 2: // normal
                spawnInterval = 0.75f;
                bombLife = 0.7f;
                levelDuration = 30f;
                break;
        }
    }
    private void StoryModeSettings()
    {
        Dictionary.Instance.SetActiveWords(levelWordLists[0]);

        switch (level)
        {
            case 1: // easy
                spawnInterval = 2.0f;
                bombLife = 1.95f;
                levelDuration = 5f;
                break;
            case 2: // normal
                spawnInterval = 0.5f;
                bombLife = 0.7f;
                levelDuration = 30f;
                break;
        }
    }


}
