using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3.0f;
    float jumpForce = 5;
    Animator anim;
    public GameObject player;
    public GameObject groundPrefab;
    float count = 1;
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

       if(Input.GetKeyDown(KeyCode.Space)) {
           GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
           anim.Play("Jump");
       }

       GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision){
    
        if(collision.gameObject.tag == "GroundSpawn"){
            //Debug.Log("ENTER");
            count++;
            GameObject gameObject = Instantiate(groundPrefab, new Vector3((count * 11.98f), -1.75f, 0), groundPrefab.transform.rotation);
        }
        //groundPrefab = gameObject;
    }
}
