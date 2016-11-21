using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChrisScript_Scene1 : MonoBehaviour {

	public Text DialogueText;
	private string Quote = "Did you have traffic on the way here? I took the bridge, all clear for me!"; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.text = Quote;
		}
	}
}
