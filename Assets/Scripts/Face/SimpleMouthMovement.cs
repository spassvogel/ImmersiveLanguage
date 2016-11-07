using UnityEngine;
using Random=UnityEngine.Random;
using System.Collections;
using System;

public class SimpleMouthMovement : MonoBehaviour {
	/// Set to true to start random lip movement
	public Boolean talking = false; 


	[SerializeField] private Transform jaw;
	[SerializeField] private Transform upperLip;
		
	[SerializeField] private float jawRestPosition = 0;
	[SerializeField] private float jawFullOpenPosition = -11;
	[SerializeField] private float upperLipRestPosition = 0.01495764f;
	[SerializeField] private float upperLipOpenPosition = 0.0115f;
	
	private bool mouthMoving = false;
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(talking){
			if(!mouthMoving){
				// We're in 'talking' mode, so move the jaw to random positions when not moving already
				float jawDistance = Random.Range(jawRestPosition, jawFullOpenPosition);
				float lipX = Random.Range(upperLipRestPosition, upperLipOpenPosition);
				StartCoroutine(MoveJaw(jawDistance,lipX, Random.Range(.05f, .5f)));					
			}
		}
		else if (!mouthMoving && jaw.transform.localRotation.z != jawRestPosition) {
			// So that the avatar doesn't look like an idiot with his mouth open
			StartCoroutine(CloseJaw(.5f));
		}
	}
	
	IEnumerator MoveJaw (float newRotation, float newLipX, float time)
 	{
		mouthMoving = true;
     	float elapsedTime = 0;
     	float jawStartingRotation = jaw.transform.localRotation.z;
		float lipPosition = upperLip.transform.localPosition.x;
		
     	while (elapsedTime < time)
     	{
			float jawZ = Mathf.Lerp(jawStartingRotation, newRotation, (elapsedTime / time));
			jaw.transform.localRotation = Quaternion.Euler(0, 0, jawZ); 
			
			float lipX = Mathf.Lerp(lipPosition, newLipX, (elapsedTime / time));
			upperLip.transform.localPosition = new Vector3(lipX, upperLip.transform.localPosition.y, upperLip.transform.localPosition.z);
         	
			elapsedTime += Time.deltaTime;
         	yield return new WaitForEndOfFrame();
     	}

		mouthMoving = false;
	 }
	 
	 IEnumerator CloseJaw(float time){
		 yield return StartCoroutine(MoveJaw(jawRestPosition,upperLipRestPosition, time));
	 }
}
