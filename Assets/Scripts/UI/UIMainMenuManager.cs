using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainMenuManager : UICanvas
{
    public Button playButton;
    public Button quitButton;

    public override void Start()
    {
        base.Start();
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public override void OnInit()
    {
        UIManager.instace.AddUI(this);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UIManager.instace.GetUICanvas(UIName.UIMenu).OnClose();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
