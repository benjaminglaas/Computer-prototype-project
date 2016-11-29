using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public Text StartText;
	string text;

	// Use this for initialization
	void Start () {
		StartText.supportRichText = true;
		text = "This is you. You need to surive in this box for as long as possible.\n\n"+
			"You can rotate the box 90 degrees to the right by pressing the <color=orange> D button</color> and to the left using the <color=orange> A  button</color>.\n\n" +
			"Move the player using the <color=orange> arrow keys </color>. The game ends when you hit an enemy or touch the red boundary of the box. Good luck!\n\n" + 	
			"<color=blue> Press P to play </color>";
		StartText.text = text;
	}

	void Update(){
		if(Input.GetKeyDown (KeyCode.P)) {
			SceneManager.LoadScene ("scenelayout",LoadSceneMode.Single);
		}
	}

}
