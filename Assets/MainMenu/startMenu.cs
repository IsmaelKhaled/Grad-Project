using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startMenu : MonoBehaviour
{
    public Button StartButton,MiniGamesButton,AboutButton,CreditsButton,QuitButton,ExitAbout,ExitMini,ExitCredits,BinaryButton,LogicButton,ScratchButton,ResButton,BackButton;
    public GameObject MiniGamesMenu,AboutMenu,CreditsMenu,MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BackButton.onClick.AddListener(BackOnClick);
        StartButton.onClick.AddListener(StartOnClick);
        MiniGamesButton.onClick.AddListener(MiniOnClick);
        AboutButton.onClick.AddListener(AboutOnClick);
        CreditsButton.onClick.AddListener(CreditsOnClick);
        QuitButton.onClick.AddListener(QuitOnClick);
        ExitMini.onClick.AddListener(ExitOnClick);
        ExitCredits.onClick.AddListener(ExitOnClick);
        ExitAbout.onClick.AddListener(ExitOnClick);
        LogicButton.onClick.AddListener(LogicOnClick);
        BinaryButton.onClick.AddListener(BinaryOnClick);
        ScratchButton.onClick.AddListener(ScratchOnClick);
        ResButton.onClick.AddListener(ResOnClick);
    }
    void BackOnClick()
    {
    	MainMenu.SetActive(true);
    	BackButton.gameObject.SetActive(false);
    }
    void StartOnClick()
    {
    	MainMenu.SetActive(false);
    	BackButton.gameObject.SetActive(true);
    }
    void MiniOnClick()
    {
    	MiniGamesMenu.SetActive(true);
    	AboutMenu.SetActive(false);
    	CreditsMenu.SetActive(false);
    }
    void AboutOnClick()
    {
    	MiniGamesMenu.SetActive(false);
    	AboutMenu.SetActive(true);
    	CreditsMenu.SetActive(false);
    }
    void CreditsOnClick()
    {
    	MiniGamesMenu.SetActive(false);
    	AboutMenu.SetActive(false);
    	CreditsMenu.SetActive(true);
    }
    void QuitOnClick(){}
    void ExitOnClick()
    {
    	MiniGamesMenu.SetActive(false);
    	AboutMenu.SetActive(false);
    	CreditsMenu.SetActive(false);
    }
    void BinaryOnClick()
    {
    	MainMenu.SetActive(false);
    	BackButton.gameObject.SetActive(true);
    }
    void LogicOnClick()
    {
    	MainMenu.SetActive(false);
    	BackButton.gameObject.SetActive(true);
    }
    void ScratchOnClick()
    {
    	MainMenu.SetActive(false);
    	BackButton.gameObject.SetActive(true);
    }
    void ResOnClick()
    {
    	MainMenu.SetActive(false);
    	BackButton.gameObject.SetActive(true);
    }
}
