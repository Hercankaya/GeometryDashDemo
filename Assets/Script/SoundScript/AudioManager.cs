using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    
    public Sound[] music, sfx ;
    public AudioSource musicSource, sfxSource ;
    public static AudioManager Instance;
 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        PlayMusic("GameBackgroundMusic");
    }
   
    public void PlayMusic(string name)
    {
        Sound s =Array.Find(music , x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }
    public void PlaySFX(string name)
    {

        Sound s = Array.Find(sfx, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToogleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    
}
