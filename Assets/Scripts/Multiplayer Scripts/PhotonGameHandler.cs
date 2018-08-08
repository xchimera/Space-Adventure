using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonGameHandler : Photon.PunBehaviour {

	public GameObject playerPrefab;


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

}
