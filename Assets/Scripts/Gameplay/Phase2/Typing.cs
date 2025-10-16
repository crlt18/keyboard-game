using UnityEngine;
using TMPro;
public class Typing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerText;
    private string typedText = "";

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

    }
}
