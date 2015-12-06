using UnityEngine;
using Random=UnityEngine.Random;
using System.Collections;
using System;

public class SimpleMouthMovement : MonoBehaviour {
	/// Set to true to start random lip movement
	public Boolean talking = false; 


	[SerializeField] private Transform jaw;
	[SerializeField] private float jawRestPosition = 0;
	[SerializeField] private float jawFullOpenPosition = -11;
	
	private bool mouthMoving = false;
	private bool mouthClosing = false;

		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(talking){
			if(!mouthMoving){
				// We're in 'talking' mode, so move the jaw to random positions when not moving already
				float distance = Random.Range(jawRestPosition, jawFullOpenPosition);
				StartCoroutine(MoveJaw(distance, Random.Range(.05f, .5f)));					
			}
		}
		else if (!mouthMoving && jaw.transform.localRotation.z != jawRestPosition) {
			mouthClosing = true;
			// So that the avatar doesn't look like an idiot with his mouth open
			StartCoroutine(CloseJaw(.5f));
		}
	}
	
	IEnumerator MoveJaw (float newRotation, float time)
 	{
		mouthMoving = true;
     	float elapsedTime = 0;
     	float startingRotation = jaw.transform.localRotation.z;
     	while (elapsedTime < time)
     	{
			float z = Mathf.Lerp(startingRotation, newRotation, (elapsedTime / time));
			jaw.transform.localRotation = Quaternion.Euler(0, 0, z); 
			//new Vector3(jaw.transform.localPosition.x, jaw.transform.localPosition.y, z);
         	elapsedTime += Time.deltaTime;
         	yield return new WaitForEndOfFrame();
     	}
		mouthMoving = false;
	 }
	 
	 IEnumerator CloseJaw(float time){

		 yield return StartCoroutine(MoveJaw(jawRestPosition, time));
		 mouthClosing = false;	
	 }
}
