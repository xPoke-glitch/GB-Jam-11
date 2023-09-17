using UnityEngine;

public class Player : Actor
{
    public override void Die()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            // Hardcoded 1 damage
            TakeDamage(1);
        }
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
