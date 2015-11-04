using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;
using UnityEngine.Networking;
using AssemblyCSharp;

public class VoiceController : VoiceControllerBase
{
    private VoiceTranceiver tranceiver = null;


    public override bool IsLocal
	{
		get { return true; }
	}

	protected override void OnAudioDataEncoded( VoicePacketWrapper encodedFrame )
	{
        if (tranceiver == null)
        {
			tranceiver = GetComponent<VoiceTranceiver>();
			if(tranceiver == null)
            {
				Debug.LogError("No VoiceTranceiver found on NetworkMasterClient!!");
                return;
            }
			Debug.Log ("Sending voip package");
			tranceiver.SendVoipFrame(encodedFrame);

        }

        //ReceiveAudioData( encodedFrame );
	}

	protected override void ReceiveAudioData( VoicePacketWrapper encodedFrame ) {
		//Debug.Log (encodedFrame);
		base.ReceiveAudioData (encodedFrame);
	}
}