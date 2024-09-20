using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    void Start()
    {
        
    }
    public void PlayGame(){SceneManager.LoadScene("GameScene");}
}
