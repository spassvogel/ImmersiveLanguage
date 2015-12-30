using UnityEngine;

// BodyRotator rotates its transform by the difference between the y-angle of the given Head and Hips,
// with a slack defined by maxAngle. 
public class BodyRotator : MonoBehaviour {

    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform hips;

    [SerializeField]
    private float maxAngle = 20f;

	void Update () 
	{
		Vector3 hipRotation = hips.rotation.eulerAngles;
		Vector3	headRotation = head.rotation.eulerAngles;
       
        float yAngle = Mathf.DeltaAngle(headRotation.y, hipRotation.y);
       
        if(Mathf.Abs(yAngle) > maxAngle) {
            float rotate;
            if(yAngle < 0) {
                rotate = -1 * yAngle - maxAngle;
            } else {
                rotate = maxAngle - yAngle;
            }
            transform.Rotate(0f, rotate, 0f);
        }
	}
	
}
