using System.Collections.Generic;
using System.Collections;
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
            StartCoroutine(Gameplay());
            timer = 0;
        }
    }
    private IEnumerator Gameplay()
    {
        GameObject targetKey = keyboard[Random.Range(0, keyboard.Count)];   //choose a random key
        Vector3 spawnPos = targetKey.transform.position;
        GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);   //spawn a bomb on the chosen key
        yield return new WaitForSeconds(2f);
        Destroy(bomb);
    }

}
