using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonGameHandler : Photon.PunBehaviour {

	SpawnHandler spawnHandler;

	public GameEvent playerConnected;
	public GameEvent playerDisconnected;

	private void Start()
	{
		spawnHandler = gameObject.GetComponent<SpawnHandler>();
	}

	public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
	{
		Debug.Log("MultiplayerManager: Player connected: " + newPlayer.NickName);

		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("MultiplayerManager: Client is MasterClient");
		}
		Debug.Log("PhotonGameHandler: Player connected:" + newPlayer.NickName);
		playerConnected.Raise();
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("PhotonGameHandler: joined room");
		playerConnected.Raise();
	}


	public override void OnDisconnectedFromPhoton()
	{
		Debug.Log("PhotonGameHandler: Player disconnected:" );
		playerDisconnected.Raise();
	}



}
