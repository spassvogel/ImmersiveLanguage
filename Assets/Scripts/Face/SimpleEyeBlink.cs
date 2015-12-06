using UnityEngine;
using System.Collections;

public class SimpleEyeBlink : MonoBehaviour {

	[SerializeField]	private Transform leftEyelidUp;
	[SerializeField]	private Transform leftEyelidDown;
	[SerializeField]	private Transform rightEyelidUp;
	[SerializeField]	private Transform rightEyelidDown;
	
	[SerializeField]	private Vector3 openRotationUp;
	[SerializeField]	private Vector3 closedRotationUp;
	[SerializeField]	private Vector3 openRotationDown;
	[SerializeField]	private Vector3 closedRotationDown;

    [Tooltip("Time in seconds that the eyes will be closed during a blink")]
	[SerializeField]	private float blinkDuration = .1f;	
	
    [Tooltip("Minimum frequency of blink")]
	[SerializeField]	private float minBlinkDelay = 2;
    [Tooltip("Maximum frequency of blink")]
	[SerializeField]	private float maxBlinkDelay = 4;
	
	private bool eyesClosed = true;
	private float nextBlink;

	// Use this for initialization
	void Start () {
		OpenEyes();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextBlink){
			eyesClosed = true;
			Invoke("OpenEyes", blinkDuration);
		}
		
		if(eyesClosed){
			leftEyelidDown.transform.localRotation = Quaternion.Euler(closedRotationDown);
			rightEyelidDown.transform.localRotation = Quaternion.Euler(closedRotationDown);
			leftEyelidUp.transform.localRotation = Quaternion.Euler(closedRotationUp);
			rightEyelidUp.transform.localRotation = Quaternion.Euler(closedRotationUp);
		}
		else {
			leftEyelidDown.transform.localRotation = Quaternion.Euler(openRotationDown);
			rightEyelidDown.transform.localRotation = Quaternion.Euler(openRotationDown);
			leftEyelidUp.transform.localRotation = Quaternion.Euler(openRotationUp);
			rightEyelidUp.transform.localRotation = Quaternion.Euler(openRotationUp);			
		}
	}
	
	private void OpenEyes(){
		nextBlink = Time.time + Random.Range(minBlinkDelay, maxBlinkDelay);
		eyesClosed = false;
	}
}
