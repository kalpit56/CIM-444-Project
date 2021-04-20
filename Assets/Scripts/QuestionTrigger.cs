using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{

    public GameObject player;
    public GameObject police;
    public Canvas questionCanvas;
    public Canvas correctAnswer;
    public Text questionText;
    public Button[] choices = new Button[4];
    public static int random = -1;
    public static int score = 0;
    List<int> asked = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        questionCanvas.enabled = false;
        correctAnswer.enabled = false;

        choices[0].onClick.AddListener(() => {
            check(0);
        });
        choices[1].onClick.AddListener(() => {
            check(1);
        });
        choices[2].onClick.AddListener(() => {
            check(2);
        });
        choices[3].onClick.AddListener(() => {
            check(3);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Question"){
            dispalyQuestion();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "PoliceQuestion"){
            dispalyQuestion();
            police.GetComponent<policeMove>().enabled = false;
            police.GetComponent<Animator>().Play("Police1Idle");
            Destroy(collision.gameObject);
            police.SetActive(false);
        }
    }

    public void check(int input){
        if(input == trivia.answers[random]){
            Debug.Log("MADE IT HERE");
            questionCanvas.enabled = false;
            correctAnswer.enabled = true;
            StartCoroutine(correct());
            StopCoroutine(correct());
            player.GetComponent<PlayerMovement>().enabled = true;
            random = -1;
        }
    }


    private IEnumerator correct() {
        yield return new WaitForSeconds(4f);
        Debug.Log("TESTING");
        correctAnswer.enabled = false;
    }

    private void dispalyQuestion(){
        questionCanvas.enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<PlayerMovement>().enabled = false;
        random = Random.Range(0, 4);
        while(asked.Contains(random)){
            random = Random.Range(0, 4);
            if(asked.Count == 5){
                Debug.Log("out of questions");
                break;
            }
        }
        asked.Add(random);
        questionText.text = trivia.questions[random];
        for(int i = 0; i < choices.Length; i++){
            choices[i].GetComponentInChildren<Text>().text = trivia.choices[random][i];
        }
    }
}
