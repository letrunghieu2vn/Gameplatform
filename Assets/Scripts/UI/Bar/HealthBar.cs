using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : BarController
{

    UIPlayerManager uIPlayerManager;
    public override void Start()
    {
        base.Start();
        uIPlayerManager = UIPlayerManager.instance;
        uIPlayerManager.AddBarController(this);
    }

    public override void OnChangeBar(float valueChange)
    {
        base.OnChangeBar(valueChange);
    }
}
