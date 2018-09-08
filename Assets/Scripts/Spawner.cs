using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform Waypoint;
    private void Start()
    {
        Enemy.GetComponent<Enemy>().waypoint = Waypoint;
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        GameObject EnemyInst;
        while (true)
        {
            int randomNumber = Random.Range(1, 5);
            EnemyInst = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
            yield return new WaitForSeconds(randomNumber);
        }
    }
}
