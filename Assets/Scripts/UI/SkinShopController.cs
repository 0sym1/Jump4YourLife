using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinShopController : Panel
{
    private List<SkinPlayer> skinPlayers = new List<SkinPlayer>();
    [SerializeField] private GameObject skinPlayerPanel;
    [SerializeField] private GameObject skinBackgroundPanel;
    private void Start(){
        panelName = "SkinShopPanel";
        OpenSkinPlayer();
    }
    public void OpenSkinPlayer(){
        skinPlayerPanel.SetActive(true);
        skinBackgroundPanel.SetActive(false);
    }
    public void OpenSkinBackground(){
        skinPlayerPanel.SetActive(true);
        skinBackgroundPanel.SetActive(false);
    }

    private void LoadData(){
        //load data skinplayer
        SkinPlayer[] datas = Resources.LoadAll<SkinPlayer>("SkinPlayerData");
        foreach(SkinPlayer player in datas){
            skinPlayers.Add(player);
        }

        //load data skinbackground
    }
}
