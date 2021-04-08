using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject groundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(player.transform.position.x > groundPrefab.transform.position.x - 10){
            GameObject gameObject = Instantiate(groundPrefab, this.transform.position, groundPrefab.transform.rotation);
            groundPrefab = gameObject;
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag == "GroundSpawn"){
            Debug.Log("ENTER");
            GameObject gameObject = Instantiate(groundPrefab, this.transform.position, groundPrefab.transform.rotation);
        }
        //groundPrefab = gameObject;
    }
}
