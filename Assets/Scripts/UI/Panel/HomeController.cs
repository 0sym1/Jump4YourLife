using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : Panel
{
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    private void Start()
    {
        panelName = "HomePanel"; 
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void PlayGame(){SceneManager.LoadScene("GameScene");}
    public void OnClickSettingButton() {PanelManager.Instance.OpenPanel(GameConfig.SettingPanel_Name);}
    public void OnClickShopButton() {PanelManager.Instance.OpenPanel(GameConfig.SkinShopPanel_Name);}
    public void OnClickRechargeButton() {PanelManager.Instance.OpenPanel(GameConfig.Recharge_Name);}

}
