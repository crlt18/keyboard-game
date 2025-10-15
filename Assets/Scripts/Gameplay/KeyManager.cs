using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

public class KeyManager : MonoBehaviour
{
    public float flashDuration = 0.2f;
    public KeyCode[] playableKeys;
    public KeyCode lastKeyPressed;
    public HashSet<string> pressedKeys = new HashSet<string> ();
    void Awake()
    {
        playableKeys = new KeyCode[26];
        for (int i = 0; i < 26; i++)
        {
            playableKeys[i] = KeyCode.A + i;
        }
    }

    void Update()
    {
        foreach (KeyCode key in playableKeys)  //for each key that exists
        {
            if (Input.GetKeyDown(key))
            {
                string tag = key.ToString();
                pressedKeys.Add(tag);

                GameObject keyObj = GameObject.FindWithTag(key.ToString()); //find the in game key which has the corresponding tag to the key that was pressed
                if (keyObj != null)
                {
                    keyObj.GetComponent<SpriteRenderer>().color = Color.red;
                    StartCoroutine(ResetColor(keyObj));
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void ClearPressedKeys()
    {
        pressedKeys.Clear();
    }

    private IEnumerator ResetColor(GameObject keyObject)
    {
        yield return new WaitForSeconds(flashDuration);
        keyObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
