using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

public class KeyManager : MonoBehaviour
{
    public float flashDuration = 0.2f;
    public HashSet<string> pressedKeys = new HashSet<string> ();

    void Update()
    {
        foreach (KeyCode key in GameManager.Instance.availableKeys)  //for each key that exists
        {
            if (Input.GetKeyDown(key))
            {
                if (GameManager.Instance.availableKeys.Contains(key))
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
