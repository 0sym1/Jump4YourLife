using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvatarButtonController : MonoBehaviour
{
    [SerializeField] private Image preview;
    [SerializeField] private GameObject tickImg;
    private SkinPlayer avatarInfors;
    
    void OnEnable(){
        Messenger.AddListener<string>(EventKey.CHANGE_SKIN, OnChangeSkin);
        
    }
    void OnDisable() {
        Messenger.RemoveListener<string>(EventKey.CHANGE_SKIN, OnChangeSkin);
    }
    private void OnChangeSkin(string arg1)
    {
        tickImg.SetActive(arg1 == avatarInfors.GetNameSkin);
    }
    public SkinPlayer GetSkinPlayer(){
        return avatarInfors;
    }
    public void SetTick(bool isTick){
        tickImg.SetActive(isTick);
    }
   public void Init(SkinPlayer avatar)
    {
        avatarInfors = avatar;

        preview.sprite = avatarInfors.GetSpriteAvatar;
        tickImg.SetActive(false);
    }
    public void OnClick()
    {
        Messenger.Broadcast(EventKey.CHANGE_SKIN, avatarInfors.GetNameSkin);
        tickImg.SetActive(true);
        SkinShopController.Instance.ChangeAvatar(avatarInfors);
    }
}
