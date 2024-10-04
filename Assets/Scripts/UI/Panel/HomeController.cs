using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : Panel
{
    private void Start()
    {
        panelName = "HomePanel"; 
    }
    public void PlayGame(){SceneManager.LoadScene("GameScene");}
    public void OnClickSettingButton() {PanelManager.Instance.OpenPanel(GameConfig.SettingPanel_Name);}
    public void OnClickShopButton() {PanelManager.Instance.OpenPanel(GameConfig.SkinShopPanel_Name);}
    public void OnClickRechargeButton() {PanelManager.Instance.OpenPanel(GameConfig.Recharge_Name);}

}
