using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButtonController : MonoBehaviour
{
    [SerializeField] private Image preview;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private GameObject tick;
    private SkinBackground backgroundInfors;
    
    void OnEnable(){
        Messenger.AddListener<string>(EventKey.CHANGE_THEME, OnChangeSkin);
        
    }
    void OnDisable() {
        Messenger.RemoveListener<string>(EventKey.CHANGE_THEME, OnChangeSkin);
    }
    private void OnChangeSkin(string arg1){
        tick.SetActive(arg1 == backgroundInfors.getNameSkin);
    }
        
   public void Init(SkinBackground avatar)
    {
        backgroundInfors = avatar;
        preview.sprite = backgroundInfors.getSpriteAvatar;
        nameTxt.text = backgroundInfors.getNameSkin;
        tick.SetActive(false);
    }
    public void OnClick()
    {
        Messenger.Broadcast(EventKey.CHANGE_THEME, backgroundInfors.getNameSkin);
        SkinShopController.Instance.ChangeBackground(backgroundInfors);
    }
}
