using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private AIData aiData;

    public void Attack()
    {
        Debug.Log("Ranged");
        if (aiData.currentTarget == null)
            return;
        BulletEnemyPool.Instance.BulletPool.GetObject().Shoot(transform.position, (aiData.currentTarget.position- this.transform.position).normalized, _bulletSpeed, 
            BulletEnemyPool.Instance.BulletPool);
    }
}
