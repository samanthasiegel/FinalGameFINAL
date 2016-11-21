using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeroScript : MonoBehaviour {

	public float playerSpeed = 100f;
	[HideInInspector] public bool InDialogue = false;
	[HideInInspector] public Rigidbody2D rb2d;

	[HideInInspector] public Collider2D hit;

	private ArrayList PeopleTags = new ArrayList();
	private ArrayList ObjectTags = new ArrayList();

	public Text NotificationText;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		PeopleTags.Add ("Chris Bridge");
		PeopleTags.Add ("Ronald Rump");
		PeopleTags.Add ("Barry Oh");
		PeopleTags.Add ("Liz Battleon");
		PeopleTags.Add ("Gary Williams");

		ObjectTags.Add ("Bookshelf");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		rb2d.velocity = new Vector2 (0, 0);
		if (!InDialogue) {
			MoveSprite ();
			SendRaycast ();
		}
	}
		
	void MoveSprite(){
		if (Input.GetKey ("up")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.up * playerSpeed);
		}
		if (Input.GetKey ("down")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.down * playerSpeed);
		}
		if (Input.GetKey ("left")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.left * playerSpeed);
		}
		if (Input.GetKey ("right")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.right * playerSpeed);
		}
	}

	void SendRaycast(){
		RaycastHit2D hitLeft = Physics2D.Raycast (transform.position, Vector2.left, 2.5f);
		RaycastHit2D hitRight = Physics2D.Raycast (transform.position, Vector2.right, 2.5f);
		RaycastHit2D hitFront = Physics2D.Raycast (transform.position, Vector2.up, 2.5f);
		if (hitLeft.collider != null) {
			string tag = hitLeft.collider.gameObject.tag;
			if (PeopleTags.Contains(tag)) {
				NotificationText.text = "Talk to " + tag;
				hit = hitLeft.collider;
				return;
			}
		}

		if (hitRight.collider != null) {
			string tag = hitRight.collider.gameObject.tag;
			if (PeopleTags.Contains(tag)) {
				NotificationText.text = "Talk to " + tag;
				hit = hitRight.collider;
				return;
			}
		}

		if (hitFront.collider != null) {
			string tag = hitFront.collider.gameObject.tag;
			if (ObjectTags.Contains (tag)) {
				NotificationText.text = "Look at " + tag.ToLower();
				hit = hitFront.collider;
				return;
			}
		}

		NotificationText.text = "";
		hit = null;
	}
		
}
