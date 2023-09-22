using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private AIData aiData;

    [Header("Sound Settings")]
    [SerializeField]
    private List<AudioClip> _shotAudio;
    
    public void Attack()
    {
        Debug.Log("Ranged");
        if (aiData.currentTarget == null)
            return;
        
        BulletEnemyPool.Instance.BulletPool.GetObject().Shoot(transform.position, (aiData.currentTarget.position- this.transform.position).normalized, _bulletSpeed, 
            BulletEnemyPool.Instance.BulletPool);
        AudioManager.Instance.PlayAudioEffect(_shotAudio[Random.Range(0, _shotAudio.Count)]);
    }
}
