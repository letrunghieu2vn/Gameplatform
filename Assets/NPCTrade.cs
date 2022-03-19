using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrade : NPC
{
    bool activeBag = false;
    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeBag = !activeBag;
            if (activeBag)
                UIManager.instace.GetUICanvas(UIName.UIBag).OnOpen();
            else UIManager.instace.GetUICanvas(UIName.UIBag).OnClose();
        }
    }
    public override void OnTrigger()
    {
        base.OnTrigger();
        UIManager.instace.GetUICanvas(UIName.UIBag).OnOpen();
        UIManager.instace.GetUICanvas(UIName.UIStore).OnOpen();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public void ExitStorePanel()
    {
        UIManager.instace.GetUICanvas(UIName.UIBag).OnClose();
        UIManager.instace.GetUICanvas(UIName.UIStore).OnClose();
    }

}
