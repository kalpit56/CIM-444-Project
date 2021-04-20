using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3.0f;
    float jumpForce = 5;
    Animator anim;
    public GameObject player;
    public GameObject groundPrefab;
    float count = 1;
    int index;
    public Text factText;
    string[] waitTimeFacts = new string[4];
    double[] waitTimes = {11.6, 15.4, 18.7, 23.3};
    string[] race = {"a white", "an asian", "a hispanic", "a black"};
    public Camera myCamera;
    bool jumping;
    public GameObject police;
    public GameObject cloudPrefab;
    //public GameObject questionCanvas;
    //public Text questionText;
    //GameObject gameObject;
    //SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //police.SetActive(false);
        //questionCanvas.active = false;
        anim = GetComponent<Animator>();
        //gameObject = GameObject.Find("onColMovePlatform");
        //spriteRenderer = GetComponent<SpriteRenderer>();
        index = -1;

        for(int i = 0; i < waitTimeFacts.Length; i++){
            waitTimeFacts[i] = "In the 2012 election, the average wait time for " + race[i] + " voter was " + waitTimes[i] + " minutes.";
        }

        jumping = false;
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

       if(Input.GetKeyDown(KeyCode.Space) && !jumping) {
           GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
           anim.Play("Jump");
           jumping = true;
       }

       GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision){
        
        jumping = false;
        if(collision.gameObject.tag == "GroundSpawn"){
            count++;
            GameObject gameObject = Instantiate(groundPrefab, new Vector3((count * 11.98f), -1.75f, 0), groundPrefab.transform.rotation);
            GameObject gameObject2 = Instantiate(cloudPrefab, new Vector3((count * 25f), 10f, -835f), cloudPrefab.transform.rotation);
        }

        if(collision.gameObject.tag == "Platform"){
            this.transform.parent = collision.transform;
            if(collision.gameObject.GetComponent<PlatformMove>().enabled == false){
                collision.gameObject.GetComponent<PlatformMove>().enabled = true;
            }
        }

        if(collision.gameObject.tag == "Fact"){
            Debug.Log("ONE");
            index++;
            factText.text = waitTimeFacts[index];
            StartCoroutine(display());
            StopCoroutine(display());
            StartCoroutine(spanOut());
            StopCoroutine(spanOut());
            //StartCoroutine(wait());
            //StopCoroutine(wait());
            //spanIn();
        }

        if(collision.gameObject.tag == "PoliceShoot"){
            police.SetActive(true);
        }

        if(collision.gameObject.tag == "VotingCenter"){
            SceneManager.LoadScene("End");
        }

        /*if(collision.gameObject.tag == "Question"){
            questionCanvas.active = true;
            int random = Random.Range(0, 4);
            questionText.text = trivia.questions[random];
        }*/
        //groundPrefab = gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collider){
        jumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Platform"){
            this.transform.parent = null;
        }

        /*if(collision.gameObject.tag == "Fact"){
            Debug.Log("TEST");
            factText.text = "";
            StartCoroutine(spanIn());
            StopCoroutine(spanIn());
        }*/
    }

   

    private IEnumerator spanIn(){
        while(myCamera.orthographicSize > 6){
            //if(){
                myCamera.orthographicSize -= 0.025f;
                myCamera.transform.position += new Vector3(0, 3.5f, 0) * Time.deltaTime;
            //}
            yield return new WaitForSeconds(0.01f);
        }
    }


    private IEnumerator spanOut() {
        while(myCamera.orthographicSize < 8) {
            //if(){
                myCamera.orthographicSize += 0.01f;
                myCamera.transform.position += new Vector3(0, -2f, 0) * Time.deltaTime;
            //}
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator wait(){
        yield return new WaitForSeconds(5f);
    }

    private IEnumerator display(){
        yield return new WaitForSeconds(5f);
        factText.text = "";
        StartCoroutine(spanIn());
        StopCoroutine(spanIn());
    }
}
