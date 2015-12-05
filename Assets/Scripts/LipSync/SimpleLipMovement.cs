using UnityEngine;
using Random=UnityEngine.Random;
using System.Collections;
using System;

public class SimpleLipMovement : MonoBehaviour {
	/// Set to true to start random lip movement
	public Boolean lipMoving = false; 

	[SerializeField] private Transform jaw;
	[SerializeField] private float jawRestPosition = 0;
	[SerializeField] private float jawFullOpenPosition = -11;
	
	private bool animating = false;

		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(lipMoving && !animating){
			float distance = Random.Range(jawRestPosition, jawFullOpenPosition);
			StartCoroutine(MoveJaw(distance, Random.Range(.05f, .5f)));			
		}
	}
	
	 IEnumerator MoveJaw (float newRotation, float time)
 	{
		animating = true;
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
		animating = false;
	 }
}
