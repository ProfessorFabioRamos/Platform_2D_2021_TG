using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spr;
    public float jumpForce = 6;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if(h>0)Flip(true);
        else if(h<0)Flip(false);

        rig.velocity = new Vector2(h*moveSpeed, rig.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(h));

        bool grounded = Physics2D.OverlapCircle(transform.position, 0.2f, whatIsGround);

        anim.SetBool("grounded", grounded);
        Debug.Log(grounded);

        if(Input.GetButtonDown("Jump") && grounded){
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Flip(bool faceRight){
        spr.flipX = !faceRight;
    }
}
