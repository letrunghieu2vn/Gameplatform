using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerManager : UICanvas
{

    public static UIPlayerManager instance;
    private void Awake()
    {
        instance = this;
    }
    public List<BarController> barControllers;
    public override void Start()
    {
        base.Start();
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
