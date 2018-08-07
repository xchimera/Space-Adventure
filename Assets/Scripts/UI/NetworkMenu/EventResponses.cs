using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventResponses : MonoBehaviour {

	public void StartScene(int sceneNumber)
	{
		SceneManager.LoadScene(sceneNumber);
	}

}
