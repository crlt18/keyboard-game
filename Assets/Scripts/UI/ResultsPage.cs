using UnityEngine;

public class ResultsPage : MonoBehaviour
{
    private void Awake()
    {
        foreach (var i in GameManager.Instance.levelWords)
        {
            Debug.Log(i);
        }
        GameManager.Instance.levelWords.Clear();
    }
}
