using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using UnityEngine.Networking.NetworkSystem;
using System.Collections.Generic;

public class MessageNetworkManager : NetworkLobbyManager {

    protected bool valid = true;

    public const int MSG_DEBUG = 1001;
	public const int MSG_VOIP = 1002;

	private List<MessageNode> messageNodes = new List<MessageNode>();

	// Use this for initialization
	void Start () {
        
	}

    override public void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
        client.RegisterHandler(MessageNetworkManager.MSG_DEBUG, onDebugMessage);
		client.RegisterHandler(MessageNetworkManager.MSG_VOIP, onVoipMessage);
	}

	public void RegisterMessageNode(MessageNode node) {
		messageNodes.Add(node);
	}

    private void onDebugMessage(NetworkMessage netMsg)
    {
        StringMessage stringMessage = netMsg.ReadMessage<StringMessage>();
        foreach(MessageNode node in messageNodes) {
			node.OnDebugMessage(stringMessage);
		}
    }
	
	private void onVoipMessage(NetworkMessage netMsg)
	{
		VoipMessage voipMsg = netMsg.ReadMessage<VoipMessage>();
		foreach(MessageNode node in messageNodes) {
			node.OnVoipMessage(voipMsg);
		}
	}


    // Update is called once per frame
    void Update () {
	
	}
}
