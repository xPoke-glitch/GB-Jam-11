using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _startButton;
    [SerializeField]
    private TextMeshProUGUI _exitButton;
    [SerializeField] 
    private ButtonSelectionHelper _btnHelper;
    [SerializeField] 
    private AudioClip _backgroundMusic;
    
    private float _time = 0.5f;
    private Color colorA1;
    private Color colorA0;
    private void Start()
    {
        // Init anim
        colorA0 = _startButton.color;
        colorA0.a = 0;
        _startButton.color = colorA0;
        _exitButton.color = colorA0;
        colorA1 = _startButton.color;
        colorA1.a = 1;
        FadePanel.Instance.FadeOut(() =>
        {
            LeanTween.value(this.gameObject, UpdateValueCallback, colorA0, colorA1, _time).setOnComplete(() =>
            {
                _btnHelper.ForceInitButtons();
                AudioManager.Instance.PlayGameBackgroundMusic(_backgroundMusic, true);
            });
        });
    }

    private void UpdateValueCallback(Color val)
    {
        _startButton.color = val;
        _exitButton.color = val;
    }

    public void GoToGame()
    {
        FadePanel.Instance.FadeIn(() => {
            SceneManager.LoadScene("GameScene");
        });
    }

}
