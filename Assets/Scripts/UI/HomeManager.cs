using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject skinShopPanel;
    void Start()
    {
        
    }
    public void PlayGame(){SceneManager.LoadScene("GameScene");}
    public void OpenSetting(){settingPanel.SetActive(true);}
    // public void CloseSetting(){settingPanel.SetActive(false);}
    public void OpenSkinShop(){skinShopPanel.SetActive(true);}
    // public void CloseSkinShop(){skinShopPanel.SetActive(false);}
}
