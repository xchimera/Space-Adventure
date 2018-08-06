using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControlls : Photon.MonoBehaviour
{

	private GameObject gameData;


	//Curent speed variables
	private float horizontalSpeed = 0f;
	private float verticalSpeed = 0f;
	private float lateralSpeed = 0f;

	//Acceleration variables
	public float mainAcceleration = 0.1f;
	public float secondaryAcceleration = 0.1f;
	public float rotationSpeed = 100.0f;

	//Max speed variables
	public float maxHorizontalSpeed = 10f;
	public float maxVerticalSpeed = 30f;
	public float maxLateralSpeed = 10f;

	void Update()
	{
		if (!photonView.isMine)
		{
			return;
		}
		/*****
        * Movement script
        *****/

		//if (GameManager.isInsideVehicle == true)
		//{

			/*Move ship*/
			transform.Translate(0, 0, verticalSpeed * Time.deltaTime);
			transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
			transform.Translate(0, lateralSpeed * Time.deltaTime, 0);

			/*Rotate ship*/
			var rX = Input.GetAxis("rotateHorizontal") * Time.deltaTime * rotationSpeed;
			var rY = Input.GetAxis("rotateVertical") * Time.deltaTime * rotationSpeed;
			var rZ = Input.GetAxis("rotateSides") * Time.deltaTime * rotationSpeed;

			transform.Rotate(0, 0, rX);
			transform.Rotate(0, rZ, 0);
			transform.Rotate(rY, 0, 0);


			/*****
            * Acceleration buttons
            *****/

			//Vertical
			if (Input.GetAxis("Vertical") > 0)
			{
				if (verticalSpeed < maxVerticalSpeed)
				{
					verticalSpeed = accelerate(verticalSpeed, mainAcceleration);
				}
			}
			else if (Input.GetAxis("Vertical") == 0)
			{
				if (verticalSpeed > 0 && verticalSpeed != 0)
				{
					verticalSpeed = deaccelerate(verticalSpeed, mainAcceleration);

				}
				else if (verticalSpeed < 0 && verticalSpeed != 0)
				{
					verticalSpeed = accelerate(verticalSpeed, mainAcceleration);
				}
				else
				{
					verticalSpeed = 0;
				}
			}
			else if (Input.GetAxis("Vertical") < 0)
			{
				if (verticalSpeed > -maxVerticalSpeed)
				{
					verticalSpeed = deaccelerate(verticalSpeed, mainAcceleration);
				}
			}


			//Horizontal
			if (Input.GetAxis("Horizontal") > 0)
			{
				if (horizontalSpeed < maxHorizontalSpeed)
				{
					horizontalSpeed = accelerate(horizontalSpeed, secondaryAcceleration);
				}
			}
			else if (Input.GetAxis("Horizontal") == 0)
			{
				if (horizontalSpeed > 0 && horizontalSpeed != 0)
				{
					horizontalSpeed = deaccelerate(horizontalSpeed, secondaryAcceleration);
				}
				else if (horizontalSpeed < 0 && horizontalSpeed != 0)
				{
					horizontalSpeed = accelerate(horizontalSpeed, secondaryAcceleration);
				}
				else
				{
					horizontalSpeed = 0;
				}
			}
			else if (Input.GetAxis("Horizontal") < 0)
			{
				if (horizontalSpeed > -maxHorizontalSpeed)
				{
					horizontalSpeed = deaccelerate(horizontalSpeed, secondaryAcceleration);
				}
			}


			//Lateral
			if (Input.GetAxis("lift") > 0)
			{
				if (lateralSpeed < maxLateralSpeed)
				{
					lateralSpeed = accelerate(lateralSpeed, secondaryAcceleration);
				}
			}
			else if (Input.GetAxis("lift") == 0)
			{
				if (lateralSpeed > 0 && lateralSpeed != 0)
				{
					lateralSpeed = deaccelerate(lateralSpeed, secondaryAcceleration);

				}
				else if (lateralSpeed < 0 && lateralSpeed != 0)
				{
					lateralSpeed = accelerate(lateralSpeed, secondaryAcceleration);

				}
				else
				{
					lateralSpeed = 0;
				}
			}
			else if (Input.GetAxis("lift") < 0)
			{
				if (lateralSpeed > -maxLateralSpeed)
				{
					lateralSpeed = deaccelerate(lateralSpeed, secondaryAcceleration);
				}
			}
		//}
	}

	private float accelerate(float speed, float acceleration)
	{
		return speed + acceleration;
	}

	private float deaccelerate(float speed, float acceleration)
	{
		return speed - acceleration;
	}
}