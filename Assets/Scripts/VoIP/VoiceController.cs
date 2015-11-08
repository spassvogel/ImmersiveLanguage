using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;
using UnityEngine.Networking;
using AssemblyCSharp;
using UnityEngine.Networking.NetworkSystem;

[RequireComponent (typeof (NetworkIdentity))]
[RequireComponent (typeof (VoiceTranceiver))]
public class VoiceController : VoiceControllerBase, VoipListener
{
    private VoiceTranceiver tranceiver = null;
    private NetworkIdentity networkIdentity;

	protected override void Awake() {
		networkIdentity = GetComponent<NetworkIdentity>();
		tranceiver = GetComponent<VoiceTranceiver>();

		// -- Copied from VoiceControllerBase; removed microphone start
		codec = GetCodec();
		
		microphone = GetComponent<AudioInputDeviceBase>();
		speaker = GetComponent( typeof( IAudioPlayer ) ) as IAudioPlayer;
		
		if( microphone == null )
		{
			Debug.LogError( "No audio input component attached to speaker", this );
			return;
		}
		
		if( speaker == null )
		{
			Debug.LogError( "No audio output component attached to speaker", this );
			return;
		}
		// --/ End Copy
	}

	void Start() {
		if( IsLocal )
		{
			if(microphone == null) {
				Debug.Log ("No microphone found. Cannot record audio.");
				return;
			}
			Debug.Log ("Start microphone recording.");
			microphone.OnAudioBufferReady += this.OnMicrophoneDataReady;
			microphone.StartRecording();
		}
	}

    public override bool IsLocal
	{
		get
        {
			return networkIdentity.hasAuthority;
        }
	}

	protected override void OnAudioDataEncoded( VoicePacketWrapper encodedFrame )
	{
		VoipMessage message = new VoipMessage();
		message.data = encodedFrame.RawData;
		message.headers = encodedFrame.ObtainHeaders();
		NetworkServer.SendToAll(MessageNetworkManager.MSG_VOIP, message);
		encodedFrame.ReleaseHeaders();

        tranceiver.SendVoipFrame(encodedFrame);
    }

    protected override void ReceiveAudioData( VoicePacketWrapper encodedFrame ) {
		base.ReceiveAudioData (encodedFrame);
	}

    public void FrameReceived(byte[] headers, byte[] data)
    {
        var encodedFrame = new VoicePacketWrapper(headers, data);
        ReceiveAudioData(encodedFrame);
    }

	public void OnVoipMessage(VoipMessage message) {
		FrameReceived(message.headers, message.data);
	}
}