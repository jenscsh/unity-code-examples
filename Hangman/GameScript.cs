using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {
	//the custom puzzle input box
	public GameObject input;
	//recieves the letter prefab
	public LetterScript c;
	//recieves the nonletter prefab
	public Text misc;
	//recieves the hangman parts
	public Image[] hangman=new Image[9];
	//the game end screen
	public GameObject gameEnd;
	//the text of the end screen
	public Text endText;
	//the number of times the player has made a mistake
	int wrongs=0;
	//the solution as char in a list
	List<char> solution=new List<char>();
	//the solution as letters in a list
	List<LetterScript> lettergo=new List<LetterScript>();
	//the default spawn position
	float wordPos=-350;
	//whethever the game is going or not
	bool gameStarted=false;

	
	void Update () {
		//checks every frame if the player is pressing a letter on the keyboard
		if (gameStarted && Input.anyKeyDown && Input.inputString!="" && char.IsLetter(Input.inputString[0])) {
			//in which case it converts it to lower case
			char i =char.ToLower(Input.inputString[0]);
			//if the answer was right it finds the correct letter and reveals it and checks if the player won
			if (solution.Contains(i)) {
				foreach (LetterScript g in lettergo) {
					g.RevealLetter(i);
					CheckIfWon();
				}
				//if not it sets another part of hangman to true and checks if the player has lost
			} else {
				hangman[wrongs].enabled=true;
				wrongs++;
				CheckIfLost();
			}
		}
	}
	//recieves a sring with the puzzle
	public void WritePuzzle(string sentence) {
		//takes every char in the string
		foreach (char letter in sentence) {
			//if it is a letter, it is instantiated as a letterscript and converted to lower case
			if (char.IsLetter(letter)) {
				LetterScript p = Instantiate(c,gameObject.transform);
				p.SetLetter(letter);
				p.transform.localPosition=new Vector2(wordPos,0);
				solution.Add(char.ToLower(letter));
				lettergo.Add(p);
			}
			//if it is not a letter, it is spawned as a normal text
			else {
				Text t = Instantiate(misc,gameObject.transform);
				t.text=letter.ToString();
				t.transform.localPosition=new Vector2(wordPos,0);
			}
			//moves the spawn position
			wordPos+=15;
		}
		//starts the game
		gameStarted=true;
		input.SetActive(false);
	}
	//checks if there is any inactive letters, if there isn't, it ends the game and shows the winning screen
	void CheckIfWon() {
		foreach (LetterScript n in lettergo) {
			if (!n.letter.IsActive()) {
				return;
			}
		}
		gameStarted=false;
		endText.text="You won!";
		gameEnd.SetActive(true);
	}
	//checks if there is any inactive hangman parts, if there isn't, it ends the game, reveals the solution
	//and shows the losing screen
	void CheckIfLost() {
		foreach (Image i in hangman) {
			if (!i.isActiveAndEnabled) {
				return;
			}
		}
		foreach (LetterScript l in lettergo) {
			l.RevealLetter();
		}
		gameStarted=false;
		endText.text="You lost!";
		gameEnd.SetActive(true);
	}
}
