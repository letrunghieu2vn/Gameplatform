using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    public UIName UiName;
    public virtual void Awake() {
        OnInit();
    }

    public virtual void OnInit() {
        UIManager.instace.AddUI(this);
    }
    public virtual void OnOpen() {
        gameObject.SetActive(true);
    }
    public virtual void OnClose() {
        gameObject.SetActive(false);
    }


}
