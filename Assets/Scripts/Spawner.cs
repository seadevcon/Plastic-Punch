using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public Transform Waypoint;
    private void Start()
    {
        Enemy1.GetComponent<Enemy>().waypoint = Waypoint;
        Enemy2.GetComponent<Enemy>().waypoint = Waypoint;

        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        GameObject EnemyInst;
        while (true)
        {
            int randomNumber = Random.Range(1, 6);
            int enemyRandom = Random.Range(1, 3);
           
            yield return new WaitForSeconds(randomNumber);
            if (enemyRandom == 1)
            {
                EnemyInst = Instantiate(Enemy1, transform.position, transform.rotation) as GameObject;
                EnemyInst.GetComponent<Enemy>().HP *= randomNumber+5;
            }
            if(enemyRandom == 2)
            {
                EnemyInst = Instantiate(Enemy2, transform.position, transform.rotation) as GameObject;
                EnemyInst.GetComponent<Enemy>().HP *= randomNumber+5;

            }
        }
    }
}
