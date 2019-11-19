using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {
	public string mainMenuLevel;

	public void RestartGame()
	{
		Time.timeScale = 1f;
		 
		FindObjectOfType<GameManager> ().Reset();
	}

	public void RestartBegin()
	{
		Application.LoadLevel ("Game");
	}

	public void QuitToMain()
	{
		Application.LoadLevel (mainMenuLevel);
	}

}
