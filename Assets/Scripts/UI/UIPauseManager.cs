using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPauseManager : UICanvas
{
    public Button resumeButton;
    public Button backMenuButton;
    public Button quitGameButton;
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        backMenuButton.onClick.AddListener(BackToMenu);
        quitGameButton.onClick.AddListener(QuitGame);
    }
    void ResumeGame() {
        Time.timeScale = 1f;
        UIManager.instace.GetUICanvas(UIName.UIPause).OnClose();
        UIManager.instace.GameIsPaused = false;
    }

    void BackToMenu()
    {
        Time.timeScale = 1f;
        UIManager.instace.GetUICanvas(UIName.UIPause).OnClose();
        ScreenChange.instance.ScenceChange(0);
        UIManager.instace.GetUICanvas(UIName.UIMenu).OnOpen();
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
