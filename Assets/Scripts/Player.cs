using UnityEngine;
using UnityEngine.Networking;

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
        VoipMessage message = new VoipMessage();
        message.message = msg;
        NetworkServer.SendToAll(Client.MSG_GENERIC, message);
    }
}
