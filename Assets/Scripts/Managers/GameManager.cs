using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public static event Action<bool> OnGameOver;

    public void GameOver(bool isWin = false)
    {
        OnGameOver?.Invoke(isWin);
    }
}
