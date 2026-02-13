using UnityEngine;
using TMPro;
using System.Linq;

public class ResultsPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordsList;
    [SerializeField] private TextMeshProUGUI baseScoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private float multiplier;   //the longer the word is, the higher the multiplier 
    private float score;
    private void Awake()
    {
        foreach (var word in GameManager.Instance.levelWords)
        {
            multiplier = 10 + (word.Length); //gives a larger multipler for longer words
            score += ((word.Length) * multiplier);
        }
        wordsList.text = string.Join("\n", GameManager.Instance.levelWords.Select(w => $"{w} ({w.Length * 10})"));   //displays the list of words typed with the number of characters in each word
        GameManager.Instance.levelWords.Clear();
        baseScoreText.text = "Score: " + score.ToString() + "\n Multiplier: " + GameManager.Instance.availableKeys.Count;
        score *= GameManager.Instance.availableKeys.Count;  //score multiplier = number of keys that were not destroyed
        finalScoreText.text = "Final Score: " + score.ToString();
    }
}
