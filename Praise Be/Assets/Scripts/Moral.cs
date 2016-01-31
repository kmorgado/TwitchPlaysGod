using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine.UI;

public class Moral : MonoBehaviour {


    static bool shouldShowMoral = false;
    static bool newMoral = false;

    static Timer _timer;
    static Timer _Moraltimer;

    public GameObject parentObject;
    public Text moralQuestion;
    public Text moralTimerText;

    private static float timerDuration = 45;

    public int numberOfMinPerQuandry = 2;


    private List<string> MoralQuandries = new List<string>();


	// Use this for initialization
	void Start () {


        MoralQuandries.Add("You’re headed to a very important meeting when you see a nearsighted old lady struggling to cross the street. Do you stop and help, even though it might cost you your job?");
        MoralQuandries.Add("You’re about to get your 8-year-old daughter the toy chemistry set she’s wanted for weeks, but at the store, she suddenly decides she wants a big stuffed bear instead. Do you buy her the bear?");
        MoralQuandries.Add("There is a button and if you push it there is a 95% chance all suffering on earth will instantly cease and we would live in a utopian world but there is a 5% chance everyone in earth will die painfully? Do you hit the button?");
        MoralQuandries.Add("Your best friend commits a serious felony, and you know they had no justification. Do you turn in your friend?");
        MoralQuandries.Add("You're a doctor. You've pledged an oath to save lives. The man who killed your daughter was in a horrible car accident and is going to die without medical attention. You are the only one who can provide it. Will you save this man?");
        MoralQuandries.Add("You have cheated Death. You are told that you have to kill someone. You either kill someone you love dearly, and NO ONE will ever know you did it. OR you must publicly execute a complete stranger, whom Death chooses. Do you kill the stanger?");
        //parentObject.SetActive(false);

        _timer = new Timer(numberOfMinPerQuandry * 60 * 1000);
        _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        _timer.AutoReset = true;
        _timer.Enabled = true; // Enable it

        //Morals will last for 45 seconds
        _Moraltimer = new Timer(45000); 
        _Moraltimer.Elapsed += new ElapsedEventHandler(_moralTimer_Elapsed);

	}
	
	// Update is called once per frame
	void Update () {

        moralTimerText.text = timerDuration.ToString("0");
        timerDuration -= Time.deltaTime;

        if (newMoral)
        {
            moralQuestion.text = MoralQuandries[Random.Range(0, MoralQuandries.Count)];
            newMoral = false;
        }

        if (shouldShowMoral)
        {
            parentObject.SetActive(true);
        }
        else
        {
            parentObject.SetActive(false);
        }

	}


    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        shouldShowMoral = true;
        newMoral = true;
        _Moraltimer.Enabled = true;
        timerDuration = 45;
        //_timer.Stop();
    }

    static void _moralTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        shouldShowMoral = false;
        //_timer.Start();
    }
    
}
