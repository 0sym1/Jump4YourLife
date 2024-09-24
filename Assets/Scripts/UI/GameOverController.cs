using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : Panel
{
    [SerializeField] private TextMeshProUGUI score;

    private void Start(){
        score.text = "0";
    }    
    public void Restart(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }
    public void BackHome(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("HomeScene");
    }
}
