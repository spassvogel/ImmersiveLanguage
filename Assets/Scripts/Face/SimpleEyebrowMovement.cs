using UnityEngine;
using System.Collections;

public class SimpleEyebrowMovement : MonoBehaviour {
	[SerializeField] private Transform leftBrow;
	[SerializeField] private Transform rightBrow;
	
	[SerializeField] private float xUpperBound = -0.0672f;
	[SerializeField] private float xLowerBound = -0.06165731f;
	
	[SerializeField] private float maxRandomEyeInterval = 5;
	
	private float nextMovementTime = 0;
	
	// Use this for initialization
	void Start () {
		MoveBrows();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextMovementTime){
			MoveBrows();
		}
	}
	
	private void MoveBrows() {
		nextMovementTime = Time.time + Random.Range(1f, maxRandomEyeInterval);
		var positionX = Random.Range(xLowerBound, xUpperBound);
		
		leftBrow.transform.localPosition = new Vector3(positionX, leftBrow.transform.localPosition.y, leftBrow.transform.localPosition.z);
		rightBrow.transform.localPosition = new Vector3(positionX, rightBrow.transform.localPosition.y, rightBrow.transform.localPosition.z);
	}
}
