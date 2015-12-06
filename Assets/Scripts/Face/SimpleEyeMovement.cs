using UnityEngine;
using System.Collections;

public class SimpleEyeMovement : MonoBehaviour {

	[SerializeField] private Transform leftEye;
	[SerializeField] private Transform rightEye;
	
	[SerializeField] private float zUpperBound = 10f;
	[SerializeField] private float zLowerBound = -14f;
	
	[SerializeField] private float xUpperBound = 14f;
	[SerializeField] private float xLowerBound = -14f;
	
	[SerializeField] private float maxRandomEyeInterval = 2;
	
	private float nextMovementTime = 0;
	
	// Use this for initialization
	void Start () {
		MoveEyes();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextMovementTime){
			MoveEyes();
		}
	}
	
	private void MoveEyes() {
		nextMovementTime = Time.time + Random.Range(.2f, maxRandomEyeInterval);
		var rotateX = Random.Range(xLowerBound, xUpperBound);
		var rotateZ = Random.Range(zLowerBound, zUpperBound);
		
		leftEye.transform.localRotation = Quaternion.Euler(rotateX, 0, rotateZ);
		rightEye.transform.localRotation = Quaternion.Euler(rotateX, 0, rotateZ);
	}
}
