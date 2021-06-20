using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterScript : MonoBehaviour {
	//recieves the text that is a child of the gameobject
	public Text letter;
	//the letter it is holding
	public char c;

	//sets the letter and converts it to lower case
	public void SetLetter(char f) {
		letter.text=f.ToString();
		c=char.ToLower(f);
	}
	//sets the letter text to active if it is the right one
	public void RevealLetter(char s) {
		if (s==c) {
			letter.gameObject.SetActive(true);
		}
	}
	//sets the letter text to active
	public void RevealLetter() {
		letter.gameObject.SetActive(true);
	}
}
