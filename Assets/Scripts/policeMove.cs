using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeMove : MonoBehaviour
{

    public GameObject police;
    public float speed = 2f;
    float position;
    float direction;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position.x;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > position + distance) {
            direction = -1;
            police.GetComponent<SpriteRenderer>().flipX = true;
        } else if(this.transform.position.x < position){
            direction = 1;
            police.GetComponent<SpriteRenderer>().flipX = false;
        }

        this.transform.position += new Vector3(direction * speed, 0, 0) * Time.deltaTime;
    }
}
