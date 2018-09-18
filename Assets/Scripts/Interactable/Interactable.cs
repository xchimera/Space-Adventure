using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable {
	[SerializeField]
	private string _text;

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
}
