using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;
using UnityEngine.Networking;
using AssemblyCSharp;
using UnityEngine.Networking.NetworkSystem;

[RequireComponent (typeof (NetworkIdentity))]
[RequireComponent (typeof (VoiceTranceiver))]
public class VoiceController : VoiceControllerBase
{
    private VoiceTranceiver tranceiver = null;
    private NetworkIdentity networkIdentity;

	protected override void Awake() {
		networkIdentity = GetComponent<NetworkIdentity>();
		tranceiver = GetComponent<VoiceTranceiver>();

		// Listen to VoipTranceiver
		tranceiver.onReceiveVoipFrame(this.FrameReceived);

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

        tranceiver.SendVoipFrame(encodedFrame);
    }

    private bool test_Invoked = false;
    public void FrameReceived(VoicePacketWrapper frame)
    {
        if(!test_Invoked)
        {
            Invoke("ResetScale", .5f);
            test_Invoked = true;
        }
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        ReceiveAudioData(frame);
    }

    private void ResetScale()
    {
        transform.localScale = Vector3.one;
        Invoke("ResetInvoked", .5f);
    }

    private void ResetInvoked()
    {
        test_Invoked = false;
    }
}