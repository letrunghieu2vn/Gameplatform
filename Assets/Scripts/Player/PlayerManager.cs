using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Actor
{
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float radiusCheck;

    UIPlayerManager uIPlayerManager;
    Vector2 movement;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInit()
    {
        base.OnInit();
        uIPlayerManager = UIPlayerManager.instance;
        BarController healthBarController = uIPlayerManager.GetBarController(BarName.HealthBar);
        healthBarController.OnInit(m_Max_Health, m_Health);
    }

    public void TakeDamage(float damage) {
        ChangeHealth(-damage);
        BarController healthBarController = uIPlayerManager.GetBarController(BarName.HealthBar);
        healthBarController.OnChangeBar(-damage);
    }

    public void TakeHealth(float healing) {
        ChangeHealth(healing);
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            Jump();
        }
        else myAnim.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        myBody.velocity = new Vector3(myBody.velocity.x, jumpForce, 0);
        myAnim.SetBool("Jump", true);
    }

    public override void Move()
    {
        if (movement != Vector2.zero)
        {
            myBody.velocity = new Vector3(movement.x * m_Speed, myBody.velocity.y, 0);
            if ((movement.x > 0 && !facingRight) || (movement.x < 0 && facingRight))
                Flip();


        }
        myAnim.SetFloat("Horizontal", Mathf.Abs(movement.x));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    bool CheckGround()
    {

        Collider2D[] hitGround = Physics2D.OverlapCircleAll(groundCheck.position, radiusCheck, whatIsGround);

        if (hitGround.Length > 0)
            return true;

        return false;
    }

    public override void Death()
    {
        base.Death();
        UIManager.instace.GameOver();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radiusCheck);
    }
}
