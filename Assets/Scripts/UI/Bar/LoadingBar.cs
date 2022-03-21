using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : BarController
{
    public override void Start()
    {
        base.Start();
    }
    public override void OnChangeBar(float valueChange)
    {
        currentValue = valueChange;
        barSlide.fillAmount = currentValue;
    }
}
