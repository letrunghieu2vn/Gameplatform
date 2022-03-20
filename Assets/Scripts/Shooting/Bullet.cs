using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public Rigidbody2D myBody;
    public float bulletSpeed;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy !=null)
        {
            enemy.ChangeHealth(-damage);
        }
        Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        myBody.MovePosition(myBody.position + (Vector2)transform.right * bulletSpeed * Time.deltaTime);
    }


}
