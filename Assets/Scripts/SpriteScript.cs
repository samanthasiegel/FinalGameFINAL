using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteScript : MonoBehaviour{

	public bool IsAnimated;

	private Animator SpriteAnimator;
	public Text NotificationText;

	[HideInInspector] public bool InDialogue;

	void Start(){
		if(IsAnimated){
			SpriteAnimator = GetComponent<Animator>();
			SpriteAnimator.SetBool("Dialogue", false);
		}
	}

	public void StartDialogue(){
		if(IsAnimated){
			SpriteAnimator.SetBool("Dialogue", true);
		}
		InDialogue = true;
		NotificationText.text = "";
	}

	public void ExitDialogue(){
		if(IsAnimated){
			SpriteAnimator.SetBool("Dialogue", false);
		}
		InDialogue = false;
		if(!this.gameObject.tag.Equals("Exit")){
			GameObject Hero = GameObject.FindGameObjectWithTag("Hero");
			Hero.GetComponent<HeroScript>().Visited.Add(this.gameObject.tag);
		}
	}
}