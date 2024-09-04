using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGroundController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            int addScore = GameManager.Instance.getAddScore() + 1;
            GameManager.Instance.setAddScore(addScore);

            gameObject.SetActive(false);
        }
    }
}
