using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonGameHandler : Photon.PunBehaviour, IPunObservable {

	SpawnHandler spawnHandler;

	public GameEvent playerConnected;
	public GameEvent playerDisconnected;


	public GameObject playerPrefab;
	public GameObject ship;
	public Transform[] spawns;

	public Text eventTexts;

	private void Start()
	{
		spawnHandler = gameObject.GetComponent<SpawnHandler>();
	}

	public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
	{
		//Debug.Log("MultiplayerManager: Player connected: " + newPlayer.NickName);

		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("MultiplayerManager: Client is MasterClient");
		}
		Debug.Log("PhotonGameHandler: Player connected:" + newPlayer.NickName);
		//playerConnected.Raise();
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("PhotonGameHandler: joined room");
		eventTexts.text += "Joined room \n";


		//spawn
		Debug.Log("SpawnHandler: Instantiating player");
		eventTexts.text += "Spawning player \n";
		Vector3 startPos;

		if (PhotonNetwork.playerList.Length == 1)
			startPos = spawns[0].position;
		//startPos = new Vector3(-17f, 0, 0);
		else if (PhotonNetwork.playerList.Length == 2)
			startPos = spawns[1].position;
		//startPos = new Vector3(-13, 0, 0);

		else
			startPos = new Vector3(0, 0, 0);

		Vector3 camPos = new Vector3(0, 0.857f, 0.025f);

		GameObject playerObject = PhotonNetwork.Instantiate(this.playerPrefab.name, startPos, Quaternion.identity, 0);

		var shipViewId = ship.GetPhotonView().viewID;

		FirstPersonController firstPersonController = playerObject.GetComponent<FirstPersonController>();

		playerObject.transform.position = startPos;
		firstPersonController.photonView.RPC("EnterShip", PhotonTargets.AllBuffered, shipViewId);	

		playerConnected.Raise();

	}


	public override void OnDisconnectedFromPhoton()
	{
		Debug.Log("PhotonGameHandler: Player disconnected:" );
		playerDisconnected.Raise();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isReading)
		{

		}
		else if (stream.isWriting)
		{

		}
	}
}
