using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Image HPBar;
    public float speed;
    public float HP = 500;
    public bool enemyInside;
    public float damage = 10;
    public AudioClip[] HitSounds;

    private float maxHP;

    private Vector2 currentMoveVector;
    private Vector2 lastMoveVector;

    private Hitbox hitBox;
    private Rigidbody2D rigigbody;
    private AudioSource audioSource;

    public delegate void MovingAction();
    public static event MovingAction OnStartedMoving;

    public delegate void StoppingAction();
    public static event StoppingAction OnStoppedMoving;

    public delegate void PunchAction(Hitbox.HitDirection hitDir);
    public static event PunchAction OnPunch;

    // Update is called once per frame
    private void Start()
    {
        rigigbody = this.GetComponent<Rigidbody2D>();
        hitBox = GetComponentInChildren<Hitbox>();
        audioSource = GetComponent<AudioSource>();

        maxHP = HP;
        updateHPBar();

        lastMoveVector = currentMoveVector;
    }
    void Update()
    {
        currentMoveVector = new Vector2(Input.GetAxis("Horizontal_P1"), Input.GetAxis("Vertical_P1"));
        rigigbody.velocity = (currentMoveVector * speed);

        if (lastMoveVector.sqrMagnitude == 0 && currentMoveVector.sqrMagnitude != 0)
            OnStartedMoving();
        else if(currentMoveVector.sqrMagnitude == 0 && lastMoveVector.sqrMagnitude != 0)
            OnStoppedMoving();

        if (Input.GetButtonDown("Horizontal_P2") && hitBox.EnemyList.Count != 0 || Input.GetButtonDown("Vertical_P2") && hitBox.EnemyList.Count != 0)
        {
            OnPunch(hitBox.HitDir);
            audioSource.PlayOneShot(HitSounds[Random.Range(0, HitSounds.Length)]);

            for (int i = 0; i < GetComponentInChildren<Hitbox>().EnemyList.Count; i++)
            {
                hitBox.EnemyList[i].GetComponent<Enemy>().GetDamage(damage);
                if (hitBox.EnemyList[i].GetComponent<Enemy>().HP <= 0)
                {
                    Destroy(hitBox.EnemyList[i]);
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

