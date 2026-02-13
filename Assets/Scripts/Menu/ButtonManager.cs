using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button mode1;
    private Button mode2;
    private Button mode3;
    private Button easy;
    private Button normal;

    private void Awake()
    {
        mode1 = GameObject.FindGameObjectWithTag("mode1").GetComponent<Button>();
        mode2 = GameObject.FindGameObjectWithTag("mode2").GetComponent<Button>();
        mode3 = GameObject.FindGameObjectWithTag("mode3").GetComponent<Button>();
        easy = GameObject.FindGameObjectWithTag("easy").GetComponent<Button>();
        normal = GameObject.FindGameObjectWithTag("normal").GetComponent<Button>();

        mode1.gameObject.SetActive(true);
        mode2.gameObject.SetActive(true);
        mode3.gameObject.SetActive(true);
        easy.gameObject.SetActive(false);
        normal.gameObject.SetActive(false);
    }

    public void Arcade()
    {
        GameManager.Instance.gameMode = GameManager.GameMode.Arcade;
        mode1.gameObject.SetActive(false);
        mode2.gameObject.SetActive(false);
        mode3.gameObject.SetActive(false);
        easy.gameObject.SetActive(true);
        normal.gameObject.SetActive(true);
    }

    public void Story()
    { 
        GameManager.Instance.gameMode = GameManager.GameMode.Story;
        mode1.gameObject.SetActive(false);
        mode2.gameObject.SetActive(false);
        mode3.gameObject.SetActive(false);
        easy.gameObject.SetActive(true);
        normal.gameObject.SetActive(true);
    }

    public void Endless()
    {
        GameManager.Instance.gameMode = GameManager.GameMode.Endless;
        mode1.gameObject.SetActive(false);
        mode2.gameObject.SetActive(false);
        mode3.gameObject.SetActive(false);
        easy.gameObject.SetActive(true);
        normal.gameObject.SetActive(true);
    }
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
