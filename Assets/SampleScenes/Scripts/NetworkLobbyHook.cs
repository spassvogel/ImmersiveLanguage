using UnityEngine;
using UnityStandardAssets.Network;
using System.Collections;
using UnityEngine.Networking;


public class NetworkLobbyHook : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {       
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        gamePlayer.name = lobby.playerName;
        //gamePlayer.transform.position = new Vector3(Random.Range(0, 3), 0, 0);
        //NetworkSpaceship spaceship = gamePlayer.GetComponent<NetworkSpaceship>();
/*
        spaceship.name = lobby.name;
        spaceship.color = lobby.playerColor;
        spaceship.score = 0;
        spaceship.lifeCount = 3;*/
    }
}
