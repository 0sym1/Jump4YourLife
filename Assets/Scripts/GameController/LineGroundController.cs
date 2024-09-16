using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGroundController : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private void Awake(){
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            //check perfect
            CheckPerfect();
            //add score
            AddScore();

            gameObject.SetActive(false);
        }
    }

    public void AddScore(){
        int addScore = GameManager.Instance.AddScore + 1;
        GameManager.Instance.AddScore = addScore;
    }
    public void CheckPerfect(){
        if(Math.Abs(PlayerController.Instance.transform.position.x - boxCollider2D.transform.position.x) <= 0.5f){
            Messenger.Broadcast(EventKey.PERFECT);
        }
    }
}
