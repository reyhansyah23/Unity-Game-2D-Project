using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour {

	public Text[] numbersText = new Text[5];
	public int[] numbers = new int[5];

	public float time;
	public float roundLength;

	public Text timeText;

	//buttons


	public Button[] buttons;
	public float[] Answers;
	public float result;
	public float score;
	public Text scoreText;

	public float Level;
	public int[] maxScore = new int[30];
	public Text levelText;

	public AudioSource source;
	public AudioClip[] clips = new AudioClip[2];

	// Use this for initialization
	void Start () {

		time = 0.1f;
		source = gameObject.AddComponent<AudioSource> ();

		for (int i = 1; i < maxScore.Length; i++) 
		{
			maxScore [i] = (i + 6) * (i + 1);
		}

		//time = roundLength;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (score >= 20) 
		{
			Application.LoadLevel ("#15");
		}
		time -= Time.deltaTime;
		timeText.text = "Waktu :" + time.ToString ();
		displayResults ();

		for (int i = 0; i < maxScore.Length; i++) 
		{
			if (score >= maxScore [i]) 
			{
				Level = i + 1;
				levelText.text = "Level " + Level.ToString ();
			}

		}

		if (time <= 0) 
		{
			time = roundLength;
			randomNums ();
			result = ((numbers [0] * numbers [1]) + numbers [2]) - numbers [3];
			displayResults ();

			Answers [0] = result;
			Answers [1] = result + Random.Range (1, 6);
			Answers [2] = result - Random.Range (1, 6);
			ShuffleArray (Answers);

			for (int i = 0; i < buttons.Length; i++) 
			{
				buttons [i].image.color = Color.white;
			}

		}


		
	}

	void randomNums()
	{
		for (int i = 0; i < numbers.Length; i++) 
		{
			numbers [i] = Random.Range (1, 10);
			numbersText [i].text = numbers [i].ToString ();

		}
	}


	void displayResults	()
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			buttons [i].transform.GetChild(0).GetComponent<Text> ().text = Answers[i].ToString ();
		}
	}

	public static void ShuffleArray<T>(T[] arr)
	{	 
		for (int i = arr.Length - 1; i > 0; i--) 
		{
			int r = Random.Range (0, i);
			T tmp = arr [i];
			arr [i] = arr [r];
			arr [r] = tmp;
		}
	}

	public void ButtonCheck(int buttonNum)
	{
		if (buttons [buttonNum].transform.GetChild (0).GetComponent<Text> ().text == result.ToString ()) 
		{
			Debug.Log ("Correct !");
			buttons [buttonNum].image.color = Color.green;
			score += 5;
			scoreText.text = "Skor :" + score.ToString ("0");
			source.PlayOneShot (clips [0]);
		} 
		else 
		{
			Debug.Log ("Wrong !");
			buttons [buttonNum].image.color = Color.red;
			score -= 2;
			scoreText.text = "Skor :" + score.ToString ("0");
			source.PlayOneShot (clips [1]);
		}
		time = 0.3f;
		if (score >= 0) 
		{
			scoreText.color = Color.green;
		} else 
		{
			scoreText.color = Color.red;
		}
	}
}
