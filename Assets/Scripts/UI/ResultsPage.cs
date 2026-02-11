using UnityEngine;
using TMPro;
using System.Linq;

public class ResultsPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordsList;
    private void Awake()
    {
        wordsList.text = string.Join("\n", GameManager.Instance.levelWords.Select(w => $"{w} ({w.Length})"));   //displays the list of words typed with the number of characters in each word
        GameManager.Instance.levelWords.Clear();
    }
}
