using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitInteractable : MonoBehaviour, IInteractable {
	[SerializeField]
	private string _text;
	[SerializeField]
	private GameEvent changeToShipCameraEvent;

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
		}
	}

	public void Interact()
	{
		changeToShipCameraEvent.Raise();
	}
}
