using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButtonController : MonoBehaviour
{
    [SerializeField] private Image preview;
    [SerializeField] private TextMeshProUGUI nameTxt;
    private SkinBackground backgroundInfors;
    
   public void Init(SkinBackground avatar)
    {
        backgroundInfors = avatar;
        preview.sprite = backgroundInfors.getSpriteAvatar;
        nameTxt.text = backgroundInfors.getNameSkin;
    }
    public void OnClick()
    {
        SkinShopController.Instance.ChangeBackground(backgroundInfors);
    }
}
