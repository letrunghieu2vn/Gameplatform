using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStory : NPC
{
    [TextArea(3, 5)]
    public string[] sentences;

    public override void Update()
    {
        base.Update();
    }

    public override void OnTrigger()
    {
        base.OnTrigger();
        UICanvas dialougeCanvas = UIManager.instace.GetUICanvas(UIName.UIDialouge);
        UIDialogueManager dialogueManager = dialougeCanvas.GetComponent<UIDialogueManager>();
        dialougeCanvas.OnOpen();
        dialogueManager.StartSentences(sentences);
        
    }

    public override void OnExit()
    {
        base.OnExit();
        UIManager.instace.GetUICanvas(UIName.UIDialouge).OnClose();
    }
}
