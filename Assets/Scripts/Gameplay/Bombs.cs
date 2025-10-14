using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public List<GameObject> keyboard = new List<GameObject>();
    private float timer;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float spawnInterval;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            Gameplay();
            timer = 0;
        }
    }
    private void Gameplay()
    {
        GameObject targetKey = keyboard[Random.Range(0, keyboard.Count)];
        Vector3 spawnPos = targetKey.transform.position;
        GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }
}
