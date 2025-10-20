using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
public class Typing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Dictionary dictionary;
    public List<GameObject> keyboard = new List<GameObject>();
    private string typedText = "";

    private void Start()
    {
        foreach (GameObject keyObj in keyboard)
        {
            KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyObj.tag);

            if (!GameManager.Instance.availableKeys.Contains(key))
            {
                Vector3 spawnPos = keyObj.transform.position;
                Instantiate(bombPrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        foreach (char c in Input.inputString)   //loop through all keys pressed
        {
            if (char.IsLetter(c))
            {
                KeyCode key = KeyCode.A + (char.ToUpper(c) - 'A');

                
                if (GameManager.Instance.availableKeys.Contains(key))   //only accept keys that are available
                {
                    typedText += char.ToUpper(c);
                }
            }

            
            if (c == '\b' && typedText.Length > 0)  //handle backspace
            {
                typedText = typedText.Substring(0, typedText.Length - 1);
            }
        }

        playerText.text = typedText;

        if(dictionary.IsValidWord(typedText))
        {
            GameManager.Instance.score++;
            Debug.Log(GameManager.Instance.score);
            typedText = "";
        }
 

    }
}
