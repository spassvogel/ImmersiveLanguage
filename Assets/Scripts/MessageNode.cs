using UnityEngine;
using System.Collections;
using UnityEngine.Networking.NetworkSystem;
using System.Collections.Generic;

public class MessageNode : MonoBehaviour {
	
	public List<GameObject> VoipListeners;
	public List<GameObject> DebugListeners;

	private List<VoipListener> voipListeners = new List<VoipListener>();
	private List<DebugListener> debugListeners = new List<DebugListener>();

	MessageNetworkManager MessageNetworkManager;

	void Start () {
		MessageNetworkManager = (MessageNetworkManager)FindObjectOfType(typeof(MessageNetworkManager));
		if(MessageNetworkManager == null) {
			Debug.LogError("Could not find MessageNetworkManager.");
			return;
		}

		// Register listeners
		foreach(GameObject go in VoipListeners) {
			VoipListener listener = go.GetComponent<VoipListener>();
			if(listener != null) {
				voipListeners.Add(listener);
			}
		}
		foreach(GameObject go in DebugListeners) {
			DebugListener listener = go.GetComponent<DebugListener>();
			if(listener != null) {
				debugListeners.Add(listener);
			}
		}

        Debug.Log("Registering Message Node");
		MessageNetworkManager.RegisterMessageNode(this);
	}

	public void OnDebugMessage(StringMessage message) {
		foreach(DebugListener listener in debugListeners) {
			listener.OnDebugMessage(message);
		}
	}

	public void OnVoipMessage(VoipMessage message) {
		foreach(VoipListener listener in voipListeners) {
			listener.OnVoipMessage(message);
		}
	}
}
