using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	//Recieves all the bricks in the scene
	public BrickScript[] brickA=new BrickScript[5];
	//the starting tower
	public TowerScript firstTower;
	//the tower where all the bricks should end up
	public TowerScript finalTower;
	//the counter display
	public UnityEngine.UI.Text counter;
	//the click detectors
	public GameObject clicks;
	//the win message
	public GameObject endScreen;
	//the moves count
	int count=0;
	//tower to take brick from
	TowerScript lastTower;
	//if a tower is picked
	bool towerPicked=false;
	//the currently selected brick
	BrickScript brick;

	//sets all the bricks in place
	void Start () {
		for (int c=4;c>=0;c--) {
			firstTower.SetIn(brickA[c]);
		}
	}
	//initializes when a tower is clicked, recieves a tower
	public void PickTower(TowerScript t) {
		//if a tower isn't already picked and it isn't empty, mark the brick
		if (!towerPicked&&t.GetTop()!=null) {
			towerPicked=true;
			brick=t.GetTop();
			brick.SetColor();
			lastTower=t;
		}
		//if the player clicks the same tower twice,everything is reset and nothing else happens
		 else if(towerPicked&&t==lastTower) {
			brick.SetColor();
			brick=null;
			towerPicked=false;
		}
		//if a tower is picked and the player clicks another tower, the script moves the brick to the recived, removes it from the last tower
		//if the top brick isn't smaller than the brick being sent, then clean up and check if the player has won
		 else if(towerPicked) {
			t.SetIn(brick);
			if (t.GetTop()==brick) {
				lastTower.Remove();
				count++;
				counter.text=count.ToString();
			}
			brick.SetColor();
			CheckIfWon();
			brick=null;
			lastTower=null;
			towerPicked=false;
		}
	}
	void CheckIfWon() {
		//checks if there are any empty spots in the final tower, if it is the metod is cancelled
		foreach (BrickScript b in finalTower.bricks) {
			if (b==null) {
				return;
			}
		}
		//deactivates the game and show win screen if the method wasn't cancelled
		clicks.SetActive(false);
		endScreen.SetActive(true);
	}
}
