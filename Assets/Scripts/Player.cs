using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public bool end = false;
    public Text scoreText;
    public AudioSource getCoinAudio;
    public int damaged = 3;
    float time;
    bool coll = false;
    float remTime = .35f, normalRemTime = .35f;
    public bool enterBossRoom = false;

    // Movement
    public float speed = 3;
    public float jump = 350;
    public bool grounded = false;
    public Vector2 moveRight = Vector2.right;

    // Get Object
    public Rigidbody2D rb2d;
    public Rigidbody2D rb2dCamera;
    public GameObject gameOverUI;
    public AI ai;
    public bool gameOver;

    // Scores
    public int count;

    // pauseMenu
    public PauseMenu pauseMenu;

    // tobecontinued
    public GameObject toBeContinuedUI;

    // Projectiles
    public bool bossShoot = false;
    public Rigidbody2D projectile;
    public int projectileSpeed = -5;
  
	// Use this for initialization
	void Start () {
        speed = 3;
        end = false;
        bossShoot = false;
        rb2d = GetComponent<Rigidbody2D>();
        pauseMenu = GetComponent<PauseMenu>();

        toBeContinuedUI.SetActive(false);
        gameOver = false;
        count = 0;
        setCountText();
    }
	
	// Update is called once per frame
	void Update () {

        if (remTime == normalRemTime) time = Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(Vector2.up * jump);
            grounded = false;
        }

        // pas nabrak
        if (coll == true)
        {
            time = 0;
            remTime -= Time.deltaTime;
            if (remTime <= 0)
            {
                remTime = normalRemTime;
                coll = false;
            }
        }

        if (damaged == 0)
        {
            time = 0;
        }

        transform.Translate(moveRight * speed * time);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {

        if (collision.gameObject.CompareTag("chair"))
        {
            coll = true;
            damaged -= 1;
        }

        
        if (collision.gameObject.CompareTag("coin"))
        {
            getCoinAudio.Play();
            collision.gameObject.SetActive(false);
            count += 10;
            setCountText();
        }

        if (collision.gameObject.CompareTag("PlayerStop"))
        {
            speed = 0;
            enterBossRoom = true;
            bossShoot = true;
            toBeContinuedUI.SetActive(true);

        }
    }

    public void GameOver(bool end)
    {
        gameOverUI.active = true;
        Time.timeScale = 0;
    }

    void setCountText()
    {
        scoreText.text = count.ToString();
    }
}
