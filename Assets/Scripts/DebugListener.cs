using UnityEngine;
using System.Collections;
using UnityEngine.Networking.NetworkSystem;

public interface DebugListener
{
	void OnDebugMessage (StringMessage message);
}

