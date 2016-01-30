using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ClockController : MonoBehaviour
{
	private DayNightCycle dayNight;

    public enum ClockType { Analogue, Digital}

    public ClockType clockType = ClockType.Analogue;

    //AN Clock stuff
    public Transform hourHand;
    public Transform minuteHand;

    //Digi Clock stuff
    public Text digitalTime;
    public Text digitalAMPM;


	void Awake()
	{
		dayNight = DayNightCycle.Instance;
	}

	void Update()
	{

        if (clockType == ClockType.Analogue)
        {

            float secondRot = (dayNight.TimeOfDay.Seconds / 60f) * 360f;
            float minuteRot = (dayNight.TimeOfDay.Minutes / 60f) * 360f + secondRot / 60f;
            float hourRot = ((dayNight.TimeOfDay.Hours % 12f) / 12f) * 360f + minuteRot / 12f;

            minuteHand.rotation = Quaternion.Euler(new Vector3(minuteHand.rotation.x, minuteHand.rotation.y, -minuteRot - 90f));
            hourHand.rotation = Quaternion.Euler(new Vector3(hourHand.rotation.x, hourHand.rotation.y, -hourRot - 90f));
        }
        else if (clockType == ClockType.Digital)
        {
            digitalTime.text = new DateTime(dayNight.TimeOfDay.Ticks).ToString("hh:mm"); //  string.Format("{0}:{1}", dayNight., dayNight.TimeOfDay.Minutes);

            if (dayNight.TimeOfDay.Hours > 11)
            {
                //PM
                digitalAMPM.text = "PM";
            }
            else
            {
                digitalAMPM.text = "AM";
            }

        }
    }
}