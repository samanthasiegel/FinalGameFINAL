using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExitScript : MonoBehaviour {

	public Text DialogueText;

	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
//			Debug.Log ("HERE");
//			ProgressNode node = GameManager.GetComponent<GameManagerScript> ().progressNode;
//			node.SceneNumber++;
//			node.ObjectiveNumber = 1;
//			PlayerPrefs.SetInt ("SceneProgress", node.SceneNumber);
//			PlayerPrefs.SetInt ("ObjectiveProgress", node.ObjectiveNumber);
//			Debug.Log (node.SceneNumber);
			HashSet<string> visited = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroScript>().visited;
			if (!visited.Contains ("Liz Battleon")) {
				DialogueText.text = "You should talk to Liz before leaving the room.";
				return;
			} else if (!visited.Contains ("Gary Williams")) {
				DialogueText.text = "Didn't Liz say Gary wanted to speak with you?";
				return;
			}
			Debug.Log (visited.Count);
			if (visited.Count < 6) {
				DialogueText.text = "I have this nagging feeling like I'm forgetting something in this room..."
				+ "Did I talk to everyone? That bookshelf looks interesting too.";
				return;
			}
			SceneManager.LoadScene (3);
				
		}

	}
}
