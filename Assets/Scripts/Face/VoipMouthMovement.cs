using UnityEngine;
using AssemblyCSharp;
using DaikonForge.VoIP;

public class VoipMouthMovement : MonoBehaviour {

    [SerializeField]
    private SimpleMouthMovement mouthMovement;

    [SerializeField]
    private VoiceTranceiver voiceTranceiver;

    [SerializeField]
    private float talkingTimeout = 0.5f;

    private bool valid = true;
    private float lastVoipMessage = 0f;
    private bool talking = false;

	// Use this for initialization
	void Start () {
	   if(voiceTranceiver == null) {
           Debug.LogError("No VoipTranceiver set.");
           valid = false;
       }
       if(mouthMovement == null) {
           Debug.LogError("No MouthMovement set.");
           valid = false;
       }
       
       voiceTranceiver.addVoipFrameListener(VoipFrameReceived);
	}
    
    void Update() {
        if(talking && valid) {
            if(Time.time > lastVoipMessage + talkingTimeout) {
                stopTalking();
            }
        }
    }
    
    public void VoipFrameReceived(VoicePacketWrapper frame) {
        lastVoipMessage = Time.time;
        if(!talking) {
            startTalking();
        }
    }
    
    private void startTalking() {
        talking = true;
        mouthMovement.talking = true;
    }
    
    private void stopTalking() {
        talking = false;
        mouthMovement.talking = false;
    }
}
