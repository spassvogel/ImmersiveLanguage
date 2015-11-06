using UnityEngine;
using System.Collections;

using DaikonForge.VoIP;
using UnityEngine.Networking;
using AssemblyCSharp;
using UnityEngine.Networking.NetworkSystem;

public class VoiceController : VoiceControllerBase
{
    private VoiceTranceiver tranceiver = null;
    private bool errorDisplayed = false;
    private NetworkLobbyPlayer nlp;

    public override bool IsLocal
	{
		get
        {
           // if(nlp == null)
            //{
              //  nlp = GetComponent<NetworkLobbyPlayer>();
              //  if(nlp == null)
               // {
                    return true;
               // }
           // }
           // return nlp.isLocalPlayer;
        }
	}

	protected override void OnAudioDataEncoded( VoicePacketWrapper encodedFrame )
	{
        if (tranceiver == null)
        {
			tranceiver = GetComponent<VoiceTranceiver>();
			if(tranceiver == null)
            {
				if(!errorDisplayed) Debug.LogError("No VoiceTranceiver found!!");
                errorDisplayed = true;
                return;
            }
			Debug.Log ("Sending voip package");
			tranceiver.SendVoipFrame(encodedFrame);
        }

        //ReceiveAudioData( encodedFrame );
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
		//Debug.Log (encodedFrame);
		base.ReceiveAudioData (encodedFrame);
	}

    public void FrameReceived(byte[] headers, byte[] data)
    {
        var encodedFrame = new VoicePacketWrapper(headers, data);
        Debug.Log("playing audio frame " + encodedFrame);

        ReceiveAudioData(encodedFrame);
    }
}