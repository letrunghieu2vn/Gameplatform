using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIName {UIMenu, UIStore, UIBag, UIPause, UIGameOver, UIDialouge, UIPlayer, UILoading}
public class UIManager : MonoBehaviour
{
    public List<UICanvas> uICanvases;
    public static UIManager instace;
    private void Awake()
    {
        if (instace != null)
            Destroy(gameObject);
        else instace = this;
    }

    public bool GameIsPaused;
    public bool gamePlayed;
    bool activeBag;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePlayed)
        {
            GameIsPaused = !GameIsPaused;
            if (GameIsPaused)
                Pause();
            else
                Resume();
            
        }
        if (Input.GetKeyDown(KeyCode.I) && gamePlayed)
        {
            activeBag = !activeBag;
            if (activeBag)
                UIManager.instace.GetUICanvas(UIName.UIBag).OnOpen();
            else UIManager.instace.GetUICanvas(UIName.UIBag).OnClose();
        }
    }

    void Resume() {
        GetUICanvas(UIName.UIPause).gameObject.SetActive(false);
    }
    void Pause() {
        Time.timeScale = 0f;
        GetUICanvas(UIName.UIPause).gameObject.SetActive(true);
    }

    public void AddUI(UICanvas uICanvas) {
        uICanvases.Add(uICanvas);
        if (uICanvas.UiName == UIName.UIMenu)
            return;
        uICanvas.OnClose();
    }
    public UICanvas GetUICanvas(UIName uiFindName) {
        for (int i = 0; i < uICanvases.Count; i++)
        {
            if (uICanvases[i].UiName == uiFindName)
                return uICanvases[i];
        }
        return null;
    }
    public void GameOver() {
        Time.timeScale = 0f;
        GetUICanvas(UIName.UIGameOver).OnOpen();
    }
    void ResetAllUI() {
        for (int i = 0; i < uICanvases.Count; i++)
        {
            uICanvases[i].OnClose();
        }

        GetUICanvas(UIName.UIMenu).OnOpen();
        GameIsPaused = false;
        gamePlayed = false;
        activeBag = false;
    }

    public void OnChangeScenes(int currentScencesIndex) {
        if (currentScencesIndex == 0)
            ResetAllUI();
        else {
            for (int i = 0; i < uICanvases.Count; i++)
            {
                if (uICanvases[i].UiName == UIName.UIMenu)
                    uICanvases[i].OnClose();
                else if (uICanvases[i].UiName == UIName.UIPlayer)
                    uICanvases[i].OnOpen();
            }
        }
    }
}
