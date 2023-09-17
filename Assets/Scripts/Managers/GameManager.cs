using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public static event Action<bool> OnGameOver;

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
