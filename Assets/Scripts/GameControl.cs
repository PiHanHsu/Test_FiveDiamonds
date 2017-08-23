using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {


	public GameObject TimeText;
	public GameObject ScoreText;
	public GameObject GameOverText;
	public GameObject LevelText;
	public GameObject NewGameText;
	public GameObject StartButton;

	public GameObject Target1;
	public GameObject Target2;
	public GameObject Target3;
	public GameObject Target4;
	public GameObject Target5;
	public GameObject FixObject;
	public int CurrentTarget = 0 ;

	public int NextLevel;

	public bool isPlaying = false;
	public bool isGameOver = false;
	public bool isGameComplete = false;

	public GameObject[] targetArray;
	private float time = 181f;
	private float reduceTimePeriod;


	// Use this for initialization
	void Start () {
		targetArray = new GameObject[]{ Target1, Target2, Target3, Target4, Target5 };
		foreach (GameObject target in targetArray) {
			target.SetActive (false);
		}

		if (GameScore.Score != 0) {
			ScoreText.GetComponent<TextMesh> ().text = GameScore.Score.ToString ();
		}

		LevelText.SetActive (true);
		GameOverText.SetActive (false);
		NewGameText.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (isPlaying) {
			LevelText.SetActive (false);
			time -= Time.deltaTime;
			int int_time = (int)time;
			TimeText.GetComponent<TextMesh> ().text = int_time.ToString ();
			ScoreText.GetComponent<TextMesh> ().text = GameScore.Score.ToString ();

			if (int_time == 0) {
				isPlaying = false;
				isGameOver = true;
			}

		} 

		reduceTimePeriod += Time.deltaTime;

		if (isGameComplete) {
			if (FixObject != null) {
				FixObject.SetActive (false);
			}
			if (time > 0) {
				if (reduceTimePeriod > 0.05f) {
					time--;
					int int_time = (int)time;
					TimeText.GetComponent<TextMesh> ().text = int_time.ToString ();
					GameScore.Score += 100;
					ScoreText.GetComponent<TextMesh> ().text = GameScore.Score.ToString ();
				}
			} else {
				GameOverText.SetActive (true);
				NewGameText.SetActive (true);
				if (NextLevel == 1) {
					GameOverText.GetComponent<TextMesh> ().text = "Congratulations!! \n" + "Your score is " + GameScore.Score.ToString();
					NewGameText.GetComponent<TextMesh> ().text = "Press Enter to Start a New Game!!";
				} else {
					GameOverText.GetComponent<TextMesh> ().text = "Congratulations!! \n" ;
					NewGameText.GetComponent<TextMesh> ().text = "Press Enter to Next Level! ";
				}

			}
		}
			
		if (isGameOver) {
			if (FixObject != null) {
				FixObject.SetActive (false);
			}

			GameOverText.SetActive (true);
			NewGameText.SetActive (true);
			GameOverText.GetComponent<TextMesh> ().text = "Game Over!! \n" + "Your Score is " + GameScore.Score.ToString ();
		} 

		if (Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene ("Level0" );
		}

		if (Input.GetKeyDown (KeyCode.Backspace)) {
			int currentLevel;
			if (NextLevel == 1) {
				currentLevel = 5;
			} else {
				currentLevel = NextLevel - 1;
			}

			SceneManager.LoadScene ("Level" + currentLevel.ToString());
		
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {

			if (!isPlaying && !isGameOver && !isGameComplete) {
				StartButton.SetActive (false);
				targetArray [0].SetActive (true);
				isPlaying = true;
			} else if (!isGameOver && !isGameComplete){
				targetArray [CurrentTarget].SetActive (false);

				if (CurrentTarget == 4) {
					GameScore.Score += 500;
					isPlaying = false;
					isGameComplete = true;	
				} else if (CurrentTarget < 4) {
					GameScore.Score += 200;
					CurrentTarget++;
					targetArray [CurrentTarget].SetActive (true);
				}
			} 

		}

		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit ();
		}

	}

}
