using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float speed = 5f;
    public float rotationSpeed;
    public GameObject player;
    public GameObject playerCamera;

    Actions actions;
	Vector3 movementInput;

    bool isGrounded = true;

	Rigidbody body;

	// Use this for initialization
	void Start () {
		actions = gameObject.GetComponent<Actions>();
		body = gameObject.GetComponent<Rigidbody>();
        rotationSpeed = 50f;


        /*If camera is not child, create camera*/



    }
	
	// Update is called once per frame
	void Update () {
		movementInput = Vector3.zero;



        player.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
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
        if (Input.GetKey("w")) {
            body.MovePosition(body.position + transform.forward * speed * Time.deltaTime);
        }
	}
}
