using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIPauseManager : UICanvas
{
    public override void Start()
    {
        base.Start();
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuGame");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
