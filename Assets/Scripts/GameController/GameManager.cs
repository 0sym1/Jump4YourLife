using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject grounds;
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject perfecrImg;
    [SerializeField] private GameObject instructNoti;
    [SerializeField] private Image backgroundImg;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private float speedUp;
    private SkinBackground skinBackground;
    private int highScore;
    private int score;
    private int addScore;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }
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
        skinBackground = Resources.Load<SkinBackground>(GameConfig.SkinBackgroundDataResourcePath + PlayerPrefs.GetString(GameConfig.SkinBackgroundCurrent));
        SetSpriteSkinTheme();
        perfecrImg.SetActive(false);
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
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
        PlayerPrefs.SetInt("HighScore", highScore);

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
    public void setFalseInstructNoti(){
        instructNoti.SetActive(false);
    }
    public void PerfectNoti(){
        perfecrImg.SetActive(true);
        StartCoroutine(Delay());
    }
    public void GameOver(){
        // hien len bang thong bao
        PanelManager.Instance.OpenPanel(GameConfig.GameOverPanel_Name);
        Time.timeScale = 0;
    }

    private void SetSpriteSkinTheme(){
        backgroundImg.sprite = skinBackground.GetImageBG;
    }
    public IEnumerator Delay(){
        yield return new WaitForSeconds(2f);
        perfecrImg.SetActive(false);
    }
}
