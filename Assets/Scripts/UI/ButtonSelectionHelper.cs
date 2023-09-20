using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectionHelper : MonoBehaviour
{
    [Header("UIReferences")] 
    [SerializeField]
    private List<Button> _buttons;

    [Header("Settings")] 
    [SerializeField] 
    private bool _initOnStart = true;
    [SerializeField]
    private Color _selectedColor = Color.white;
    [SerializeField] 
    private Color _defaultColor = Color.white;

    private List<TextMeshProUGUI> _tmProList = new List<TextMeshProUGUI>();
    private Button _selectedButton;
    private int _curIndex = 0;


    public void ForceInitButtons()
    {
        _selectedButton = _buttons[_curIndex];
        foreach (var button in _buttons)
        {
            _tmProList.Add(button.GetComponentInChildren<TextMeshProUGUI>());
        }
        SetSelectedButton();
    }
    
    private void Start()
    {
        if (!_initOnStart)
            return;
        
        _selectedButton = _buttons[_curIndex];
        foreach (var button in _buttons)
        {
            _tmProList.Add(button.GetComponentInChildren<TextMeshProUGUI>());
        }
        SetSelectedButton();
    }

    private void Update()
    {
        // Go up and down through menu buttons
        if (Input.GetKeyDown(KeyCode.W))
        {
            _curIndex = (_curIndex - 1 + _buttons.Count) % _buttons.Count;
            _selectedButton = _buttons[_curIndex];
            SetSelectedButton();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _curIndex = (_curIndex + 1) % _buttons.Count;
            _selectedButton = _buttons[_curIndex];
            SetSelectedButton();
        }

        // Click on current button
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            _selectedButton.onClick?.Invoke();
        }
    }

    private void SetSelectedButton()
    {
        foreach (var t in _tmProList)
        {
            t.color = _defaultColor;
        }

        if(_tmProList != null && _tmProList.Count > _curIndex)
            _tmProList[_curIndex].color = _selectedColor;
    }
}
