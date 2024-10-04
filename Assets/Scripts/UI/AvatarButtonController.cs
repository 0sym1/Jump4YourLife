using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarButtonController : MonoBehaviour
{
    [SerializeField] private Image preview;
    private SkinPlayer avatarInfors;
    
   public void Init(SkinPlayer avatar)
    {
        avatarInfors = avatar;

        preview.sprite = avatarInfors.GetSpriteAvatar;
    }
    public void OnClick()
    {
        SkinShopController.Instance.ChangeAvatar(avatarInfors);
    }
}
