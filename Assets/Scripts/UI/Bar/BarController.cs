using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarName {HealthBar, StaminaBar}
public class BarController : MonoBehaviour
{
    public BarName barName;
    public float maxValue, currentValue;
    public Image barSlide;
    UIPlayerManager uIPlayerManager;

    public virtual void Start() {
        OnInit(1,1);
        uIPlayerManager = UIPlayerManager.instance;
        uIPlayerManager.AddBarController(this);
    }
    public virtual void OnInit(float _maxValue, float _currentValue) {
        maxValue = _maxValue;
        currentValue = _currentValue;
        OnChangeBar(0);
    }
    public virtual void OnChangeBar(float valueChange) {
        currentValue += valueChange;
        if (currentValue > maxValue)
            currentValue = maxValue;
        barSlide.fillAmount = currentValue / maxValue;
    }
}
