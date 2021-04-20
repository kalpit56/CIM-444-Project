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
        "After record voter turn out in the Election of 2008, how many states introduced voter suppression legislation?",
        "Which of these is a method of voter suppression?"
    };
    public static List<string[]> choices = new List<string[]>{
        new string[] {"a). 1 million", "b). 16 million", "c). 10 million", "d). 15 million"},
        new string[] {"a). 30%", "b). 50%", "c). 90%", "d). 70%"},
        new string[] {"a). 13", "b). 100", "c). 50", "d). 250"},
        new string[] {"a). 5", "b). 0", "c). 25", "d). 1"},
        new string[] {"a). California", "b). New York", "c). Colorado", "d). Florida"},
        new string[] {"a). 16", "b). 30", "c). 5", "d). 10"},
        new string[] {"a). allowing mail in voting", "b). sending ballots to citizens", "c). enacting stricter ID requirements", "d). setting up more polls"},
    };
    public static List<int> answers = new List<int>() {
        1,
        3,
        0,
        0,
        2,
        1,
        2
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
