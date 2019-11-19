using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text mathText;
	public Text resultText;
	public Text scoreText;

	public GameObject timeProgress;
	private float limitTime;
	private float currentTime;

	private int leftNumber;
	private int rightNumber;
	private int mathOperator;
	private int trueResult;
	private int falseResult;

	private int currentScore;

	public AudioSource source;
	public AudioClip[] clips = new AudioClip[2];


	public void Start()
	{
		source = gameObject.AddComponent<AudioSource> ();
		limitTime = 20.0f;
		currentTime = 0.0f;

		currentScore = 0;
		createMath ();
	}

	public void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > limitTime) 
		{
			LoseGame();
		} 
		else 
		{
			float scaleProgressTime = 1.0f - currentTime / limitTime;
			timeProgress.transform.localScale = new Vector3 (scaleProgressTime, 1, 1);
		}
		if (currentScore == 5) 
		{
			Application.LoadLevel ("Math");
		}

	}

	public void createMath()
	{
		leftNumber = Random.Range (1, 10);
		rightNumber = Random.Range (1, 10);

		mathOperator = Random.Range (1, 3);

		switch (mathOperator) 
		{
		case 0:
			trueResult = leftNumber + rightNumber;
			falseResult = trueResult + Random.Range (-2, 3);
			mathText.GetComponent<Text> ().text = 
				leftNumber.ToString () + 
				" + " + 
				rightNumber.ToString ();
			
			resultText.GetComponent<Text> ().text = 
				falseResult.ToString ();

			break;

		case 1:
			trueResult = leftNumber - rightNumber;
			falseResult = trueResult + Random.Range (-2, 3);
			mathText.GetComponent<Text> ().text = 
				leftNumber.ToString () + 
				" - " + 
				rightNumber.ToString ();

			resultText.GetComponent<Text> ().text = 
				falseResult.ToString ();
			
			break;

		case 2:
			trueResult = leftNumber * rightNumber;
			falseResult = trueResult + Random.Range (-2, 3);
			mathText.GetComponent<Text> ().text = 
				leftNumber.ToString () + 
				" x " + 
				rightNumber.ToString ();

			resultText.GetComponent<Text> ().text = 
				falseResult.ToString ();
			break;

		default:
			break;
		}

		scoreText.GetComponent<Text> ().text = currentScore.ToString ();
	}

	public void LoseGame()
	{
		GameValues.currentScore = currentScore;
		int highScore = PlayerPrefs.GetInt ("High_Score", 0);
		if (currentScore > highScore) 
		{
			PlayerPrefs.SetInt ("High_Score", currentScore);
		}

		Application.LoadLevel ("LoseGame");
	}

	public void onTrueButtonClick()
	{
		if (trueResult == falseResult) 
		{
			currentTime = 0;
			currentScore += 1;
			createMath ();
			source.PlayOneShot (clips [0]);
		} 
		else 
		{
			source.PlayOneShot (clips [1]);
			LoseGame ();
		}
	}

	public void onFalseButtonClick()
	{
		if (trueResult != falseResult) 
		{
			currentTime = 0;
			currentScore += 1;
			createMath ();
			source.PlayOneShot (clips [0]);
		}
		else 
		{
			source.PlayOneShot (clips [1]);
			LoseGame ();
		}
	}

}
