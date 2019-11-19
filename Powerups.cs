using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	public float powerupLength;

	private PowerupManager thePowerupmanager;

	// Use this for initialization
	void Start () {
		thePowerupmanager = FindObjectOfType<PowerupManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			
			thePowerupmanager.ActivatePowerup (doublePoints, safeMode, powerupLength);
		}
		gameObject.SetActive (false);
	}
}
