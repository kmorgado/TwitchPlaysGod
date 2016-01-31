using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class Moral : MonoBehaviour {


    static bool shouldShowMoral = true;

    static Timer _timer;
    static Timer _Moraltimer;

    public GameObject parentObject;


    public int numberOfMinPerQuandry = 2;


	// Use this for initialization
	void Start () {

        _timer = new Timer(numberOfMinPerQuandry * 60 * 1000);
        _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        _timer.Enabled = true; // Enable it


        //Morals will last for 30 seconds
        _Moraltimer = new Timer(30000); 
        _Moraltimer.Elapsed += new ElapsedEventHandler(_moralTimer_Elapsed);

	}
	
	// Update is called once per frame
	void Update () {

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
        _Moraltimer.Enabled = true;
        _timer.Stop();

    }

    static void _moralTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        shouldShowMoral = false;
        _timer.Start();
    }
    
}
