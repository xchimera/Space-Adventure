using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float speed = 5f;
    public float rotationSpeed;
    public Camera cameraPrefab;
    Camera playerCamera;

    Actions actions;
	Vector3 movementInput;

    bool isGrounded = true;

	Rigidbody body;

	// Use this for initialization
	void Start () {
		actions = gameObject.GetComponent<Actions>();
		body = gameObject.GetComponent<Rigidbody>();
        rotationSpeed = 50f;

        /****
        * Check if camera exists
        ****/
        if (Camera.allCamerasCount == 0) {
            //Instantiate camera
            playerCamera = Instantiate(cameraPrefab, transform, true);
            playerCamera.transform.localPosition = new Vector3(0,0.857f,0.025f);
            playerCamera.transform.rotation = Quaternion.Euler(0,0,0);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
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
        if (Input.GetKey("w")) {
            body.MovePosition(body.position + transform.forward * speed * Time.deltaTime);
        }
	}
}
