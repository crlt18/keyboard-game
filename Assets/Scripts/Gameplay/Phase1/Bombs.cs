using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bombs : MonoBehaviour
{
    public List<GameObject> keyboard = new List<GameObject>();
    private float timer;
    private float levelTimer;
    private float minimumSpawnInterval = 0.2f;
    private float spawnIncrease = 1.2f;
    private float nextSpeedUpTime; //for endless mode, increase of bomb spawn speed

    [SerializeField] private float speedUpInterval = 10f;
    [SerializeField] private KeyManager keyManager;
    [SerializeField] private ObjectPooling targetPool;
    [SerializeField] private ObjectPooling bombPool;

    void Start()
    {
        nextSpeedUpTime = speedUpInterval;
    }

    private void Update()
    {
        levelTimer += Time.deltaTime;

        if (GameManager.Instance.gameMode == GameManager.GameMode.Endless)
        {
            if (levelTimer >= nextSpeedUpTime)
            {
                if (minimumSpawnInterval < GameManager.Instance.spawnInterval)
                {
                    GameManager.Instance.spawnInterval /= spawnIncrease;
                    nextSpeedUpTime += speedUpInterval;
                }
            }
        }

        if (GameManager.Instance.levelDuration < 0 || GameManager.Instance.levelDuration > levelTimer)  //allows endless mode to run infinitely
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
        if (keyboard.Count == 0) yield break;

        
        GameObject targetKey = keyboard[Random.Range(0, keyboard.Count)];   //choose a random key
        Vector3 spawnPos = targetKey.transform.position;

        
        GameObject target = targetPool.Get();   //get target from pool
        target.transform.position = spawnPos;

        keyManager.ClearPressedKeys();

        float elapsed = 0f;

        while (elapsed < GameManager.Instance.bombLife)
        {
            
            if (keyManager.pressedKeys.Contains(targetKey.tag)) //if key is pressed, return target to pool
            {
                targetPool.Return(target);
                yield break;
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        targetPool.Return(target);

        GameObject bomb = bombPool.Get();
        bomb.transform.position = spawnPos;
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
