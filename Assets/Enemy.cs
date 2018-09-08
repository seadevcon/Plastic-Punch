using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public float HP = 100;
    public Transform waypoint;
    public float speed = 2;

    private Vector2 direction;
    private Transform playerTransform;
    private bool chasePlayer;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        direction = Vector2.zero;
        if (!chasePlayer)
        {
            direction = waypoint.position - transform.position;

        }
        else
        {
            direction = playerTransform.position - transform.position;
        }
        direction = direction.normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        Debug.Log(HP);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            chasePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.tag == "Player")
            {
                chasePlayer = false;
            }
        }
    }
}
