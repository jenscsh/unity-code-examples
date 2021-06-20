using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
	//recives the gameobject with the gamescript
	public GameScript game;
	//a selection of premade words
	public List<string> selection = new List<string>();
	//the start menu
	public GameObject startMenu;
	//the custom puzzle input field
	public GameObject input;

	//picks a random word from the word selection and starts the puzzle using it, disables the main menu
	public void PickWord() {
		int r = Random.Range(0,selection.Count);
		game.WritePuzzle(selection[r]);
		startMenu.SetActive(false);
	}
	//turns the input field on and the main menu off
	public void MakeWord() {
		input.SetActive(true);
		startMenu.SetActive(false);
	}
	//loads a scene
	public void Load(string m) {
		SceneManager.LoadScene(m);
	}
}
