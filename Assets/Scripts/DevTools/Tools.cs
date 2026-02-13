using UnityEngine;
using UnityEngine.SceneManagement;

public class Tools : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Game")
            {
                GameManager.Instance.levelDuration = 0;
            }
            else if (currentScene == "Typing Phase")
            {
                GameManager.Instance.typingDuration = 0;
            }
            
        }
    }
}
