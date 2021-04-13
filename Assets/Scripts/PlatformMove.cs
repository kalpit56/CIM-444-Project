using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    float speed = 1.5f;
    float position;
    bool up;
    float direction;
    public float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        //platform = this;
        position = this.transform.position.y;
        up = true;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > position + distance) {
            direction = -1;
        } else if(this.transform.position.y < position){
            direction = 1;
        }
        
        this.transform.position += new Vector3(0, direction * speed, 0) * Time.deltaTime;
    }
}
