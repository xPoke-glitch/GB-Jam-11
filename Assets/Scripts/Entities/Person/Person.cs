using UnityEngine;

public class Person : MonoBehaviour
{
    private bool _rescueable = false;

    private void Update()
    {
        if (!_rescueable)
            return;

        if(Input.GetKeyDown(KeyCode.L) || Input.GetKey("joystick button 0"))
        {
            PeopleManager.Instance.RescuePerson();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            _rescueable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _rescueable = false;
    }
}
