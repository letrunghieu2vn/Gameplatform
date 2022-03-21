using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarName {HealthBar, StaminaBar, LoadingBar}
public class BarController : MonoBehaviour
{
    public BarName barName;
    public float maxValue, currentValue;
    public Image barSlide;

    public virtual void Start() {
        OnInit(1,1);
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
