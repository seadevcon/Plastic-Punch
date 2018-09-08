using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public enum HitDirection { RIGHT, LEFT, UP, DOWN}
    public HitDirection HitDir { get; private set; }

    public List<GameObject> EnemyList = new List<GameObject>();
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal_P2")<0)
        {
            transform.localPosition = new Vector3(-0.5f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            HitDir = HitDirection.LEFT;
        }
        else if(Input.GetAxis("Horizontal_P2")>0)
        {
            transform.localPosition = new Vector3(0.5f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            HitDir = HitDirection.RIGHT;
        }
        else if (Input.GetAxis("Vertical_P2") < 0)
        {
            transform.localPosition = new Vector3(0, -0.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            HitDir = HitDirection.DOWN;
        }
        else if (Input.GetAxis("Vertical_P2") > 0)
        {
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            HitDir = HitDirection.UP;
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            gameObject.GetComponentInParent<PlayerController>().enemyInside = true;
            if (!EnemyList.Contains(col.gameObject))
            {
                EnemyList.Add(col.gameObject);

            }
        }



    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {

            gameObject.GetComponentInParent<PlayerController>().enemyInside = false;
            if (EnemyList.Contains(col.gameObject))
            {
                EnemyList.Remove(col.gameObject);
            }

        }
    }
}
