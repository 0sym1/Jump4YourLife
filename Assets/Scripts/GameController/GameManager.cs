using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject grounds;

    private int highScore;
    private int score;
    private int addScore;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    void Awake(){
        Instance = this;
        score = 0;
    }

    public int getScore(){ return score;}
    public int getAddScore(){ return addScore;}
    public void setAddScore(int addScore){
        this.addScore = addScore;
    }
    public void setScore(int score){
        this.score = score;
    }
    public void setScoreTxt(){
        scoreTxt.text = score.ToString(); 
    }

    public void PushGrounds(){
        int step = addScore;
        Debug.Log(step + "ok");
        grounds.transform.position = new Vector3(grounds.transform.position.x, grounds.transform.position.y + 3.5f*step, 0);
    }
}
