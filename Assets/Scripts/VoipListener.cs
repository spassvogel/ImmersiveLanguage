using UnityEngine;
using System.Collections;
using UnityEngine.Networking.NetworkSystem;

public interface VoipListener
{
	void OnVoipMessage (VoipMessage message);
}

