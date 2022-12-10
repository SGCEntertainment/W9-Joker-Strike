using UnityEngine;
using System;
using System.Collections;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject[] Fruits { get; set; }
    private Transform EnvironmentRef { get; set; }

    public static Action<bool> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Fruits = Resources.LoadAll<GameObject>("fruits");
        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    public void RestartGame()
    {
        StartCoroutine(nameof(Spawning));
    }

    public void GameOver(bool IsWin)
    {
        Fruit[] fruit = FindObjectsOfType<Fruit>();
        foreach(Fruit f in fruit)
        {
            Destroy(f.gameObject);
        }

        OnGameFinsihed?.Invoke(IsWin);
        StopCoroutine(nameof(Spawning));
    }

    IEnumerator Spawning()
    {
        while(true)
        {
            Instantiate(Fruits[Random.Range(0, Fruits.Length)], EnvironmentRef);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.75f));
        }
    }
}