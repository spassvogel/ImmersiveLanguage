
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
            NetworkServer.SendToAll(Client.MSG_VOIP, message);
            encodedFrame.ReleaseHeaders();
            //var data = encodedFrame.ObtainHeaders();
            //NetworkServer.SendBytesToReady(this, data, data.Length, 1);
        }


        [Command]
        void CmdSendString(string msg)
        {
            StringMessage message = new StringMessage();
            message.value = msg;
            NetworkServer.SendToAll(Client.MSG_GENERIC, message);
        }

    }
}

