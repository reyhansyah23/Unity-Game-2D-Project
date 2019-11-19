using System.Collections;
using UnityEngine;

public class MoveBar1 : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		gameObject.transform.position += new Vector3 (speed, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log ("Collided !");
		speed = speed * -1;
	}
}
