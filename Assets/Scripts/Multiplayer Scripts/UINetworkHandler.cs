using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINetworkHandler : Photon.PunBehaviour {

	public PhotonLogLevel logLevel = PhotonLogLevel.Informational;

	string gameVersion = "1";

	public GameEvent connectedEvent;

	private void Awake()
	{
		PhotonNetwork.logLevel = logLevel;
		PhotonNetwork.autoJoinLobby = false;

		PhotonNetwork.automaticallySyncScene = false;
	}


	public void Connect()
	{
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings(gameVersion);
	}

	public override void OnConnectedToPhoton()
	{
		connectedEvent.Raise();
	}

}
