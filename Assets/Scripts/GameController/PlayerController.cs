using System.Collections;
using System.Collections.Generic;
using Common;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    // Start is called before the first frame update
    private bool isJump;
    private Rigidbody2D rg;
    private Animator animator;
    private float boundScreen;
    [SerializeField] private float speed;

    private bool isDead;

    void Awake()
    {
        Instance = this;
        boundScreen = -5.5f;
        isJump = false;
        isDead = false;
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Utils.IsMouseOverUI() && !isJump) //TODO check co dang click vao UI khong?
        {
            //tat instruct
            GameManager.Instance.setFalseInstructNoti();
            Jump();
        }
        if(!isDead){
            CheckOutScreen();
        }
    }
    public void setIsJump(bool isJump)
    {
        this.isJump = isJump;
    }
    public void Jump()
    {
        isJump = true;
        transform.parent = null;
        rg.velocity = Vector3.up * speed;
        setAnimation();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //update điểm
            GameManager.Instance.UpdateScore();
            isJump = false;
        }
        setAnimation();
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJump = true;
        }
    }
    public void setAnimation()
    {
        animator.SetBool("isJump", isJump);
    }
    // sau update obsever
    public void CheckOutScreen()
    {
        if (transform.position.y <= boundScreen)
        {
            Messenger.Broadcast(EventKey.GAME_OVER);
            isDead = true;
        }
    }
}
