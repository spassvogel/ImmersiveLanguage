using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class Client : NetworkLobbyManager {

    protected bool valid = true;

    public const int MSG_GENERIC = 1001;
	public const int MSG_VOIP = 1002;

	// Use this for initialization
	void Start () {
        
	}

    override public void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
        client.RegisterHandler(Client.MSG_GENERIC, onGenericMessage);
		client.RegisterHandler(Client.MSG_VOIP, onVoipMessage);
	}

    private void onGenericMessage(NetworkMessage netMsg)
    {
        VoipMessage voipMsg = netMsg.ReadMessage<VoipMessage>();
        //Debug.Log(voipMsg.message);
    }
	
	private void onVoipMessage(NetworkMessage netMsg)
	{
		VoipMessage voipMsg = netMsg.ReadMessage<VoipMessage>();
		//Debug.Log(voipMsg.message);
	}


    // Update is called once per frame
    void Update () {
	
	}
}
