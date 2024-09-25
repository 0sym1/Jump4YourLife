using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : Panel
{
    private void OnEnable(){
        Time.timeScale = 0;
    }
    private void OnDisable(){
        Time.timeScale = 1;
    }
    public void Restart(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GameConfig.GameScene);
    }
    public void BackHome(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GameConfig.HomeScene);
    }
}
