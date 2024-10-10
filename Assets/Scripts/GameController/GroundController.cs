using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.WSA;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject lineScore;
    private SkinBackground skinBackground;
    private BoxCollider2D collider2d;
    private SpriteRenderer spriteRenderer;
    private Sprite groundSpriteNormal;
    private Sprite groundSpriteBroken;
    private bool isRight, isCollide;
    private float boundWall;
    private float boundScreen;
    private int type;
    [SerializeField] private float angle;
    [SerializeField] private float speedInvisible;
    private bool isUp; // dùng cho đi chéo
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void Start(){
        //Set sprite
        skinBackground = Resources.Load<SkinBackground>(GameConfig.SkinBackgroundDataResourcePath + PlayerPrefs.GetString(GameConfig.SkinBackgroundCurrent));
        groundSpriteNormal = skinBackground.GetSpriteGroundNormal;
        groundSpriteBroken = skinBackground.GetSpriteGroundBroken;
        spriteRenderer.sprite = groundSpriteNormal;

        //Random cho chạy về trái or phải
        isRight = UnityEngine.Random.value > 0.5f;
        isUp = true;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        isCollide = false;
        boundWall = 1.6f;
        boundScreen = 5;

        Classify();
    }

    private void Update()
    {
        if((int)GameConfig.TypeGround.diagonal == type) GoDiagonal();
        else if((int)GameConfig.TypeGround.invisible == type){Blur();}

        if(isRight) transform.position += Vector3.right * speed * Time.deltaTime;
        else transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -boundWall || transform.position.x >= boundWall){
            if(transform.position.x <= -boundWall) transform.position = new Vector3(-boundWall, transform.position.y, transform.position.z);
            else if(transform.position.x >= -boundWall) transform.position = new Vector3(boundWall, transform.position.y, transform.position.z);
            isRight = !isRight;
            isUp = !isUp;
            //update sprite
            UpdateSprite();
        }
        // xoa cac obj bi out ra khoi man hinh va them obj o duoi
        if(transform.position.y > boundScreen){
            gameObject.SetActive(false);
            Reset();
            // them obj
            SpawnController.Instance.RecyclingObject();
        }
    }

    private void GoDiagonal(){
        if(isUp) transform.position += Vector3.up * angle * Time.deltaTime;
        else transform.position += Vector3.down * angle * Time.deltaTime;
    }
    private void Blur(){
        Color color = spriteRenderer.color;
        if(spriteRenderer.color.a >= 1f ) speedInvisible = -Math.Abs(speedInvisible);
        else if(spriteRenderer.color.a <= 0f) speedInvisible = Math.Abs(speedInvisible);
        color.a += speedInvisible * Time.deltaTime;
        spriteRenderer.color = color;
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            isCollide = true;
            PlayerController.Instance.transform.parent = transform;
            //day mat dat len
            StartCoroutine(GameManager.Instance.PushGrounds());
            //push wall up
            StartCoroutine(GameManager.Instance.PushWall());
        }
    }

    public void OnCollisionExit2D(Collision2D collision){
        if(isCollide){
            collider2d.isTrigger = true;
        }
    }
    public void Reset(){
        isCollide = false;
        collider2d.isTrigger = false;
        spriteRenderer.sprite = groundSpriteNormal;
        lineScore.SetActive(true);
    }
    public void UpdateSprite(){
        if(isCollide){
            if(spriteRenderer.sprite == groundSpriteNormal) spriteRenderer.sprite = groundSpriteBroken;
            else{
                PlayerController.Instance.transform.SetParent(null);
                gameObject.SetActive(false);
                Reset();
                SpawnController.Instance.RecyclingObject();
            }
        }
    }
    
    public void Classify(){
        type = UnityEngine.Random.Range(0,5);
        if((int)GameConfig.TypeGround.normal == type){
            Debug.Log("normal");
        }
        else if((int)GameConfig.TypeGround.fast == type){
            speed = 3f;
            Debug.Log("fast");
        }
        else if((int)GameConfig.TypeGround.small == type){
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            Debug.Log("small");
        }
        else if((int)GameConfig.TypeGround.diagonal == type){
            angle = 1f;
            Debug.Log("diagonal");
        }
        else if((int)GameConfig.TypeGround.invisible == type){
            Debug.Log("invisible");
        }
    }
}
