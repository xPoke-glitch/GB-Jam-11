using UnityEngine;

public class Enemy : Actor
{
    public override void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // Hardcoded 1 damage
            TakeDamage(1);
        }
    }
}
