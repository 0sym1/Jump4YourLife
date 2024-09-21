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
}
