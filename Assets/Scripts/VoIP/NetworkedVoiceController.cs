using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;
using UnityEngine.Networking;

public class NetworkedVoiceController : VoiceControllerBase
{
    private NetworkClient client = null;


    public override bool IsLocal
	{
		get { return true; }
	}

	protected override void OnAudioDataEncoded( VoicePacketWrapper encodedFrame )
	{
        if (client == null)
        {
            client = GetComponent<NetworkMasterClient>().client;
            if(client == null)
            {
                Debug.LogError("No NetworkClient found on NetworkMasterClient!!");
                return;
            }
            //
            var msg = new MasterMsgTypes.GenericMessage();
            msg.message = "fooo bar";
            client.Send(MasterMsgTypes.GenericMessageId, msg);
            Debug.Log("Sending " + msg.message);    
        }

        ReceiveAudioData( encodedFrame );
	}

	protected override void ReceiveAudioData( VoicePacketWrapper encodedFrame ) {
		//Debug.Log (encodedFrame);
		base.ReceiveAudioData (encodedFrame);
	}
}