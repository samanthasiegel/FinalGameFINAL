using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SingleLineScript : MonoBehaviour {

	public Text DialogueText;
	public GameObject DialogueContainer;
	public string Quote;
	public Font font;

	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueContainer.SetActive (true);
			DialogueText.font = font;
			DialogueText.text = Quote;
		} else if(DialogueContainer.activeSelf){
			DialogueContainer.SetActive (false);
		}
	}
}
