using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float m_Health;
    public float m_Max_Health;
    public float m_Stamina;
    public float m_Max_Stamina;
    public float m_Damage;

    public float m_Speed;
    public bool facingRight;

    public Rigidbody2D myBody;
    public Animator myAnim;

    public virtual void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    public virtual void Start() {
        OnInit();
    }
    public virtual void OnInit() {}

    public virtual void ChangeHealth(float valueChange) {
        m_Health += valueChange;
        if (m_Health > m_Max_Health)
            m_Health = m_Max_Health;
        if (m_Health <= 0f)
            Death();
    }
    public virtual void ChangeStamina() { }
    public virtual void Move() { }
    public virtual void Death() { }

}
