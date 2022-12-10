using UnityEngine;
using System;
using System.Collections;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject Player { get; set; }
    private GameObject[] Fruits { get; set; }
    private Transform EnvironmentRef { get; set; }

    private int completeCount;
    private int totalCompleteCount;

    public static Action<bool> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Player = Resources.Load<GameObject>("player");
        Fruits = Resources.LoadAll<GameObject>("fruits");

        EnvironmentRef = GameObject.Find("Environment").transform;

        Fruit.OnCollided += () =>
        {
            if(++completeCount >= totalCompleteCount)
            {
                GameOver(true);
            }
        };
    }

    public void RestartGame()
    {
        totalCompleteCount = Random.Range(10, 25);

        Instantiate(Player, EnvironmentRef);
        StartCoroutine(nameof(Spawning));
    }

    public void GameOver(bool IsWin)
    {
        Fruit[] fruit = FindObjectsOfType<Fruit>();
        foreach(Fruit f in fruit)
        {
            Destroy(f.gameObject);
        }

        Sliced[] sliced = FindObjectsOfType<Sliced>();
        foreach (Sliced s in sliced)
        {
            Destroy(s.gameObject);
        }

        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
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