using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public static event Action<bool> OnGameOver;

    [SerializeField]
    private Player player;
    [SerializeField]
    private Timer timer;

    public void StartGame()
    {
        ShrinkManager.Instance.StartManager();
        EnemySpawnManager.Instance.StartManager();
        player.gameObject.SetActive(true);
        timer.StartTimer();
    }

    private void Start()
    {
        StartGame();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        bool isWin = false;
        if(PeopleManager.Instance.PeopleRescued >= PeopleManager.Instance.PeopleCount)
        {
            isWin = true;
        }
        OnGameOver?.Invoke(isWin);
    }
}
