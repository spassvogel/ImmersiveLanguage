
using System;
using UnityEngine.Networking;
using DaikonForge.VoIP;

namespace AssemblyCSharp
{
	public class VoiceTranceiver : NetworkBehaviour
	{
		public void SendVoipFrame(VoicePacketWrapper encodedFrame){
			CmdSendFrame (encodedFrame);
		}
	

		[Command]
		void CmdSendFrame(VoicePacketWrapper encodedFrame)
		{
			VoipMessage message = new VoipMessage();
			message.vpw = encodedFrame;
			NetworkServer.SendToAll(Client.MSG_VOIP, message);
		}
}
}

