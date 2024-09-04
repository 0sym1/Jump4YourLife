using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isJump;
    private Rigidbody2D rg;
    private Animator animator;
    [SerializeField] private float speed;
    
    void Start()
    {
        isJump = false;
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && !isJump){
            Jump();
        }
    }

    public void Jump(){
        isJump = true;
        transform.parent = null;
        rg.velocity = Vector3.up * speed;
        setAnimation();
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            isJump = false;
            //cho player làm con của đất
            // transform.parent = other.transform;
            //update điểm
            updateScore();
        }
        setAnimation();
    }

    public void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            isJump = true;
        }
    }
    public void setAnimation(){
        animator.SetBool("isJump", isJump);
    }
    public void updateScore(){
        int addScore = GameManager.Instance.getAddScore();
        int score = GameManager.Instance.getScore();
        GameManager.Instance.setScore(score + addScore);
        GameManager.Instance.setScoreTxt();

        GameManager.Instance.setAddScore(0);
    }
}
