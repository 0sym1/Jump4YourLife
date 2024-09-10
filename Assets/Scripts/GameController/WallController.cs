using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public static WallController Instance;
    private float boundScreen;
    private float highOfWall;
    [SerializeField] private List<GameObject> walls = new List<GameObject>();
    // Update is called once per frame
    void Awake(){
        Instance = this;
        boundScreen = 6f;
        highOfWall = 10;
    }
    void Update()
    {
        for(int i=0 ; i<3 ; i++){
            if(walls[i].transform.position.y > boundScreen){
                RecyclingWall(walls[i], i);
            }
        }
    }

    public void RecyclingWall(GameObject wall, int i){
        i++;
        i %= 3;
        wall.transform.position = new Vector3(wall.transform.position.x, walls[i].transform.position.y - highOfWall, 0);
    }
    public void PushWall(){
        int step = GameManager.Instance.getAddScore();
        foreach(GameObject wall in walls){
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + 3.5f*step, 0);
        }
    }
}
