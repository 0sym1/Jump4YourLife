using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{
    //Name Panel
    public const String HomePanel_Name = "HomePanel";
    public const String SettingPanel_Name = "SettingPanel";
    public const String SkinShopPanel_Name = "SkinShopPanel";
    public const String Recharge_Name = "RechargePanel";
    public const String GameOverPanel_Name = "GameOverPanel";
    public const String PausePanel_Name = "PausePanel";

    // scene
    public const string HomeScene = "HomeScene";
    public const string GameScene = "GameScene";
    
    // resource
    public const string PanelResourcePath = "PanelPrefabs/";
    public const string SkinPlayerDataResourcePath = "SkinPlayerData/";
    public const string SkinBackgroundDataResourcePath = "SkinBackgroundData/";
    public const string SkinPlayerPrefabs = "SkinPrefabs/";

    //PlayerPrefs
    public const string SkinPlayerCurrent = "SkinPlayerCurrent";
    public const string SkinBackgroundCurrent = "SkinBackgroundCurrent";

    public enum TypeGround{
        normal,
        small,
        fast,
        diagonal,
        invisible,
    }
}
