
using System;
using UnityEngine.Networking;
using DaikonForge.VoIP;
using UnityEngine.Networking.NetworkSystem;

namespace AssemblyCSharp
{
	public class VoiceTranceiver : NetworkBehaviour
	{
		public void SendVoipFrame(VoicePacketWrapper encodedFrame)
		{
			CmdSendFrame (encodedFrame);
		}
		
		public void SendString(string text)
		{
			CmdSendString(text);
		}
		
		
		[Command]
		void CmdSendFrame(VoicePacketWrapper encodedFrame)
		{
			VoipMessage message = new VoipMessage();
			message.data = encodedFrame.RawData;
			message.headers = encodedFrame.ObtainHeaders();
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

