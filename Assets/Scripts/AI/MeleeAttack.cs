using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AIData _aiData;

    [Header("Sound Settings")]
    [SerializeField]
    private AudioClip _hitAudio;
    
    private bool _canDealDamage = false;
    
    public void Attack()
    {
        if (_aiData.currentTarget == null || !_canDealDamage)
            return;

        Player p = _aiData.currentTarget.GetComponent<Player>();
        AudioManager.Instance.PlayAudioEffect(_hitAudio);
        p.TakeDamage(1);
        _canDealDamage = false;
        Debug.Log("Melee");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
            return;
        
        if (!_canDealDamage)
            _canDealDamage = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
            return;
        
        if (_canDealDamage)
            _canDealDamage = false;
    }
}
