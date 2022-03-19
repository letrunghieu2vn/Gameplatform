using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIName {UIMenu, UIStore, UIBag, UIPause, UIGameOver, UIDialouge}
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

    bool GameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
            GameIsPaused = !GameIsPaused;
        }
    }

    void Resume() {
        GetUICanvas(UIName.UIGameOver).gameObject.SetActive(false);
    }
    void Pause() {
        GetUICanvas(UIName.UIGameOver).gameObject.SetActive(true);
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
}
