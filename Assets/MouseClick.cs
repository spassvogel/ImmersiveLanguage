using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown ()
	{
		Debug.Log ("sending message  " );
        GetComponent<Begin>().SendReadyToBeginMessage(23);
    }
}
