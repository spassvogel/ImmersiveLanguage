using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using DaikonForge.VoIP;
using System;

public class VoipMessage : MessageBase {

	[NonSerialized]
	public VoicePacketWrapper vpw;

	//public int frequency;
	//public int index;
	//private byte[] rawData;


	override public void Serialize(NetworkWriter writer) {
		writer.Write(vpw.Frequency);
		writer.WritePackedUInt64(vpw.Index);
		writer.WriteBytesAndSize(vpw.RawData, vpw.RawData.Length);
		//frequency = vpw.Frequency;
		//index = vpw.Index;
		//rawData = vpw.RawData;
	}

	override public void Deserialize(NetworkReader reader) {
		byte frequency = reader.ReadByte();
		ulong index = reader.ReadUInt64();
		byte[] rawData = reader.ReadBytesAndSize();

		vpw = new VoicePacketWrapper (index, frequency, rawData);
	}

}
