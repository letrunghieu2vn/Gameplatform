using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    public UIName UiName;

    public virtual void Start() {
        OnInit();
    }

    public virtual void OnInit() { }
    public virtual void OnOpen() { }
    public virtual void OnClose() { }
}
