using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float speed = 5f;
	public float rotationSpeed = 3f;


	Actions actions;
	Vector3 movementInput;
	Quaternion moveRotation = Quaternion.identity;
	bool isGrounded = true;

	Rigidbody body;

	// Use this for initialization
	void Start () {
		actions = gameObject.GetComponent<Actions>();
		body = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		movementInput = Vector3.zero;
		movementInput.z = Input.GetAxis("Vertical");

		float horizontal = Input.GetAxis("Horizontal");

		moveRotation = Quaternion.Euler(0, horizontal * rotationSpeed * Time.deltaTime, 0);

		if (moveRotation != Quaternion.identity)
		{
			transform.forward = new Vector3(0, 0, 0);
		}


		if (movementInput != Vector3.zero)
		{
			//transform.forward = movementInput;
			actions.Run();
		}
		else
		{
			actions.Stay();
		}


	}

	private void FixedUpdate()
	{
		body.MovePosition(body.position + movementInput * speed * Time.deltaTime);
		body.MoveRotation(body.rotation * moveRotation);
	}
}
