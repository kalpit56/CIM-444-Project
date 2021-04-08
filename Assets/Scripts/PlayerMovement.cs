using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3.0f;
    Animator anim;
    //SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       float move = Input.GetAxis("Horizontal");
       //Debug.Log(move);

       if(move > 0){
           //spriteRenderer.flipX = false;
           //anim.SetBool("Walking", true);
           anim.Play("Walk");
       } 
       if(move < 0){
           //anim.SetBool("Walking", false);
           //spriteRenderer.flipX = true;
           anim.Play("WalkLeft");
       } 
       if(move == 0){
           //spriteRenderer.flipX = false;
           anim.Play("Idle");
       }

       GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
