using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAudioController : MonoBehaviour {

	private AudioSource audioSource;
    public AudioClip[] HitSounds;

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundWhenHit()
    {
        audioSource.PlayOneShot(HitSounds[Random.Range(0, HitSounds.Length)]);
    }

    //void Punch(Hitbox.HitDirection dir)
    //{
    //    audioSource.PlayOneShot(HitSounds[Random.Range(0, HitSounds.Length)]);
    //}
}
