using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinShopController : Panel
{
    public static SkinShopController Instance;
    private List<SkinPlayer> skinPlayers = new List<SkinPlayer>();
    private List<SkinBackground> skinBackgrounds = new List<SkinBackground>();

    [SerializeField] private GameObject skinPlayerPanel;
    [SerializeField] private GameObject skinBackgroundPanel;
    [SerializeField] private Transform contentTransformAvt;
    [SerializeField] private Transform contentTransformBG;
    [SerializeField] private GameObject avtBtnPrefab;
    [SerializeField] private GameObject backgroundBtnPrefab;

    private void Awake(){
        Instance = this;
        LoadData();
    }
    private void Start(){
        panelName = "SkinShopPanel";
        OpenSkinPlayer();
        GenerateButton();
    }
    public void OpenSkinPlayer(){
        skinPlayerPanel.SetActive(true);
        skinBackgroundPanel.SetActive(false);
    }
    public void OpenSkinBackground(){
        skinPlayerPanel.SetActive(false);
        skinBackgroundPanel.SetActive(true);
    }

    private void LoadData(){
        //load data skinplayer
        SkinPlayer[] datasAvt = Resources.LoadAll<SkinPlayer>("SkinPlayerData");
        foreach(SkinPlayer player in datasAvt){
            skinPlayers.Add(player);
        }

        //load data skinbackground
        SkinBackground[] datasBG = Resources.LoadAll<SkinBackground>("SkinBackgroundData");
        foreach(SkinBackground skin in datasBG){
            skinBackgrounds.Add(skin);
        }
    }

    private void GenerateButton(){
        // Generate avt
        foreach(SkinPlayer player in skinPlayers){
            var obj = Instantiate(avtBtnPrefab, contentTransformAvt);
            obj.GetComponent<AvatarButtonController>().Init(player);
        }
        // Generate BG
        foreach(SkinBackground skin in skinBackgrounds){
            var obj = Instantiate(backgroundBtnPrefab, contentTransformBG);
            obj.GetComponent<BackgroundButtonController>().Init(skin);
        }
    }

    public void ChangeAvatar(SkinPlayer skin){

    }
    public void ChangeBackground(SkinBackground skin){

    }
}
