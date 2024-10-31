using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : Panel
{
    private string link = "https://www.facebook.com/profile.php?id=100007136566181";
    [SerializeField] private Image soundBackgroundImg;
    [SerializeField] private Image soundEffectImg;
    [SerializeField] private Sprite onSoundSprite;
    [SerializeField] private Sprite offSoundSprite;

    private void Start(){
        panelName = "SettingPanel";
        if(PlayerPrefs.GetInt(GameConfig.MucsicBackGround) == 1) soundBackgroundImg.sprite = onSoundSprite;
        else soundBackgroundImg.sprite = offSoundSprite;

        if(PlayerPrefs.GetInt(GameConfig.MucsicSFX) == 1) soundEffectImg.sprite = onSoundSprite;
        else soundEffectImg.sprite = offSoundSprite;
    }
    public void OpenCredit(){
        Application.OpenURL(link);
    }
    public void OnOffSoundBackground(){
        ChangeSound(soundBackgroundImg, "BG");
    }
    public void OnOffSoundEffect(){
        ChangeSound(soundEffectImg, "SFX");
    }
    private void ChangeSound(Image image, string typeSound){
        if(image == null) Debug.Log("hehe");
        if(image.sprite == onSoundSprite){
            image.sprite = offSoundSprite;
            if(typeSound == "BG") SoundManager.Instance.TurnOffMusic();
            else if(typeSound == "SFX") SoundManager.Instance.TurnOffSFX();
        }
        else{
            image.sprite = onSoundSprite;
            if(typeSound == "BG") SoundManager.Instance.TurnOnMusic();
            else if(typeSound == "SFX") SoundManager.Instance.TurnOnSFX();
        }
    }
}
