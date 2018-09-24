using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameras : MonoBehaviour {

	public Camera shipOutsideCamera;
	Camera playerCamera;
	GameObject player;
	GameObject ship;

	private void Start()
	{
		ship = shipOutsideCamera.GetComponentInParent<Transform>().gameObject;
	}

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
		DisablePlayerScripts();
		EnablePlayerScripts();
	}

	public void EnablePlayerCamera()
	{
		DisableAllCameras();
		if(playerCamera != null)
		playerCamera.gameObject.SetActive(true);
	}

	public void FindAndSetPlayerCamera()
	{
		var playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
		if (playerCamera != null)
		{
			this.playerCamera = playerCamera.GetComponent<Camera>();
			player = playerCamera.transform.parent.gameObject;
		}
	}

	private void DisablePlayerScripts()
	{
		var fpc = player.GetComponent<FirstPersonController>();
		fpc.enabled = false;
		player.GetComponent<InteractScript>().Disable();
	}

	private void EnablePlayerScripts()
	{
		player.GetComponent<FirstPersonController>().enabled = true;
		player.GetComponent<InteractScript>().enabled = true;
		

	}

	private void DisableShipScripts()
	{

	}

	private void EnableShipScripts()
	{

	}

}
