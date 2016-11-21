using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//TODO: Make this cleaner and versatile to fit other situations
//TODO: Make conditions so Bernie can't exit room until talks to everyone/interacts with everything

public class GaryScript_Scene1 : MonoBehaviour {

	public class Node{
		public string Question;
		public string Answer;
		public Node[] Adj;
		public bool Asked;

		public Node(string Q, string A, int i){
			this.Question = Q;
			this.Answer = A;
			this.Adj = new Node[i];
			this.Asked = false;
		}
	}

	public class Graph{
		public Node[] root;
		public Graph(Node[] start){
			this.root = start;
		}

		public Node[] next(Node curr){
			if (curr.Adj.Length > 0) {
				return curr.Adj;
			}
			for (int i = 0; i < root.Length; i++) {
				if (!root [i].Asked) {
					return root;
				}
			}
			return null;
		}
	}

	private Graph graph;
	public GameObject ButtonContainer;
	public GameObject NextButton;
	public Text JustText;
	public Node CurrentNode;
	public Node[] CurrentList;
	public Node[] OriginalList;
	public bool ShowQuestions;

	void Start(){
		Node n0 = new Node ("What brings you to Foxville Estates?", "Um, what is Foxville Estates?", 2);
		Node n1 = new Node ("Are you serious?", "Oh, it's where we are now, right... I'm here for the dinner party.", 0);
		Node n2 = new Node ("Jon Hannity's house? Where we are now?", "Oh, it's where we are now, right... I'm here for the dinner party.", 0);
		Node n3 = new Node ("Have you stayed in contact with Jon?", "No, I haven't spoken to him since high school." +
		          " I was surprised by the invitation too!", 0);
		n0.Adj [0] = n1;
		n0.Adj [1] = n2;
		OriginalList = new Node[2];
		OriginalList[0] = n0;
		OriginalList [1] = n3;
		CurrentList = OriginalList;
	}

	void Update(){
		if (GetComponent<SpriteScript> ().InDialogue && ShowQuestions) {

			JustText.text = "";
			Button[] buttons = ButtonContainer.GetComponentsInChildren<Button> ();
			int i = 0;
			for (int j = 0; j < CurrentList.Length; j++) {
				if (!CurrentList [j].Asked) {
					buttons [i++].GetComponentInChildren<Text> ().text = CurrentList [j].Question;
				}
			}
			while (i < 2) {
				buttons [i].GetComponentInChildren<Text> ().text = "";
				buttons [i++].interactable = false;
			}
		}
	}

	public void Option1Clicked(){
		string clicked = ButtonContainer.GetComponentsInChildren<Button> () [0].GetComponentInChildren<Text> ().text;
		FindUserInput (clicked);
	}

	public void Option2Clicked(){
		string clicked = ButtonContainer.GetComponentsInChildren<Button> () [1].GetComponentInChildren<Text> ().text;
		FindUserInput (clicked);
	}

	void FindUserInput(string clicked){
		for (int i = 0; i < CurrentList.Length; i++) {
			if (CurrentList [i].Question.Equals (clicked)) {
				// show answer
				ButtonContainer.SetActive(false);
				CurrentList [i].Asked = true;
				JustText.text = CurrentList [i].Answer;
				CurrentNode = CurrentList [i];
				ShowQuestions = false;
				NextButton.SetActive (true);
				// wait until click next
				return;
			}
		}
	}

	public void NextClicked(){
		JustText.text = "";
		NextButton.SetActive (false);
		ButtonContainer.SetActive (true);
		if (CurrentNode.Adj.Length > 0) {
			CurrentList = CurrentNode.Adj;
		} else {
			CurrentList = OriginalList;
		}
		ShowQuestions = true;
	}

}
