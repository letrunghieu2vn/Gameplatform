using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChange : MonoBehaviour
{
    public static ScreenChange instance;
    UICanvas canvas_LoadingBar;
    UIManager uiManager;
    UILoadingManager ui_LoadingManager;
    LoadingBar loadingBar;
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);

        }else
        {
            instance = this;
        }
    }
    private void Start()
    {
        uiManager = UIManager.instace;
        canvas_LoadingBar = uiManager.GetUICanvas(UIName.UILoading);
        ui_LoadingManager = canvas_LoadingBar.GetComponent<UILoadingManager>();
        loadingBar = ui_LoadingManager.loadingBar;
    }
    public void ScenceChange(int index)
    {
        canvas_LoadingBar.OnOpen();
        loadingBar.OnInit(0, 1);
        UIManager.instace.OnChangeScenes(index);
        StartCoroutine(loadScenes(index));
    }
    public IEnumerator loadScenes(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            loadingBar.OnChangeBar(progress);
            yield return null;
        }
        canvas_LoadingBar.OnClose();

        

    }
}
