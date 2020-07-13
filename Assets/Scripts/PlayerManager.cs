using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Keeps track of the player */

public class PlayerManager : MonoBehaviour {

	#region Singleton

	public static PlayerManager instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	public GameObject player;
	public static int kills;
	public TextMeshProUGUI score;

	private void Update()
	{
		score.text = string.Concat("SCORE: ", kills.ToString());
	}

	public void KillPlayer ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
