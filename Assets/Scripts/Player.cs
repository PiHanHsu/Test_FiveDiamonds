using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject GameControl;


	private GameControl gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameControl.GetComponent<GameControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (gameControl.isGameComplete || gameControl.isGameOver) {
			this.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "StartButton") {
			col.gameObject.SetActive (false);
			gameControl.isPlaying = true;
			gameControl.targetArray [0].SetActive (true);
		}

		if (col.tag == "Target") {
			//col.gameObject.SetActive (false);
			gameControl.targetArray [gameControl.CurrentTarget].SetActive (false);
			GameScore.Score += 200;
			gameControl.CurrentTarget++;
			if (gameControl.CurrentTarget < gameControl.targetArray.Length) {
				gameControl.targetArray [gameControl.CurrentTarget].SetActive (true);
			}
		}

		if (col.tag == "RedTarget") {
			gameControl.targetArray [gameControl.CurrentTarget].SetActive (false);
			GameScore.Score += 500;
			gameControl.isPlaying = false;
			gameControl.isGameComplete = true;
		}

		if (col.tag == "Fire") {
			gameControl.targetArray [gameControl.CurrentTarget].SetActive (false);
			gameControl.isPlaying = false;
			gameControl.isGameOver = true;
		}
	}
}
