using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    /*
    [Header("References")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    **/
    [Header("Settings")]
    [SerializeField]
    private float _moveTime = 0.1f;
    [SerializeField]
    private float _rayDistance = 1f;

    private bool _canMove = true;

    private void Update()
    {
        if (!_canMove)
            return;

        // Collisions
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * _rayDistance, Color.red);
        RaycastHit2D hitUP = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), _rayDistance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * _rayDistance, Color.red);
        RaycastHit2D hitDOWN = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), _rayDistance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * _rayDistance, Color.red);
        RaycastHit2D hitLEFT = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), _rayDistance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * _rayDistance, Color.red);
        RaycastHit2D hitRIGHT = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), _rayDistance);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(1,1)) * _rayDistance, Color.red);
        RaycastHit2D hitUR = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(1,1)), _rayDistance);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(-1, 1)) * _rayDistance, Color.red);
        RaycastHit2D hitUL = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(-1, 1)), _rayDistance);

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A) && !hitUL)
            {
                _canMove = false;
                LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y + 1, _moveTime).setOnComplete(() => { _canMove = true; });
                LeanTween.moveX(this.gameObject, this.gameObject.transform.position.x - 1, _moveTime).setOnComplete(() => { _canMove = true; });
            }
            else if(!hitUP)
            {
                _canMove = false;
                LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y + 1, _moveTime).setOnComplete(() => { _canMove = true; });
            }
          
            //_animator.SetInteger("Horizontal", 0);
            //_animator.SetInteger("Vertical", 1);
        }
        else if (Input.GetKey(KeyCode.S) && !hitDOWN)
        {
            _canMove = false;
            LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y - 1, _moveTime).setOnComplete(() => { _canMove = true; });
            //_animator.SetInteger("Horizontal", 0);
           //_animator.SetInteger("Vertical", -1);
        }
        else if (Input.GetKey(KeyCode.D) && !hitRIGHT)
        {
            _canMove = false;
            LeanTween.moveX(this.gameObject, this.gameObject.transform.position.x + 1, _moveTime).setOnComplete(() => { _canMove = true; });
            //_animator.SetInteger("Horizontal", 1);
            //_animator.SetInteger("Vertical", 0);
            //_spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) && !hitLEFT)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _canMove = false;
                LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y + 1, _moveTime).setOnComplete(() => { _canMove = true; });
                LeanTween.moveX(this.gameObject, this.gameObject.transform.position.x - 1, _moveTime).setOnComplete(() => { _canMove = true; });
            }
            else
            {
                _canMove = false;
                LeanTween.moveX(this.gameObject, this.gameObject.transform.position.x - 1, _moveTime).setOnComplete(() => { _canMove = true; });
            }
         
            //_animator.SetInteger("Horizontal", -1);
            //_animator.SetInteger("Vertical", 0);
            //_spriteRenderer.flipX = true;
        }
        else
        {
            //_animator.SetInteger("Horizontal", 0);
            //_animator.SetInteger("Vertical", 0);
        }
    }
}
