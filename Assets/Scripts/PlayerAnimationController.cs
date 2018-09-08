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
    }


    void OnDisable()
    {
        PlayerController.OnStartedMoving -= StartMoving;
        PlayerController.OnStoppedMoving += StopMoving;
    }

    void StartMoving()
    {
        LowerBody.SetTrigger(AnimationUtils.ANIM_PARAM_ISMOVING);
    }

    void StopMoving()
    {
        LowerBody.SetTrigger(AnimationUtils.ANIM_PARAM_HASSTOPPED);
    }

    void Punch()
    {
        LowerBody.SetTrigger(AnimationUtils.ANIM_PARAM_ISMOVING);

    }

}
