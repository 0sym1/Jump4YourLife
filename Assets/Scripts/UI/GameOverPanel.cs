using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameOverPanel : Panel
{
    [FormerlySerializedAs("score")]
    [SerializeField] private TextMeshProUGUI scoreTxt;

    private void Start(){
        scoreTxt.text = "0";
    }

    public void Setup(int score)
    {
        scoreTxt.text = score.ToString();
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
