using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickScript : MonoBehaviour {
	//gets a rank that indicates it's size
	public int rank;
	//sets a color
	Color colorSelf;

	//set the original color of the brick
	void Start () {
		colorSelf=GetComponent<Image>().color;
	}
	//changes the color to white if it isn't white, or back to the original color if it is
	public void SetColor() {
		if (GetComponent<Image>().color==colorSelf) {
			GetComponent<Image>().color=Color.white;
		} else {
			GetComponent<Image>().color=colorSelf;
		}
	}
}
