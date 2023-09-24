using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Vector3Int LastPlayerDirection => _lastDirection;

    [Header("References")]
    [SerializeField]
    private Animator _playerAnimator = null; 
    
    
    [Header("Settings")]
    [SerializeField]
    private LayerMask _movementMask;
    [SerializeField]
    private float _moveTime = 0.1f;
    [SerializeField]
    private float _rayDistance = 1f;

    private bool _canMove = true;
    private Vector3Int _lastDirection = Vector3Int.up;
    
    private static readonly int X = Animator.StringToHash("X");
    private static readonly int Y = Animator.StringToHash("Y");


    private void Update()
    {
        if (!_canMove)
            return;

        Vector3Int movement = Vector3Int.RoundToInt(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        Debug.DrawRay(transform.position, transform.TransformDirection(movement) * _rayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(movement), _rayDistance,_movementMask);

        
        
        if (movement == Vector3.zero || hit)
        {
            _playerAnimator.SetTrigger("Idle");
            return;
        }

        _playerAnimator.SetTrigger("Run");
        _playerAnimator.SetFloat(X, movement.x);
        _playerAnimator.SetFloat(Y, movement.y);

        _lastDirection = movement;

        _canMove = false;
        LeanTween.move(this.gameObject, this.gameObject.transform.position + movement, _moveTime).setOnComplete(() => { _canMove = true; });
    }
}
