using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonLobby : Photon.PunBehaviour
{

	public byte maxPlayersPerRoom = 4;


	private void Start()
	{
		Connect();
	}
	#region Public Methods

	public void Connect()
	{
		if (!PhotonNetwork.connected)
		{
			SceneManager.LoadScene(0);
			return;
		}
		
		PhotonNetwork.JoinRandomRoom();
	}


	public void CreateRoom()
	{
		Debug.Log("Lobby: Creating room without name");

		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
	}

	public void CreateRoom(string roomName)
	{
		Debug.Log("Lobby: Creating room with name: " + roomName);

		PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
	}

	#endregion

	#region Photon pun behaviour callbacks
	public override void OnConnectedToMaster()
	{
		Debug.Log("Lobby: OnConnectedToMaster was called by PUN");

		//Check if we are attempting to connect
		//Otherwise we could loop

			//Try to join an existing room. If none is available, OnPhotonRandomJoinFailed() is called
			PhotonNetwork.JoinRandomRoom();
	}

	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
	{
		Debug.Log("Lobby: OnPhotonRandomJoinFailed was called by PUN. No random room available.");
		CreateRoom();
	}



	public override void OnDisconnectedFromPhoton()
	{
		Debug.Log("Lobby: Disconnected from Photon");
	}

	#endregion


}
