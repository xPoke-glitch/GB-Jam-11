using UnityEngine;
using System;

public class Player : Actor
{
    public static event Action<int> OnHealthInit;
    public static event Action<int> OnDamageTaken;

    public override void Die()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    private void Start()
    {
        OnHealthInit.Invoke(Health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            // Hardcoded 1 damage
            TakeDamage(1);
            UpdateHealth();
        }
    }

    public void UpdateHealth()
    {
        OnDamageTaken.Invoke(Health);
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver(bool isWin)
    {
        Destroy(gameObject);
    }
}
