using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public static float speed = 3;
    public float jump = 350;
    public Vector2 moveRight = Vector2.right;
    public Rigidbody2D rb2d;
    private Player player;
    public GameObject gameOverUI;


    public GameObject GameObject;
    public bool end = false;

    // Use this for initialization
    void Start()
    {
        // speed dan jump sama dengan player
        speed = 3;
        jump = 350;
        end = false;
        rb2d = GetComponent<Rigidbody2D>();
        GameObject = GetComponent<GameObject>();
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // AI gerak ke kanan
        transform.Translate(moveRight * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika AI Nabrak Player
        if (collision.transform.gameObject.name == "Player")
        {
            speed = 0;
            jump = 0;
            end = true;
            player.GameOver(end);
            gameOverUI.active = true;
            //Application.LoadLevel(Application.loadedLevel);
        }
    }

    // AI Lompat dan Berhenti pas ada Bos
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AIJump"))
        {
            rb2d.AddForce(Vector2.up * jump);
        }

        if (collision.gameObject.CompareTag("AIStop"))
        {
            speed = 0;
        }
    }
    
}