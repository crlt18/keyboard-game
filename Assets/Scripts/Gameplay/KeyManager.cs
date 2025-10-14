using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour
{
    public float flashDuration = 0.2f;

    void Update()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))  //for each key that exists
        {
            if (Input.GetKeyDown(key))
            {
                GameObject keyObj = GameObject.FindWithTag(key.ToString()); //find the in game key which has the corresponding tag to the key that was pressed
                if (keyObj != null)
                {
                    keyObj.GetComponent<SpriteRenderer>().color = Color.red;

                    StartCoroutine(ResetColor(keyObj));
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
