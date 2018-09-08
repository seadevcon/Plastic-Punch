using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioController : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] PunchSounds;

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        //PlayerController.OnGetHit += GetHit;
        PlayerController.OnPunch += Punch;
    }

    void OnDisable()
    {
        Enemy.OnGetHit -= GetHit;
    }

    void GetHit()
    {
    }

    void Punch(Hitbox.HitDirection dir)
    {
        audioSource.PlayOneShot(PunchSounds[Random.Range(0, PunchSounds.Length)]);

    }
}
