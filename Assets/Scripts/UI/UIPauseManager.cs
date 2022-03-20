using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPauseManager : UICanvas
{

    public Button backMenuButton;
    public Button quitGameButton;
    public override void Start()
    {
        base.Start();
        backMenuButton.onClick.AddListener(BackToMenu);
        quitGameButton.onClick.AddListener(QuitGame);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        UIManager.instace.GetUICanvas(UIName.UIPause).OnClose();
        UIManager.instace.ResetAllUI();
        ScreenChange.instance.ScenceChange(0);
        UIManager.instace.GetUICanvas(UIName.UIMenu).OnOpen();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
