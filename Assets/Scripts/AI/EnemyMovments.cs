using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovments : MonoBehaviour
{
    [Header("Movements Settings")]
    [SerializeField]
    private float _moveTime = 0.1f;

    private bool _isMoving = false;

    public void Move(Vector2 direction)
    {
        if (_isMoving) return;
        _isMoving = true;

        LeanTween.move(this.gameObject, this.gameObject.transform.position + new Vector3(direction.x,direction.y,transform.position.z), _moveTime).setOnComplete(() => { _isMoving = false; });
    }
}
