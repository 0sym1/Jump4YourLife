using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip breakSound;
    public AudioClip gameOver;
    public AudioClip jump;

    // private void Awake(){
    //     musicSource.clip = background;
    //     musicSource.loop = true;
    // }
    private void Start()
    {
        musicSource.loop = true;
        musicSource.clip = background;
        musicSource.Play();
        if(PlayerPrefs.GetInt(GameConfig.MucsicBackGround) == 1)
        {
            TurnOnMusic();
        }
        else
        {
            TurnOffMusic();
        }
        if (PlayerPrefs.GetInt(GameConfig.MucsicSFX) == 1)
        {
            TurnOnSFX();
        }
        else
        {
            TurnOffSFX();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void TurnOnMusic()
    {
        musicSource.mute = false;
        PlayerPrefs.SetInt("IsMusicPlaying", 1);
    }

    public void TurnOffMusic()
    {
        musicSource.mute = true;
        PlayerPrefs.SetInt("IsMusicPlaying", 0);
    }

    public void TurnOnSFX()
    {
        SFXSource.mute = false;
        PlayerPrefs.SetInt("IsSFXPlaying", 1);
    }

    public void TurnOffSFX()
    {
        SFXSource.mute = true;
        PlayerPrefs.SetInt("IsSFXPlaying", 0);
    }
}
