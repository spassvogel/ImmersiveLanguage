using UnityEngine;

/// @ingroup Scripts
/// This script provides head tracking support for a camera.
///

public class CardboardHeadController : MonoBehaviour {
    public Transform target;
    public Transform targetRoot;


  /// Determines whether the head tracking is applied during `LateUpdate()` or
  /// `Update()`.  The default is false, which means it is applied during `LateUpdate()`
  /// to reduce latency.
  ///
  /// However, some scripts may need to use the camera's direction to affect the gameplay,
  /// e.g by casting rays or steering a vehicle, during the `LateUpdate()` phase.
  /// This can cause an annoying jitter because Unity, during this `LateUpdate()`
  /// phase, will update the head object first on some frames but second on others.
  /// If this is the case for your game, try switching the head to apply head tracking
  /// during `Update()` by setting this to true.
  public bool updateEarly = false;

  [SerializeField]  private float xRotateUp = 45f;
  [SerializeField]  private float xRotateDown = 40f;
  
  /// Returns a ray based on the heads position and forward direction, after making
  /// sure the transform is up to date.  Use to raycast into the scene to determine
  /// objects that the user is looking at.
  public Ray Gaze {
    get {
      UpdateHead();
      return new Ray(transform.position, transform.forward);
    }
  }

  private bool updated;

  void OnDrawGizmos()
  {
   // Quaternion.
    if(target == null)
    return;
      
    
    Gizmos.color = Color.blue;
    Gizmos.DrawRay(target.position, target.forward);
  }

  Vector3 startRotation;
  void Start()
  {
    startRotation = target.rotation.eulerAngles;
  }

  void Update() {
    
    updated = false;  // OK to recompute head pose.
    if (updateEarly) {
      UpdateHead();
    }
  }

  // Normally, update head pose now.
  void LateUpdate() {
    UpdateHead();
  }

  // Compute new head pose.
  private void UpdateHead() {
    if (updated) {  // Only one update per frame, please.
      return;
    }
    updated = true;
    Cardboard.SDK.UpdateState();

    // Update self rotation (which contains the cameras)
	  transform.localRotation = Cardboard.SDK.HeadPose.Orientation;

  	Vector3 rotation = Cardboard.SDK.HeadPose.Orientation.eulerAngles;
    rotation.x = ClampAngle(rotation.x, startRotation.x - xRotateUp, startRotation.x + xRotateDown);
		target.rotation = Quaternion.Euler(rotation + targetRoot.rotation.eulerAngles);
  }
  
  
	 float ClampAngle(float angle, float min, float max)	 {
 
     if (angle<90 || angle>270){       // if angle in the critic region...
         if (angle>180) angle -= 360;  // convert all angles to -180..+180
         if (max>180) max -= 360;
         if (min>180) min -= 360;
     }    
     angle = Mathf.Clamp(angle, min, max);
     if (angle<0) angle += 360;  // if angle negative, convert to 0..360
     return angle;
 }
}
