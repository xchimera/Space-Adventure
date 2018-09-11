using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunEvents : Photon.MonoBehaviour {

	private readonly byte PlayerEnteredShip = 0;
	private readonly byte PlayerExitedShip = 1;

	public void RaisePunEvent()
	{
		
	}

	public void RaisePlayerEnteredShipEvent(int playerViewId, int shipViewId)
	{
		object[] content = new object[] { playerViewId, shipViewId };
	}
}
