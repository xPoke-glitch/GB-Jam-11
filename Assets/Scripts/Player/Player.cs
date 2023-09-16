using UnityEngine;

public class Player : Actor
{
    public override void Die()
    {
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
}