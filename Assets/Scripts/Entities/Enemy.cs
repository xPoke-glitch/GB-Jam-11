using UnityEngine;

public class Enemy : Actor
{
    private ObjectPool<Enemy> _pool;
    
    [SerializeField] 
    private AudioClip _damageAudio;
    [SerializeField] 
    private AudioClip _deathAudio;
    
    public void SetupEnemy(Vector3 position, Quaternion rotation, ObjectPool<Enemy> ownPool)
    {
        _pool = ownPool;
        transform.position = position;
        transform.rotation = rotation;
    }

    public override void Die()
    {
        _pool.ReturnObject(this);
        AudioManager.Instance.PlayAudioEffect(_deathAudio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // Hardcoded 1 damage
            TakeDamage(1);
            AudioManager.Instance.PlayAudioEffect(_damageAudio);
        }
    }
}
