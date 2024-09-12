using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject grounds;
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject PerfecrImg;

    private int highScore;
    private int score;
    private int addScore;
    [SerializeField] private float speedUp;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        score = 0;

    }

    void OnEnable(){
        Messenger.AddListener(EventKey.GAME_OVER, GameOver);
        Messenger.AddListener(EventKey.PERFECT, PerfectNoti);
        
    }

    void OnDisable() {
        Messenger.RemoveListener(EventKey.GAME_OVER, GameOver);
        Messenger.RemoveListener(EventKey.PERFECT, PerfectNoti);
    }
    void Start(){
        gameOverPanel.SetActive(false);
        PerfecrImg.SetActive(false);
    }

    public int getScore(){ return score;}
    public int getAddScore(){ return addScore;}
    public void setAddScore(int addScore){
        this.addScore = addScore;
    }
    public void UpdateScore(){
        score += addScore;
        scoreTxt.text = score.ToString();
        highScore = Math.Max(highScore, score);

        addScore = 0;
    }
    public void setScoreTxt(){
        scoreTxt.text = score.ToString(); 
    }

    public IEnumerator PushGrounds(){
        int step = addScore;
        Vector3 positionTarget = new Vector3(grounds.transform.position.x, grounds.transform.position.y + 3.5f*step, 0);
        while(grounds.transform.position != positionTarget){
            grounds.transform.position = Vector3.MoveTowards(grounds.transform.position, positionTarget, speedUp * Time.deltaTime);
            yield return null;
        }
        // dat lai isJump cho player co the nhay tiep
        PlayerController.Instance.setIsJump(false);
    }

    public IEnumerator PushWall(){
        int step = addScore;
        Vector3 positionTarget = new Vector3(walls.transform.position.x, walls.transform.position.y + 3.5f*step, 0);
        while(walls.transform.position != positionTarget){
            walls.transform.position = Vector3.MoveTowards(walls.transform.position, positionTarget, speedUp * Time.deltaTime);
            yield return null;
        }
    }
    public void PerfectNoti(){
        PerfecrImg.SetActive(true);
        StartCoroutine(Delay());
        
    }
    public void GameOver(){
        Time.timeScale = 0;
        // hien len bang thong bao
        gameOverPanel.SetActive(true);
    }
    public void ReplayGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void BackHome(){
        Time.timeScale = 1f; 
        SceneManager.LoadScene("HomeScene");
    }

    public IEnumerator Delay(){
        yield return new WaitForSeconds(2f);
        PerfecrImg.SetActive(false);
    }
}
