using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : PanelManager
{
    private string link = "https://www.facebook.com/profile.php?id=100007136566181";
    [SerializeField] private Image soundBackgroundImg;
    [SerializeField] private Image soundEffectImg;
    [SerializeField] private Sprite onSoundSprite;
    [SerializeField] private Sprite offSoundSprite;

    private void Start(){
        soundBackgroundImg.sprite = onSoundSprite;
        soundEffectImg.sprite = onSoundSprite;
    }
    public void OpenCredit(){
        Application.OpenURL(link);
    }
    public void OnOffSoundBackground(){
        ChangeImgSound(soundBackgroundImg);
    }
    public void OnOffSoundEffect(){
        ChangeImgSound(soundEffectImg);
    }
    private void ChangeImgSound(Image image){
        if(image.sprite == onSoundSprite) image.sprite = offSoundSprite;
        else image.sprite = onSoundSprite;
    }
}
