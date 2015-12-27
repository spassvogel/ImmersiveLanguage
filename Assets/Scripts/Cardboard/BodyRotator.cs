using UnityEngine;
using System.Collections;
/* 
This rotates the current */
public class BodyRotator : MonoBehaviour {

[SerializeField]
private Transform head;
[SerializeField]
private float speed = .02f;
	// Update is called once per frame
	void Update () 
	{
		Vector3 rootRotation = transform.rotation.eulerAngles;
		Vector3	headRotation = head.rotation.eulerAngles;
				
		headRotation.x = rootRotation.x;
		headRotation.z = rootRotation.z;		
				
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(headRotation) , speed * Time.deltaTime * Quaternion.Angle(transform.rotation, head.rotation));
	}
	
}
