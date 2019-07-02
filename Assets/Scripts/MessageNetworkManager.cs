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
        client.RegisterHandler(MSG_DEBUG, onDebugMessage);
		client.RegisterHandler(MSG_VOIP, onVoipMessage);
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

    public override void OnLobbyStartClient(NetworkClient lobbyClient)
    {
        Debug.Log("OnLobbyStartClient");
        base.OnLobbyStartClient(lobbyClient);
    }

    public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("OnLobbyServerCreateLobbyPlayer");
        //conn.
        return base.OnLobbyServerCreateLobbyPlayer(conn, playerControllerId);
    }

    public override GameObject OnLobbyServerCreateGamePlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("OnLobbyServerCreateGamePlayer");
        var player = base.OnLobbyServerCreateGamePlayer(conn, playerControllerId);


        return player;
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        Debug.Log("OnServerAddPlayer");

        base.OnServerAddPlayer(conn, playerControllerId, extraMessageReader);
    }

    public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
    {
        Debug.Log("OnLobbyServerSceneLoadedForPlayer " + gamePlayer);
        return base.OnLobbyServerSceneLoadedForPlayer(lobbyPlayer, gamePlayer);
    }


    //  OnStartLocalPlayer
}
