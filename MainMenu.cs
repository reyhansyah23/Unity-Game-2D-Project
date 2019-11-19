using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public string playGameLevel;

	public void PlayGame ()
	{
		Application.LoadLevel ("Game");
	}

	public void Howtoplay()
	{
		Application.LoadLevel ("CaraBermain1");
	}

	public void About()
	{
		Application.LoadLevel ("About");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void BackMainMenu()
	{
		Application.LoadLevel ("Main Menu");
	}

	public void next1()
	{
		Application.LoadLevel ("CaraBermain2");
	}
	public void next2()
	{
		Application.LoadLevel ("CaraBermain3");
	}

}