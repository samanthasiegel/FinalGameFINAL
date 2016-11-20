using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour {

	public float playerSpeed = 10f;
	private bool CanMove = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (CanMove) {
			if (Input.GetKey ("up")) {//Press up arrow key to move forward on the Y AXIS
				transform.Translate (0, playerSpeed * Time.deltaTime, 0);
			}
			if (Input.GetKey ("down")) {//Press up arrow key to move forward on the Y AXIS
				transform.Translate (0, -playerSpeed * Time.deltaTime, 0);
			}
			if (Input.GetKey ("left")) {//Press up arrow key to move forward on the Y AXIS
				transform.Translate (-playerSpeed * Time.deltaTime, 0, 0);
			}
			if (Input.GetKey ("right")) {//Press up arrow key to move forward on the Y AXIS
				transform.Translate (playerSpeed * Time.deltaTime, 0, 0);
			}
		}
	}
		
	public void RestartMovement(){
		CanMove = true;
	}

	public void StopMovement(){
		CanMove = false;
	}
		
}
