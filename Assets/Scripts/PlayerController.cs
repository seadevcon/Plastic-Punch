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

    private Vector2 currentMoveVector;
    private Vector2 lastMoveVector;

    public delegate void MovingAction();
    public static event MovingAction OnStartedMoving;

    public delegate void StoppingAction();
    public static event StoppingAction OnStoppedMoving;


    // Update is called once per frame
    private void Start()
    {
        maxHP = HP;
        updateHPBar();

        lastMoveVector = currentMoveVector;
    }
    void Update()
    {
        currentMoveVector = new Vector2(Input.GetAxis("Horizontal_P1"), Input.GetAxis("Vertical_P1"));
        player.GetComponent<Rigidbody2D>().velocity = (currentMoveVector * speed);

        if (lastMoveVector.sqrMagnitude == 0 && currentMoveVector.sqrMagnitude != 0)
            OnStartedMoving();
        else if(currentMoveVector.sqrMagnitude == 0 && lastMoveVector.sqrMagnitude != 0)
            OnStoppedMoving();

        if (Input.GetButtonDown("Horizontal_P2") && GetComponentInChildren<Hitbox>().EnemyList.Count != 0 || Input.GetButtonDown("Vertical_P2") && GetComponentInChildren<Hitbox>().EnemyList.Count != 0)
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

        lastMoveVector = currentMoveVector;
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

