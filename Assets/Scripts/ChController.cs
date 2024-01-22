using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChController : MonoBehaviour
{
    private float JumpForce = 10.0f;
    private float Speed = 1f;
    private float MoveDirection;
    private SpriteRenderer Spriterend;

    bool jump;
    bool grounded = true;
    bool moving;

    Rigidbody2D RB2D;
    Animator anim;

    PhotonView view;
    private void Awake()
    {
        anim = GetComponent<Animator>();  // caching
    }

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        Spriterend = GetComponent<SpriteRenderer>();
        view = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            if (RB2D.velocity != Vector2.zero)
            {
                moving = true;
            }
            else
            {
                moving = false;
            }

            //hareket
            RB2D.velocity = new Vector2(Speed * MoveDirection, RB2D.velocity.y);

            //zýplama
            if (jump == true)
            {
                RB2D.velocity = new Vector2(RB2D.velocity.x, JumpForce);
                jump = false;
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            RB2D.velocity = new Vector2(Speed * MoveDirection, RB2D.velocity.y);
            if (grounded == true && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            { 
                if (Input.GetKey(KeyCode.A))
                {
                    MoveDirection = -1f;
                    anim.SetFloat("speed", 1f);
                    Spriterend.flipX = true;
                    Speed = 1f;
                }
               
                if (Input.GetKey(KeyCode.D))
                {
                    MoveDirection = 1f;
                    anim.SetFloat("speed", 1f);
                    Spriterend.flipX = false;
                    Speed = 1f;
                }
            }

            // tuþa basýlmýyorsa animasyonu durdur
            else if (grounded == true)
            {
                MoveDirection = 0f;
                anim.SetFloat("speed", 0f);
            }

            //zýpla

            if (grounded == true && Input.GetKey(KeyCode.W))
            {
                jump = true;
                grounded = false;
                anim.SetTrigger("jump");
                anim.SetBool("Grounded", false);
            }          
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin") || other.gameObject.CompareTag("Karakter"))
        {
            anim.SetBool("Grounded", true);
            grounded = true;
        }
    }
}
