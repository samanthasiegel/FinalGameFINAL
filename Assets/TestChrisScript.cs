using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestChrisScript : MonoBehaviour {

	public GameObject DialogueBox;
	public Text NotificationText;
	public GameObject Hero;

	private bool CloseEnough;
	private bool InDialogue;


	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetBool ("Dialogue", false);
	}
	
	// Update is called once per frame
	void Update () {
		if (CloseEnough) {
			if (Input.GetKey (KeyCode.Space)) {
				StartDialogue ();
				GetComponent<Animator> ().SetBool("Dialogue", true);
				InDialogue = true;
			} else if (Input.GetKey (KeyCode.X)) {
				StopDialogue ();

				GetComponent<Animator> ().SetBool("Dialogue" , false);
				InDialogue = false;
			}
		}
	}

	void FixedUpdate(){
		if (!InDialogue) {
			RaycastHit2D hitLeft = Physics2D.Raycast (transform.position, Vector2.left, 2.5f);
			RaycastHit2D hitRight = Physics2D.Raycast (transform.position, Vector2.right, 2.5f);
			if (hitLeft.collider != null && hitLeft.collider.gameObject.CompareTag ("Hero")) {
				NotificationText.text = "Talk to " + gameObject.tag;
				CloseEnough = true;
			} else if (hitRight.collider != null && hitRight.collider.gameObject.CompareTag ("Hero")) {
				NotificationText.text = "Talk to " + gameObject.tag;
				CloseEnough = true;
			} else {
				CloseEnough = false;
				NotificationText.text = "";
			}
		}

	}

	void StartDialogue(){
		DialogueBox.SetActive (true);
		NotificationText.text = "";
		Hero.GetComponent<HeroScript> ().StopMovement ();
		Text DialogueText = DialogueBox.GetComponentInChildren<Text> ();
		DialogueText.text = "How are you doing today?";
	}

	void StopDialogue(){
		DialogueBox.SetActive (false);
		NotificationText.text = "";
		Hero.GetComponent<HeroScript> ().RestartMovement ();
	}
}
