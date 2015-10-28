using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;

public class MyLocalVoiceController : VoiceControllerBase
{
	public override bool IsLocal
	{
		get { return true; }
	}

	protected override void OnAudioDataEncoded( VoicePacketWrapper encodedFrame )
	{
		ReceiveAudioData( encodedFrame );
	}

	protected override void ReceiveAudioData( VoicePacketWrapper encodedFrame ) {
		//Debug.Log (encodedFrame);
		base.ReceiveAudioData (encodedFrame);
	}
}