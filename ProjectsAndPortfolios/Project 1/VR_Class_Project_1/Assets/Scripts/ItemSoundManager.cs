using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ItemSoundManager : MonoBehaviour
{
    public AudioClip[] sounds;
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;

    public AudioSource audioSource;
    public LayerMask soundInteractors;

    private void Awake()
    {
        if (this.GetComponent<AudioSource>() == null)
        {
            this.gameObject.AddComponent<AudioSource>();
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        
    }
    public void PlaySound()
    {
        audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((soundInteractors.value & (1 << collision.gameObject.layer)) != 0)
        {
            PlaySound();
        }
    }
}
