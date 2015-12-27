using UnityEngine;

using DaikonForge.VoIP;
using UnityEngine.Networking;
using AssemblyCSharp;

[RequireComponent (typeof (NetworkIdentity))]
[RequireComponent (typeof (VoiceTranceiver))]
[RequireComponent (typeof (MicrophoneInputDevice))]
[RequireComponent (typeof (UnityAudioPlayer))]
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
		
		microphone = GetComponent<MicrophoneInputDevice>() as AudioInputDeviceBase;
		speaker = GetComponent<UnityAudioPlayer>() as IAudioPlayer;
        if(speaker == null) {
            Debug.LogError("No AudioSource found.");
        }
        if(microphone == null) {
            Debug.LogError("No MicrophoneInputDevice found.");
        }
		
		// --/ End Copy
	}

	void Start() {
		if( IsLocal )
		{
            Debug.Log("Start microphone recording.");
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
    
    public void FrameReceived(VoicePacketWrapper frame)
    {
        ReceiveAudioData(frame);
    }
}