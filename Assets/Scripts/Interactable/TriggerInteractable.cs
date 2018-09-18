using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractable : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		other.GetComponent<InteractScript>().IsInInteractableZone = true;
	}

	private void OnTriggerExit(Collider other)
	{
		other.GetComponent<InteractScript>().IsInInteractableZone = false;
	}
}
