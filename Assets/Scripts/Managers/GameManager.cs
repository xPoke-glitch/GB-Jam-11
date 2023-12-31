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
    [SerializeField] 
    private AudioClip _backgroudMusic;

    public void StartGame()
    {
        ShrinkManager.Instance.StartManager();
        EnemySpawnManager.Instance.StartManager();
        player.gameObject.SetActive(true);
        timer.StartTimer();
        AudioManager.Instance.PlayGameBackgroundMusic(_backgroudMusic, true);
    }

    private void Start()
    {
        StartGame();
    }

    public void GameOver(bool isPlayerDead = false)
    {
        Debug.Log("Game Over");
        bool isWin = PeopleManager.Instance.PeopleRescued >= PeopleManager.Instance.PeopleCount && !isPlayerDead;
        OnGameOver?.Invoke(isWin);
    }
}
