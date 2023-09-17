using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AIData _aiData;

    public void Attack()
    {
        if (_aiData.currentTarget == null)
            return;

        Player p = _aiData.currentTarget.GetComponent<Player>();
        p.TakeDamage(1);
        Debug.Log("Melee");
    }
}
