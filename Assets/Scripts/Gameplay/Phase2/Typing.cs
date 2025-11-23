using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Typing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private GameObject bombPrefab;
    public List<GameObject> keyboard = new List<GameObject>();
    private string typedText = "";
    private float timer;

    private void Start()
    {
        timer = 10.0f;
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
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("Results");
        }
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
            if (Dictionary.Instance.IsValidWord(typedText) && !GameManager.Instance.levelWords.Contains(typedText))
            {
                GameManager.Instance.score++;
                Debug.Log(GameManager.Instance.score);
                GameManager.Instance.levelWords.Add(typedText);
            }

            typedText = "";
        }


    }
}
