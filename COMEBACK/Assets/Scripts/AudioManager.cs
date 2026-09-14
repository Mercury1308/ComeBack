using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    //public AudioClip Shoot;


    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    /*
    public void ShootSound()
    {
        shootSource.clip = Shoot;
        shootSource.Play();
    }
    */

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }



}
