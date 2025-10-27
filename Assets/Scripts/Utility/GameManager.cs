using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HashSet<KeyCode> availableKeys = new HashSet<KeyCode>();
    public static GameManager Instance { get; private set; }

    [HideInInspector] public int gameMode = 1;
    [HideInInspector] public int level = 1;
    [HideInInspector] public int score;
    [HideInInspector] public float spawnInterval;
    [HideInInspector] public float bombLife;
    [HideInInspector] public float levelDuration;

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

}
