using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStoreManager : UICanvas
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnClose()
    {
        base.OnClose();
        if (UIManager.instace.GetUICanvas(UIName.UIBag))
            UIManager.instace.GetUICanvas(UIName.UIBag).gameObject.SetActive(false);
    }
}
