using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour
{
    public float flashDuration = 0.2f;
    public KeyCode[] playableKeys;

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

    private IEnumerator ResetColor(GameObject keyObject)
    {
        yield return new WaitForSeconds(flashDuration);
        keyObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
