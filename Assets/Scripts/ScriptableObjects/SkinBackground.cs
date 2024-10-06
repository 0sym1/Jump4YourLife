using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SkinBackground", menuName = "ScriptableObject/SkinBackground")]
public class SkinBackground : ScriptableObject
{
    [SerializeField] private string nameSkin;
    [SerializeField] private Sprite avatar;
    [SerializeField] private Sprite imageBG;
    [SerializeField] private Sprite groundSpriteNormal;
    [SerializeField] private Sprite groundSpriteBroken;

    public Sprite getSpriteAvatar
    {
        get { return avatar; }
    }
    public string getNameSkin
    {
        get { return nameSkin; }
    }
    public Sprite GetImageBG{
        get { return imageBG; }
    }
    public Sprite GetSpriteGroundNormal{
        get { return groundSpriteNormal; }
    }
    public Sprite GetSpriteGroundBroken{
        get { return groundSpriteBroken; }
    }
}
