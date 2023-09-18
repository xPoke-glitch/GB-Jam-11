using UnityEngine;
using System;

public class Player : Actor
{
    public static event Action<int> OnHealthInit;
    public static event Action<int> OnDamageTaken;

    [SerializeField]
    private SpriteRenderer _playerSprite;


    private bool _canTakeDamage = true;

    public override void Die()
    {
        GameManager.Instance.GameOver(true);
        Destroy(gameObject);
    }

    private void Start()
    {
        _canTakeDamage = true;
        OnHealthInit.Invoke(Health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            // Hardcoded 1 damage
            TakeDamage(1);
        }
    }

    public override void TakeDamage(int amount)
    {
        
        if (!_canTakeDamage)
            return;

        // Player simple blink
        _canTakeDamage = false;
        LeanTween.value(gameObject, setSpriteAlpha, 0f, 1f, 0.30f).setOnComplete(() =>
        {
            _canTakeDamage = true;
        }).setRepeat(5).setLoopPingPong();

        base.TakeDamage(amount);

        UpdateHealth();
    }

    private void setSpriteAlpha(float val)
    {
        _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, val);
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
