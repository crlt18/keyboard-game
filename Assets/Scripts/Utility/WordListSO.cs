using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordListSO", menuName = "Scriptable Objects/WordListSO")]
public class WordListSO : ScriptableObject
{
    public List<string> words = new List<string>();
}
