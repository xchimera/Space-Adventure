using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
	public Text interactText;

	private bool _isInInteractableZone = false;
	Camera playerCamera;

	public bool IsInInteractableZone
	{
		get
		{
			return _isInInteractableZone;
		}

		set
		{
			_isInInteractableZone = value;
		}
	}

	private void Awake()
	{
		for (int i = 0; i < Camera.allCameras.Length; i++)
		{
			var currentCamera = Camera.allCameras[i];
			if (currentCamera.tag == "PlayerCamera")
			{
				playerCamera = currentCamera;
				break;
			}
		}
		interactText = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
	}

	public void Disable()
	{
		interactText.text = "";
		this.enabled = false;
	}

	private void FixedUpdate()
	{
		if (_isInInteractableZone)
		{

			var rayCast = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			RaycastHit raycastHit;

			if (Physics.Raycast(rayCast, out raycastHit, 10f))
			{
				IInteractable interactable = raycastHit.transform.gameObject.GetComponent<IInteractable>();
				if (interactable != null)
				{
					interactText.text = interactable.Text;

					if (Input.GetAxis("Interact") > 0)
					{
						interactable.Interact();
					}

				}
			}
			else
				interactText.text = "";

		}

	}
}
