using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using DaikonForge.VoIP;
using System;

public class VoipMessage : MessageBase {

    public byte[] headers;
    public byte[] data;

}
