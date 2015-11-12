using UnityEngine;
using System.Collections;

public class YSpinner : MonoBehaviour {


    [SerializeField]
    private float speed = 25;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);
    }
}
