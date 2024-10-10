using System.Collections;
using System.Collections.Generic;
using Common;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private float speed;
    private GameObject skinPrefab;
    private GameObject skinObject;
    private bool isJump;
    private Rigidbody2D rg;
    private Animator animator;
    private float boundScreen;
    private bool isDead;

    private void Awake()
    {
        Instance = this;
        rg = GetComponent<Rigidbody2D>();
        skinPrefab = Resources.Load<GameObject>(GameConfig.SkinPlayerPrefabs + PlayerPrefs.GetString(GameConfig.SkinPlayerCurrent));
    }

    private void Start(){
        skinObject = Instantiate(skinPrefab, transform);
        animator = skinObject.GetComponent<Animator>();

        boundScreen = -5.5f;
        isJump = false;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isJump && !Utils.IsMouseOverUI())
        {
            //turn off instruct
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
        if (other.gameObject.CompareTag("Ground"))
        {
            //update điểm
            GameManager.Instance.UpdateScore();
            // StartCoroutine(DelayJump());
            isJump = false;
        }
        setAnimation();
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }
    public void setAnimation()
    {
        animator.SetBool("isJump", isJump);
    }
    
    public void CheckOutScreen()
    {
        if (transform.position.y <= boundScreen)
        {
            Messenger.Broadcast(EventKey.GAME_OVER);
            isDead = true;
        }
    }

    // anti spam
    private IEnumerator DelayJump(){
        yield return new WaitForSeconds(0.1f);
    }
}