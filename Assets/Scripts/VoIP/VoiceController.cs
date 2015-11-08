using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;
using UnityEngine.Networking;
using AssemblyCSharp;
using UnityEngine.Networking.NetworkSystem;

[RequireComponent (typeof (NetworkIdentity))]
public class VoiceController : VoiceControllerBase
{
    private VoiceTranceiver tranceiver = null;
    private bool errorDisplayed = false;
    private NetworkIdentity networkIdentity;

	protected override void Awake() {
		networkIdentity = GetComponent<NetworkIdentity>();

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

        if (tranceiver == null)
        { 
            tranceiver = GetComponent<VoiceTranceiver>();
			if(tranceiver == null)
            {
				Debug.LogError("No VoiceTranceiver found!!");
                return;
            }
        }

        tranceiver.SendVoipFrame(encodedFrame);
    }

    void Update()
    {
        // For debugging
        if (Input.GetKeyDown("a"))
        {
            tranceiver = GetComponent<VoiceTranceiver>();
            if (tranceiver == null)
            {
                Debug.LogError("No VoiceTranceiver found on NetworkMasterClient!!");
                return;
            }
            tranceiver.SendString("aaa!");

        }
    }


    protected override void ReceiveAudioData( VoicePacketWrapper encodedFrame ) {
		base.ReceiveAudioData (encodedFrame);
	}

    public void FrameReceived(byte[] headers, byte[] data)
    {
        var encodedFrame = new VoicePacketWrapper(headers, data);

        ReceiveAudioData(encodedFrame);
    }
}