using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainMenuManager : UICanvas
{
    public Button playButton;
    public Button quitButton;
    ScreenChange screenChange;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        screenChange = ScreenChange.instance;
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        UIManager.instace.GetUICanvas(UIName.UIMenu).OnClose();
        screenChange.ScenceChange(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
