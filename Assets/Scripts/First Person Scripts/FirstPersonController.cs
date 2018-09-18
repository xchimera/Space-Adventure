using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : Photon.PunBehaviour, IPunObservable
{

	public float speed = 5f;
	public float rotationSpeed = 50f;
	//public Camera cameraPrefab;
	public Camera playerCamera;

	Actions actions;
	Vector3 movementInput;

	bool isGrounded = true;

	Rigidbody body;

	private void Awake()
	{
		if (photonView.isMine)
		{
			playerCamera.gameObject.SetActive(true);
		}
		else
		{
			playerCamera.gameObject.SetActive(false);
		}

	}

	// Use this for initialization
	void Start()
	{
		actions = gameObject.GetComponent<Actions>();
		body = gameObject.GetComponent<Rigidbody>();
		//rotationSpeed = 50f;

		//if (photonView.isMine)
		//{
		//	playerCamera.gameObject.SetActive(true);
		//}
		//else
		//{
		//	playerCamera.gameObject.SetActive(false);
		//}


	}

	// Update is called once per frame
	void Update()
	{
		if (photonView.isMine == false)
		{
			return;
		}

		movementInput = Vector3.zero;
		transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
		playerCamera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * rotationSpeed);

		if (movementInput != Vector3.zero)
		{
			actions.Run();
		}
		else
		{
			actions.Stay();
		}
	}

	private void FixedUpdate()
	{
		if (photonView.isMine == false)
		{
			return;
		}

		if (Input.GetKey("w"))
		{
			body.MovePosition(body.position + transform.forward * speed * Time.deltaTime);
		}
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

	[PunRPC]
	public void EnterShip(int shipViewId)
	{
		var ships = GameObject.FindGameObjectsWithTag("PlayableShip");
		GameObject shipToEnter = null;

		foreach (var ship in ships)
		{
			if (ship.GetPhotonView().viewID == shipViewId)
			{
				shipToEnter = ship;
			}
		}
		
		this.transform.parent = shipToEnter.transform;
	}
}
