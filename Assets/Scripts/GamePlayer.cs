using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking;

public class ImmersiveNetworkLobbyPlayer : NetworkLobbyPlayer {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
