using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Vector3 target;

    public float speed;
    public float nextWaypointDistance = 3f;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public float distanceToStop;
    public Vector3 spawnPoint;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .1f);
        spawnPoint = transform.position;

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }


        //check khoang cach de dung lai
        float distance = Vector2.Distance(transform.position, target);
        if (distance >= distanceToStop)
            Movement();

        CheckPlayer();
    }

    void Movement() {
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;

        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    public LayerMask whatIsTarget;
    public float radiusFollow;
    void CheckPlayer() {
        Collider2D hitTarget = Physics2D.OverlapCircle(transform.position, radiusFollow, whatIsTarget);
        if (hitTarget != null)
        {
            target = hitTarget.transform.position;
            return;
        }

        target = spawnPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radiusFollow);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToStop);
    }
}
 