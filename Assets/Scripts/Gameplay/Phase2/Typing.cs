using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class Typing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private GameObject bombPrefab;
    private HashSet<string> typedWords = new HashSet<string>();
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

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Dictionary.Instance.IsValidWord(typedText) && !typedWords.Contains(typedText))
            {
                GameManager.Instance.score++;
                Debug.Log(GameManager.Instance.score);
                typedWords.Add(typedText);
            }

            typedText = "";
        }


    }
}
