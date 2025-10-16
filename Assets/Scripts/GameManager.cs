using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HashSet<KeyCode> AvailableKeys = new HashSet<KeyCode>();
    public HashSet<KeyCode> availableKeys { get; set; } = new HashSet<KeyCode>();
    public static GameManager Instance { get; private set; }

    public float level;

    private void Awake()
    {
        level = 1;
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

}
