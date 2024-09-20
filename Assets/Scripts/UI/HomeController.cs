using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : Panel
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject skinShopPanel;
    [SerializeField] private GameObject blockAdsPanel;
    private void Start()
    {
        panelName = "HomePanel"; 
    }
}
