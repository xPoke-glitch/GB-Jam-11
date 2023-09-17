using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMesh;
    [SerializeField]
    private Timer _timer;

    private void Start()
    {
        _timer.StartTimer();
    }

    private void Update()
    {
        _textMesh.text = _timer.FormattedValue;
    }
}
