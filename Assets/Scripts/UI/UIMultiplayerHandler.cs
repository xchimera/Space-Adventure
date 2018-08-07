using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class UIMultiplayerHandler : MonoBehaviour {

	static string playerNamePrefKey = "PlayerName";

	void Start()
	{
		string defaultName = "";
		InputField _inputField = this.GetComponent<InputField>();
		if (_inputField != null)
		{
			if (PlayerPrefs.HasKey(playerNamePrefKey))
			{
				defaultName = PlayerPrefs.GetString(playerNamePrefKey);
				_inputField.text = defaultName;
			}
		}


		PhotonNetwork.playerName = defaultName;
	}

	public void SetPlayerName(string value)
	{
		//if (value.Replace(" ", "") == "")
		//	return;

		// #Important
		PhotonNetwork.playerName = value;


		PlayerPrefs.SetString(playerNamePrefKey, value);
	}

	public void StartScene(int sceneNumber)
	{
		SceneManager.LoadScene(sceneNumber);
	}
}
