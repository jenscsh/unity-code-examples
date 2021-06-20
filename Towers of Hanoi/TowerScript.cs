using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {
	//holds the five possible positions for the tower
	public Transform[] pos=new Transform[5];
	//holds the bricks the tower currently has
	public BrickScript[] bricks=new BrickScript[5];

	//recieves a brick
	public void SetIn(BrickScript b) {
		//if the first spot is empty, the brick is placed here
		if (bricks[4]==null) {
			bricks[4]=b;
			b.transform.position=pos[4].position;
		}
		//if not it looks for the top empty spot and checks if the brick below it is ranked lower
		else for(int i=3;i>=0;i--) {
			//if it isn't, it places the brick on top and cancels the method
			if (bricks[i]==null&&GetTop().rank>b.rank) {
				bricks[i]=b;
				bricks[i].transform.position=pos[i].position;
				return;
			}
			//if it is, it cancels the method
			else if (b.rank>GetTop().rank){
				return;
			}
		}
	}
	//goes through the bricks array, if it finds a value that isn't empty, it removes it, then cancels
	public void Remove() {
		for (int y=0;y<5;y++) {
			if (bricks[y]!=null) {
				bricks[y]=null;
				return;
			}
		}
	}
	//returns the top brick, if there isn't any, it returns a null value
	public BrickScript GetTop() {
		foreach (BrickScript brick in bricks) {
			if (brick!=null) {
				return brick;
			}
		}
		return null;
	}
}
