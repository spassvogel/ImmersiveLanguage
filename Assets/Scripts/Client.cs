using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using UnityEngine.Networking.NetworkSystem;

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
        StringMessage stringMessage = netMsg.ReadMessage<StringMessage>();
        Debug.Log(stringMessage.value);
    }
	
	private void onVoipMessage(NetworkMessage netMsg)
	{
		VoipMessage voipMsg = netMsg.ReadMessage<VoipMessage>();
        Debug.Log("Voip message received!");

        var player = singleton.client.connection.playerControllers[0];
        var voiceController = player.gameObject.GetComponent<VoiceController>();
        voiceController.FrameReceived(voipMsg.headers, voipMsg.data);
	}


    // Update is called once per frame
    void Update () {
	
	}
}
