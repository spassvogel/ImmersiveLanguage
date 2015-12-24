using UnityEngine;
using UnityEngine.Networking;

public class GamePlayer : NetworkLobbyPlayer {

    [SerializeField]    private AudioListener audioListener;   
	[SerializeField]	private GameObject cardboard; 
	[SerializeField]	private SkinnedMeshRenderer meshRenderer; 

    // Use this for initialization
    void Start () {
	   //Debug.Log("A new GamePlayer is born! is local? "  + isLocalPlayer);
       audioListener.enabled = isLocalPlayer;

	   // Only turn cardboard controls on for local player
	   cardboard.SetActive(isLocalPlayer);
       
	   
	   if(meshRenderer){
		   // Disable rendering of local player (so the player wont see himself when looking down)
		  meshRenderer.enabled = !isLocalPlayer;
	   }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
