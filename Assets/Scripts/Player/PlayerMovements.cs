using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private LayerMask _movementMask;
    [SerializeField]
    private float _moveTime = 0.1f;
    [SerializeField]
    private float _rayDistance = 1f;

    private bool _canMove = true;

    private void Update()
    {
        if (!_canMove)
            return;

        Vector3Int movement = Vector3Int.RoundToInt(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        Debug.DrawRay(transform.position, transform.TransformDirection(movement) * _rayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(movement), _rayDistance,_movementMask);

        if (movement == Vector3.zero || hit)
            return;

        _canMove = false;
        LeanTween.move(this.gameObject, this.gameObject.transform.position + movement, _moveTime).setOnComplete(() => { _canMove = true; });
        
    }
}
