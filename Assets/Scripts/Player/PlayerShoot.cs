using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private PlayerMovements _playerMovements;
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private Transform _bulletParent;

    [Header("Settings")]
    [SerializeField]
    private float _shootCooldown;
    [SerializeField]
    private float _bulletSpeed;

    [Header("Sound Settings")]
    [SerializeField]
    private List<AudioClip> _shotAudio;
    
    private bool _canShoot = true;
    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        _canShoot = true;
    }

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(BulletFactory, TurnOnBullet, TurnOffBullet, 10, true);
    }

    private void Update()
    {
        if (!_canShoot)
            return;

        if(Input.GetKey(KeyCode.K) || Input.GetKey("joystick button 1"))
        {
            _canShoot = false;

            bulletPool.GetObject().Shoot(transform.position, _playerMovements.LastPlayerDirection, _bulletSpeed, bulletPool);
            AudioManager.Instance.PlayAudioEffect(_shotAudio[Random.Range(0, _shotAudio.Count)]);
            
            StartCoroutine(COShootTimer());
        }
    }

    private Bullet BulletFactory()
    {
        GameObject bulletGo = Instantiate(_bullet.gameObject, _bulletParent);
        bulletGo.tag = "PlayerBullet";
        return bulletGo.GetComponent<Bullet>();
    }

    private void TurnOnBullet(Bullet bullet) => bullet.gameObject.SetActive(true);

    private void TurnOffBullet(Bullet bullet) => bullet.gameObject.SetActive(false);

    private IEnumerator COShootTimer()
    {
        yield return new WaitForSeconds(_shootCooldown);

        _canShoot = true;
    }
}
