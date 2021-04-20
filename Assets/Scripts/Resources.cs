using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Resources : MonoBehaviour
{

    public Button rockTheVote;
    public Button registerToVote;
    public Button whenWeAllVote;
    public Button startOver;

    // Start is called before the first frame update
    void Start()
    {
        rockTheVote.onClick.AddListener(() => {
            Application.OpenURL("https://www.rockthevote.org/");
        });

        registerToVote.onClick.AddListener(() => {
            Application.OpenURL("https://www.vote.org/");
        });

        whenWeAllVote.onClick.AddListener(() => {
            Application.OpenURL("https://www.whenweallvote.org/volunteer/");
        });

        startOver.onClick.AddListener(() => {
            SceneManager.LoadScene("Start");
        });
    }
}
