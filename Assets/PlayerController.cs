using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Image HPBar;
    public float speed;
    public GameObject player;
    public float HP = 500;
    public bool enemyInside;
    public float damage = 10;

    private float maxHP;
    // Update is called once per frame
    private void Start()
    {
        maxHP = HP;
        updateHPBar();
    }
    void Update()
    {
        
        Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal_P1"), Input.GetAxis("Vertical_P1"));
        player.GetComponent<Rigidbody2D>().velocity = (moveVector * speed);

        if (Input.GetButtonDown("Fire_P1") && GetComponentInChildren<Hitbox>().EnemyList.Count != 0)
        {
            for (int i = 0; i < GetComponentInChildren<Hitbox>().EnemyList.Count; i++)
            {
                GetComponentInChildren<Hitbox>().EnemyList[i].GetComponent<Enemy>().GetDamage(damage);
                if (GetComponentInChildren<Hitbox>().EnemyList[i].GetComponent<Enemy>().HP <= 0)
                {
                    Destroy(GetComponentInChildren<Hitbox>().EnemyList[i]);
                }
            }

        }
    }

    public void getDamage(float damage)
    {
        HP -= damage;
        updateHPBar();
    }
    void updateHPBar()
    {
        HPBar.fillAmount = HP / maxHP;
    }
}

