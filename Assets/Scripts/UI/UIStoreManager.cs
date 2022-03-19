using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStoreManager : UICanvas
{
    public override void Start()
    {
        base.Start();
        Debug.Log("dd");
    }

    public override void OnClose()
    {
        base.OnClose();
        if (UIManager.instace.GetUICanvas(UIName.UIBag))
            UIManager.instace.GetUICanvas(UIName.UIBag).gameObject.SetActive(false);
    }
}
