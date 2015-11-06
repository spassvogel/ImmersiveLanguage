using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class Player : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            CmdSendMessage("jupjup");
        }
    }

    [Command]
    void CmdSendMessage(string msg)
    {
        StringMessage message = new StringMessage();
        message.value = msg;
        NetworkServer.SendToAll(Client.MSG_GENERIC, message);
    }
}
