using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : Photon.PunBehaviour {

	public GameObject playerPrefab;

	public GameObject cockpitMesh;

	#region Unity Methods
	private void Start()
	{

		if (playerPrefab == null)
		{
			Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
			return;
		}
	}
	#endregion

	public void SpawnPlayer()
	{
		Debug.Log("SpawnHandler: Instantiating player");

		Vector3 startPos;

		if (PhotonNetwork.playerList.Length == 0)
			startPos = new Vector3(-17f, 0, 0);
		else if (PhotonNetwork.playerList.Length == 1)
			startPos = new Vector3(-13, 0, 0);

		else
			startPos = new Vector3(0, 0, 0);

		Vector3 camPos = new Vector3(0, 0.857f, 0.025f);

		GameObject playerObject = PhotonNetwork.Instantiate(this.playerPrefab.name, startPos, Quaternion.identity, 0);

		playerObject.transform.parent = cockpitMesh.transform;
		playerObject.transform.localPosition = new Vector3(15, 1, 0);


	}

}
