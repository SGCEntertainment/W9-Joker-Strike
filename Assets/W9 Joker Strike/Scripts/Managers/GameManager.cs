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

    public static Action<bool> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Player = Resources.Load<GameObject>("player");
        Fruits = Resources.LoadAll<GameObject>("fruits");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    public void RestartGame()
    {
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

        GameObject[] sliced = GameObject.FindGameObjectsWithTag("sliced");
        foreach (GameObject s in sliced)
        {
            Destroy(s);
        }

        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>());
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