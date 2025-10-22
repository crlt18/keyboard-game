using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Easy()
    {
        GameManager.Instance.level = 1;
        GameManager.Instance.ApplyDifficultySettings();
        SceneManager.LoadScene("Game");
    }

    public void Normal()
    {
        GameManager.Instance.level = 2;
        GameManager.Instance.ApplyDifficultySettings();
        SceneManager.LoadScene("Game");
    }


}
