	using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking;

public class GamePlayer : NetworkLobbyPlayer {

    [SerializeField]    private AudioListener audioListener;   
	[SerializeField]	private GameObject cardboard; 

    // Use this for initialization
    void Start () {
	   Debug.Log("A new GamePlayer is born! is local? "  + isLocalPlayer);
       audioListener.enabled = isLocalPlayer;
	   cardboard.SetActive(isLocalPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
