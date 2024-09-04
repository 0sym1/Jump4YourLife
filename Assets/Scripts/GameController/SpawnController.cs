using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject grounds;
    private ObjectPool objectPool;
    private float point;
    private float distance;
    private GameObject lastGround;
    void Awake(){
        Instance = this;
        objectPool = GetComponent<ObjectPool>();
        point = 0;
        distance = 3.5f;

    }

    void Start(){
        for(int i=1 ; i<=10 ; i++){
            GameObject tmp = objectPool.GetFromPool();
            tmp.transform.position = new Vector3(Random.Range(-1.2f, 1.2f), point, 0);
            tmp.SetActive(true);
            
            point-=distance;
            if(i == 10){
                lastGround = tmp;
            }
        }
    }

    public void RecyclingObject(){
        point = lastGround.transform.position.y;
        point -= distance;
        GameObject tmp = objectPool.GetFromPool();
        tmp.transform.position = new Vector3(Random.Range(-1.2f, 1.2f), point, 0);
        tmp.transform.parent = grounds.transform;
        tmp.SetActive(true);

        lastGround = tmp;
    }

}