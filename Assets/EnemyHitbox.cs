using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public float damage = 1;
    private bool inRange = false;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
            StartCoroutine("makeDamage");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
            StopCoroutine("makeDamage");
        }
    }
    IEnumerator makeDamage()
    {
        while (inRange)
        {
            Player.GetComponent<PlayerController>().getDamage(damage);
            yield return new WaitForSeconds(1f);

        }
    }
}
