using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Bombs : MonoBehaviour
{
    public List<GameObject> keyboard = new List<GameObject>();
    private float timer;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float bombLife;
    [SerializeField] private KeyManager keyManager;

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
        GameObject target = Instantiate(targetPrefab, spawnPos, Quaternion.identity);   //spawn a bomb on the chosen key
        keyManager.ClearPressedKeys();

        float elapsed = 0f;

        while (elapsed < bombLife)
        {
            if (keyManager.pressedKeys.Contains(targetKey.tag))
            {
                Destroy(target);

                yield break;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(target);
        GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
        keyboard.Remove(targetKey);
        KeyCode keyToRemove = (KeyCode)System.Enum.Parse(typeof(KeyCode), targetKey.tag);
        keyManager.destroyedKeys.Add(keyToRemove);
    }

}
