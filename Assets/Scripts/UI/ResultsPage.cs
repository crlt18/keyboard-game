using UnityEngine;
using TMPro;
using System.Linq;

public class ResultsPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordsList;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    private void Awake()
    {
        foreach (var word in GameManager.Instance.levelWords)
        {
            score += (word.Length) * 10;
        }
        wordsList.text = string.Join("\n", GameManager.Instance.levelWords.Select(w => $"{w} ({w.Length * 10})"));   //displays the list of words typed with the number of characters in each word
        GameManager.Instance.levelWords.Clear();
        scoreText.text = "Final Score: " + score.ToString();
    }
}
