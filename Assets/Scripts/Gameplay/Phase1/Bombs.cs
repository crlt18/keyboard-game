using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditorInternal;
using UnityEngine.SceneManagement;

public class Bombs : MonoBehaviour
{
    public List<GameObject> keyboard = new List<GameObject>();
    private float timer;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private KeyManager keyManager;
    private float levelTimer;

    private void Update()
    {
        levelTimer += Time.deltaTime;

        if (GameManager.Instance.levelDuration > levelTimer)
        {
            if (keyboard.Count < 1)
            {
                GameOver();
                return;
            }

            timer += Time.deltaTime;

            if (timer > GameManager.Instance.spawnInterval)
            {
                StartCoroutine(SpawnBombs());
                timer = 0;
            }
        }
        else
        {
            LevelComplete();
        }
    }
    private IEnumerator SpawnBombs()
    {
        GameObject targetKey = keyboard[Random.Range(0, keyboard.Count)];   //choose a random key
        Vector3 spawnPos = targetKey.transform.position;
        GameObject target = Instantiate(targetPrefab, spawnPos, Quaternion.identity);   //spawn a bomb on the chosen key
        keyManager.ClearPressedKeys();

        float elapsed = 0f;

        while (elapsed < GameManager.Instance.bombLife)
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
        GameManager.Instance.availableKeys.Remove(keyToRemove);
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene("Typing Phase");
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }

}
