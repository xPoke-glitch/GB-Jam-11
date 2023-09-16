using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMovments : MonoBehaviour
{
    [Header("Movements Settings")]
    [SerializeField]
    private float _moveTime = 0.1f;
    [SerializeField]
    private LayerMask _obstaclesMask;

    private bool _isMoving = false;

    public void Move(Vector2 direction)
    {
        if (_isMoving) return;

        direction = new Vector2(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y));
        if(!CanMove(direction))
            return;
        _isMoving = true;
        LeanTween.move(this.gameObject, this.gameObject.transform.position + new Vector3(direction.x,direction.y,transform.position.z), _moveTime).setOnComplete(() => { _isMoving = false; });
    }

    public bool CanMove(Vector2 direction)
    {
        RaycastHit2D hit =
             Physics2D.Raycast(transform.position, direction, 1.1f, _obstaclesMask);
        if (hit.collider != null)
            return false;
        return true;
    }
}
