using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameras : MonoBehaviour {

	public Camera shipOutsideCamera;
	Camera playerCamera;

	public void DisableAllCameras()
	{
		if(shipOutsideCamera != null)
			shipOutsideCamera.gameObject.SetActive(false);
		if(playerCamera != null)
			playerCamera.gameObject.SetActive(false);
	}

	public void EnableShipOutsideCamera()
	{
		DisableAllCameras();
		if(shipOutsideCamera != null)
			shipOutsideCamera.gameObject.SetActive(true);
	}

	public void EnablePlayerCamera()
	{
		DisableAllCameras();
		if(playerCamera != null)
		playerCamera.gameObject.SetActive(true);
	}

	public void FindAndSetPlayerCamera()
	{
		//var player = GameObject.FindGameObjectWithTag("Player");
		var playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
		//var playerCamera = player.gameObject.GetComponentInChildren<Camera>();
		if(playerCamera != null)
			this.playerCamera = playerCamera.GetComponent<Camera>();
	}

}
