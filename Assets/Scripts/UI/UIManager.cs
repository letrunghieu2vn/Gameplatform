using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIName {UIMenu, UIStore, UIBag}
public class UIManager : MonoBehaviour
{
    public List<UICanvas> uICanvas = new List<UICanvas>();
    public static UIManager instace;
    private void Awake()
    {
        if (instace != null)
            Destroy(gameObject);
        else instace = this;
    }

    public UICanvas GetUICanvas(UIName uiFindName) {
        for (int i = 0; i < uICanvas.Count; i++)
        {
            if (uICanvas[i].UiName == uiFindName)
                return uICanvas[i];
        }
        return null;
    }
}
