using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trivia : MonoBehaviour
{

    public static List<string> questions = new List<string> {
        "How many voters were purged between 2014 and 2016?",
        "What percent of Georgia Voters purged in 2018 were black?",
        "One in how many Black Americans cannot vote due to disenfranchisement laws?",
        "As of July 2020, about how many states hold their elections entirely by mail?",
        "Which of these states holds their elections almost entirely by mail?",
    };
    public static List<string[]> choices = new List<string[]>{
        new string[] {"a). 1 million", "b). 16 million", "c). 10 million", "d). 15 million"},
        new string[] {"a). 30%", "b). 50%", "c). 90%", "d). 70%"},
        new string[] {"a). 13", "b). 100", "c). 50", "d). 250"},
        new string[] {"a). 5", "b). 0", "c). 25", "d). 1"},
        new string[] {"a). California", "New York", "Colorado", "Florida"}
    };
    public static List<int> answers = new List<int>() {
        1,
        3,
        0,
        0,
        2
    };

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(choices[0][answers[0]]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
