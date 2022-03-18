
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator myAnim;
    public Vector3 target;
    public float speed;
    public float viewFar;
    bool facingRight = true;

    Vector2 endPoint;

    public LayerMask whatIsPlayer;

    public Vector3 spawnPoint;

    public float distanceStopSetting;
    public float distanceToStop;

    public Stage currentStage;
    public float nextTimeDecision, nextTimeDecisionSetting;

    //nho co doan cho con nay dung lai
    void FixedUpdate()
    {

        //check khoang cach de dung lai
        if (currentStage==Stage.Move)
        {
            float distance = Vector2.Distance(transform.position, target);
            if (distance >= distanceToStop)
                Movement();
            else
            {
                currentStage = Stage.Idle;
                myAnim.SetBool("walk", false);
            }
        }
        

    }

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        if (!PlayerOnMyView() && currentStage == Stage.Idle && nextTimeDecision <= 0f)
            MakeDecision();

        if (nextTimeDecision > 0f)
            nextTimeDecision -= Time.deltaTime;
    }

    void MakeDecision() {
        int decision = Random.Range(0, 10);
        
        if (decision <= 3)
        {
            currentStage = Stage.Idle;
            target = transform.position;
            myAnim.SetBool("walk", false);
            Debug.Log("Quyet dinh la: Dung Im!");
        }

        if (decision > 3)
        {
            Debug.Log("Quyet dinh la: Di Chuyen!");
            currentStage = Stage.Move;
            distanceToStop = 0.05f;
            target = SetUptargetTogoAround();
        }

        nextTimeDecision = nextTimeDecisionSetting;
    }

    float bouch = 2f;

    Vector2 SetUptargetTogoAround()
    {
        Vector2 TargetNew = Vector2.zero;
        TargetNew.x = spawnPoint.x + (bouch * -1);
        bouch *= -1;
        TargetNew.y = transform.position.y;
        currentStage = Stage.Move;
        Debug.Log("Muc Tieu: "+TargetNew);
        return TargetNew;
    }

    void Movement() {
        Vector2 direction = (target - transform.position).normalized;
        myBody.MovePosition(myBody.position + direction * speed * Time.deltaTime);
        myAnim.SetBool("walk", true);
        if  ((transform.position.x > target.x && !facingRight) ||
            (transform.position.x < target.x && facingRight) )
             Flip();
    }


        

    bool PlayerOnMyView() {
        endPoint = (Vector2)transform.position - new Vector2(viewFar, 0);
        RaycastHit2D hitPlayer = Physics2D.Linecast(transform.position, endPoint, whatIsPlayer);

        if (hitPlayer.collider != null)
        {
            Debug.DrawLine(transform.position, hitPlayer.point, Color.red);
            target = hitPlayer.transform.position;
            distanceToStop = distanceStopSetting;
            currentStage = Stage.Move;

            return true;

        }
        else {
            Debug.DrawLine(transform.position, endPoint, Color.green);
        }
        
        return false;
    }
    void Flip()
    {
        viewFar = -viewFar;
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        endPoint = (Vector2)transform.position - new Vector2(viewFar, 0);
    }


    //Flip function nho viewFar=-viewFar;
}
public enum Stage {Idle, Move, Attack}
