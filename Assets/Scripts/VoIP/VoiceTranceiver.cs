using UnityEngine;
using System;
using UnityEngine.Networking;
using DaikonForge.VoIP;
using UnityEngine.Networking.NetworkSystem;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class VoiceTranceiver : NetworkBehaviour, VoipListener
	{
		public delegate void Listener(VoicePacketWrapper wrapper);

		List<Listener> listeners = new List<Listener>();

		public void SendVoipFrame(VoicePacketWrapper encodedFrame)
		{
			CmdSendFrame (encodedFrame);
		}
		
		public void SendString(string text)
		{
			CmdSendString(text);
		}

		public void OnVoipMessage(VoipMessage message) {
			// Check if I am not the origin
            Debug.Log("Receiving VOIP Message");
			if(message.originID == this.netId.Value) {
                var encodedFrame = new VoicePacketWrapper(message.headers, message.data);
				foreach(Listener listener in listeners) {
					listener(encodedFrame);
				}
			}
		}

		public void onReceiveVoipFrame(Listener receiveVoipFrame) {
			listeners.Add(receiveVoipFrame);
		}

		[Command]
		void CmdSendFrame(VoicePacketWrapper encodedFrame)
		{
			VoipMessage message = new VoipMessage();
			message.originID = this.netId.Value;
			message.data = encodedFrame.RawData;
			message.headers = encodedFrame.ObtainHeaders();
            
            Debug.Log("Sending VOIP Message");
			NetworkServer.SendToAll(MessageNetworkManager.MSG_VOIP, message);
			encodedFrame.ReleaseHeaders();
		}
		
		[Command]
		void CmdSendString(string msg)
		{
			StringMessage message = new StringMessage();
			message.value = msg;
			NetworkServer.SendToAll(MessageNetworkManager.MSG_DEBUG, message);
		}
	}
}

