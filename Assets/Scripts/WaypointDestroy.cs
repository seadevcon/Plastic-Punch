using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointDestroy : MonoBehaviour
{
    private GameObject Player;
    private GameObject Scriptholder;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Scriptholder = GameObject.FindGameObjectWithTag("Scriptholder");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Player.GetComponentInChildren<Hitbox>().EnemyList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Scriptholder.GetComponent<WaterPollution>().Pollution();
        }
    }
}
