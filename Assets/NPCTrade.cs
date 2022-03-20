using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrade : NPC
{
    
    public override void Update()
    {
        base.Update();
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
