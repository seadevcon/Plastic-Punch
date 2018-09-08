using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour {

    public Animator UpperBody;


    public void PlayAnimationWhenHit()
    {
        UpperBody.SetTrigger(AnimationUtils.ANIM_PARAM_GOTHIT);
    }
}
