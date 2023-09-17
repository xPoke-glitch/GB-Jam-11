using UnityEngine;

public class BulletEnemyPool : Singleton<BulletEnemyPool>
{
    public ref ObjectPool<Bullet> BulletPool => ref _bulletPool;

    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private Transform _bulletParent;

    private ObjectPool<Bullet> _bulletPool;

    protected override void Awake()
    {
        base.Awake();
        _bulletPool = new ObjectPool<Bullet>(BulletFactory, TurnOnBullet, TurnOffBullet, 10, true);
    }

    private Bullet BulletFactory()
    {
        GameObject bulletGo = Instantiate(_bullet.gameObject, _bulletParent);
        bulletGo.tag = "EnemyBullet";
        return bulletGo.GetComponent<Bullet>();
    }

    private void TurnOnBullet(Bullet bullet) => bullet.gameObject.SetActive(true);

    private void TurnOffBullet(Bullet bullet) => bullet.gameObject.SetActive(false);
}
