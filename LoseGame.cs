using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour {

	public Text currentScoreText;
	public Text highScoreText;

	public void Start()
	{
		
	}

	public void onPlayAgainButtonClick()
	{
		Application.LoadLevel ("Game");
	}

	public void onMenuButtonClick()
	{
		Application.LoadLevel ("Main Menu");
	}

}
