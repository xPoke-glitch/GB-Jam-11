using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Vector3Int LastPlayerDirection => _lastDirection;

    [Header("Settings")]
    [SerializeField]
    private float _moveTime = 0.1f;
    [SerializeField]
    private float _rayDistance = 1f;

    private bool _canMove = true;
    private Vector3Int _lastDirection = Vector3Int.up;

    private void Update()
    {
        if (!_canMove)
            return;

        Vector3Int movement = Vector3Int.RoundToInt(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        Debug.DrawRay(transform.position, transform.TransformDirection(movement) * _rayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(movement), _rayDistance);

        if (movement == Vector3.zero || hit)
            return;

        _lastDirection = movement;

        _canMove = false;
        LeanTween.move(this.gameObject, this.gameObject.transform.position + movement, _moveTime).setOnComplete(() => { _canMove = true; });
    }
}
