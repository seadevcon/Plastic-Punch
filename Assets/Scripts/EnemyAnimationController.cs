using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour {

    public Animator UpperBody;

    void OnEnable()
    {
        Enemy.OnGetHit += GetHit;
    }


    void OnDisable()
    {
        Enemy.OnGetHit -= GetHit;
    }

    void GetHit()
    {
        Debug.Log("BÄM");
        UpperBody.SetTrigger(AnimationUtils.ANIM_PARAM_GOTHIT);
    }
}
