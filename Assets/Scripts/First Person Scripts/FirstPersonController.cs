using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float speed = 5f;

	Actions actions;
	Vector3 movementInput;
	Quaternion moveRotation;
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

		moveRotation = Quaternion.Euler(0, Input.GetAxis("Horizontal") * Time.deltaTime, 0);


		var a = Quaternion.identity;
		


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
