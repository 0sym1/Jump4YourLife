using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject lineScore;
    private SkinBackground skinBackground;
    private BoxCollider2D collider2d;
    private BoxCollider2D collider2dLine;
    private SpriteRenderer spriteRenderer;
    private Sprite groundSpriteNormal;
    private Sprite groundSpriteBroken;
    private bool isRight, isCollide;
    private float boundWall;
    private float boundScreen;
    private int type;
    private bool isInvisible;
    private float angle;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
        collider2dLine = lineScore.GetComponent<BoxCollider2D>();
    }

    void Start(){
        //Set sprite
        skinBackground = Resources.Load<SkinBackground>(GameConfig.SkinBackgroundDataResourcePath + PlayerPrefs.GetString(GameConfig.SkinBackgroundCurrent));
        groundSpriteNormal = skinBackground.GetSpriteGroundNormal;
        groundSpriteBroken = skinBackground.GetSpriteGroundBroken;
        spriteRenderer.sprite = groundSpriteNormal;

        //Random cho chạy về trái or phải
        isRight = Random.value > 0.5f;
        isCollide = false;
        boundWall = 1.3f;
        boundScreen = 5;
    }

    void Update()
    {
        if(isRight) transform.position += Vector3.right * speed * Time.deltaTime;
        else transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -boundWall || transform.position.x >= boundWall){
            if(transform.position.x <= -boundWall) transform.position = new Vector3(-boundWall, transform.position.y, transform.position.z);
            else if(transform.position.x >= -boundWall) transform.position = new Vector3(boundWall, transform.position.y, transform.position.z);
            isRight = !isRight;
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
        type = Random.Range(0,4);
        if(GameConfig.TypeGround.normal.Equals(type)){

        }
    }
}
