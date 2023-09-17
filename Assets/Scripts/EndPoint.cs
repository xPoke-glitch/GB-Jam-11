using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private bool _canEnter = false;

    private void Update()
    {
        if (!_canEnter)
            return;

        if (Input.GetKeyDown(KeyCode.L) || Input.GetKey("joystick button 0"))
        {
            GameManager.Instance.GameOver();
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _canEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _canEnter = false;
    }
}
