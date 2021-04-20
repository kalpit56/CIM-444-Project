using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneMovement : MonoBehaviour
{
    public Button start;
    public Button learnMore;

    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(() => {
            SceneManager.LoadScene("Main");
        });

        learnMore.onClick.AddListener(() => {
            Application.OpenURL("https://www.aclu.org/issues/voting-rights/fighting-voter-suppression");
        });
    }
}
