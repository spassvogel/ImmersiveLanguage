using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Collections.Generic;

public class MessageNetworkManager : UnityStandardAssets.Network.LobbyManager
{
    public const int MSG_DEBUG = 1001;
	public const int MSG_VOIP = 1002;

	private List<MessageNode> messageNodes = new List<MessageNode>();

    public override void OnStartClient(NetworkClient client)
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
}
