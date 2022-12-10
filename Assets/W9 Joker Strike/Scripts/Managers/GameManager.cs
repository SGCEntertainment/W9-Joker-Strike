using UnityEngine;
using System;

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

    }

    public void GameOver()
    {
        
    }
}