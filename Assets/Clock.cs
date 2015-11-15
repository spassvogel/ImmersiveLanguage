using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	[SerializeField]
	private Transform minutes;
	[SerializeField]
	private Transform hours;

    //[SerializeField]
	//private float timeModifier = 1;

    private const float hoursToDegrees = 360f / 12f;
    private const float minutesToDegrees = 360f / 60f;
	

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan timespan = DateTime.Now.TimeOfDay;// + DateTime.Now.AddMinutes(Time.frameCount).TimeOfDay;
        hours.localRotation = Quaternion.Euler(0f, (float)timespan.TotalHours * -hoursToDegrees,0f );
        minutes.localRotation = Quaternion.Euler(0f, (float)timespan.TotalMinutes * -minutesToDegrees, 0f);
	}
}
