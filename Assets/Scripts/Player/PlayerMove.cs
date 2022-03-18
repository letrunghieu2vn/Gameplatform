using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator myAnim;

    Vector2 movement;

    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float radiusCheck;

    bool facingRight = true;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
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

    void Jump() {
        myBody.velocity = new Vector3(myBody.velocity.x, jumpForce, 0);
        myAnim.SetBool("Jump",true);
    }

    void Move() {
        if (movement != Vector2.zero)
        {
            myBody.velocity = new Vector3(movement.x*speed, myBody.velocity.y, 0);
            if ((movement.x > 0 && !facingRight) || (movement.x < 0 && facingRight))
                Flip();

           
        }
        myAnim.SetFloat("Horizontal", Mathf.Abs(movement.x));
    }

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    bool CheckGround() {

        Collider2D[] hitGround = Physics2D.OverlapCircleAll(groundCheck.position, radiusCheck, whatIsGround);

        if (hitGround.Length > 0)
            return true;

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,radiusCheck);
    }


   
}
