using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerManager : UICanvas
{

    public static UIPlayerManager instance;

    public List<BarController> barControllers;
    public override void Awake()
    {
        base.Awake();
        instance = this;
    }
    public void AddBarController(BarController barController) {
        barControllers.Add(barController);
    }
    public BarController GetBarController(BarName _barName) {
        for (int i = 0; i < barControllers.Count; i++)
        {
            if (barControllers[i].barName == _barName) {
                return barControllers[i];
            }
        }

        return null;
        
    }
}
