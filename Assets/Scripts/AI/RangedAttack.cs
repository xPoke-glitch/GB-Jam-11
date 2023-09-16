using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private Transform _bulletParent;
    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private AIData aiData;

    private ObjectPool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(BulletFactory, TurnOnBullet, TurnOffBullet, 10, true);
    }
    public void Attack()
    {
        Debug.Log("Ranged");
        if (aiData.currentTarget == null)
            return;
        bulletPool.GetObject().Shoot(transform.position, (aiData.currentTarget.position- this.transform.position).normalized, _bulletSpeed, bulletPool);
    }
    private Bullet BulletFactory()
    {
        GameObject bulletGo = Instantiate(_bullet.gameObject, _bulletParent);
        return bulletGo.GetComponent<Bullet>();
    }

    private void TurnOnBullet(Bullet bullet) => bullet.gameObject.SetActive(true);

    private void TurnOffBullet(Bullet bullet) => bullet.gameObject.SetActive(false);
}
