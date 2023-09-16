using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float _destructionTimer = 2f; 

    private bool _canMove = false;
    private Vector3 _direction = Vector3.zero;
    private float _shootSpeed = 0f;
    private ObjectPool<Bullet> _currentPool;

    public void Shoot(Vector3 startPosition, Vector3Int direction, float shootSpeed, ObjectPool<Bullet> currentPool = null)
    {
        _currentPool = currentPool;
        _direction = direction;
        _shootSpeed = shootSpeed;
        transform.position = startPosition;
        transform.rotation = RotateTo(direction);

        _canMove = true;
        StartCoroutine(COWaitToBeDestroyed());
    }

    private void Update()
    {
        if (!_canMove)
            return;

        transform.Translate(_direction * _shootSpeed * Time.deltaTime, Space.World);
    }

    private Quaternion RotateTo(Vector3Int direction)
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        if (direction.y != 0 && direction.x != 0)
            angle *= -1;

        return Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private IEnumerator COWaitToBeDestroyed()
    {
        yield return new WaitForSeconds(_destructionTimer);

        if (_currentPool != null)
            _currentPool.ReturnObject(this);
        else
            Destroy(gameObject);
    }
}
