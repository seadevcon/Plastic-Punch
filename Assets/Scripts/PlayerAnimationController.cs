using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    public Animator UpperBody;
    public Animator LowerBody;

    void OnEnable()
    {
        PlayerController.OnStartedMoving += StartMoving;
        PlayerController.OnStoppedMoving += StopMoving;
        PlayerController.OnPunch += Punch;
    }


    void OnDisable()
    {
        PlayerController.OnStartedMoving -= StartMoving;
        PlayerController.OnStoppedMoving += StopMoving;
        PlayerController.OnPunch -= Punch;
    }

    void StartMoving()
    {
        LowerBody.SetTrigger(AnimationUtils.ANIM_PARAM_ISMOVING);
    }

    void StopMoving()
    {
        LowerBody.SetTrigger(AnimationUtils.ANIM_PARAM_HASSTOPPED);
    }

    void Punch(Hitbox.HitDirection hitDir)
    {
        if(hitDir == Hitbox.HitDirection.LEFT)
            UpperBody.SetTrigger(AnimationUtils.ANIM_PARAM_PUNCHLEFT);
        else if (hitDir == Hitbox.HitDirection.RIGHT)
            LowerBody.SetTrigger(AnimationUtils.ANIM_PARAM_PUNCHRIGHT);
    }

}
