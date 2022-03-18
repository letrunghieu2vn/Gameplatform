using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStory : NPC
{
    public GameObject dialougeUI;
    public override void Update()
    {
        base.Update();
    }

    public override void OnTrigger()
    {
        base.OnTrigger();
        dialougeUI.SetActive(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        dialougeUI.SetActive(false);
    }
}
