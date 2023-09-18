using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private TextMeshProUGUI _peopleCounter;
    [SerializeField] private TextMeshProUGUI _description;
    private PeopleManager _peopleManager => PeopleManager.Instance;
    private bool _isWin = false;
    private void Awake()
    {
        GameManager.OnGameOver += InitShow;
        HidePage();
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= InitShow;
    }

    private void InitShow(bool isWin)
    {
        _isWin = isWin;
        SetupPage();
        FadePanel.Instance.FadeIn(ShowPage);
    }

    private void ShowPage()
    {
        if(gameObject)
            gameObject.SetActive(true);
        FadePanel.Instance.FadeOut();
    }
    
    private void HidePage() => gameObject.SetActive(false);

    private void SetupPage()
    {
        int peopleRescued = _peopleManager.PeopleRescued;
        _peopleCounter.text = peopleRescued.ToString();
        
        SetupDescription(_isWin);
    }

    private void SetupDescription(bool isWin)
    {
        if (_peopleManager.PeopleRescued == 0)
            _description.text = "You saved no one!\nTry again";
        else if (!isWin && _peopleManager.PeopleRescued >= _peopleManager.PeopleCount)
            _description.text = "You have to take people to the spaceship!\nTry again";
        else if (!isWin)
            _description.text = "You forgot someone!\nTry again";
        else
            _description.text = "Congratulation!\nYou Won!";
    }
    
    #region Button Signals
    
    public void Retry()
    {
        FadePanel.Instance.FadeIn(() =>
        {
            HidePage();
            SceneManager.LoadScene("GameScene");
        });
        
    }
    
    public void MainMenu()
    {
        FadePanel.Instance.FadeIn(() =>
        {
            HidePage();
            SceneManager.LoadScene("MainMenu");
        });
    }
    
    #endregion
    
    
}
