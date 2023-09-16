using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float _timer = 2f;

    private void Awake()
    {
        Destroy(gameObject, _timer);
    }
}
