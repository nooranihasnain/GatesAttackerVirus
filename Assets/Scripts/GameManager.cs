using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool FanInfected = false;
	public bool RAMInfected = false;
	public bool HDDInfected = false;

	public GameObject FanStatusText;
	public GameObject RAMStatusText;
	public GameObject HDDStatusText;
	public GameObject TimeRemainingText;

	public GameObject TitleText;
	public GameObject PlayText;
	public GameObject QuitText;

	public GameObject Level1Mesh;
	public GameObject Level2Mesh;
	public GameObject Level3Mesh;

	//CountDown stuff
	public float GivenTime = 90f;
	private float CurrentTime = 0;

	// Use this for initialization
	void Start () {
		
	}

	void LoadBackMenu()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Playground");
		}
	}

	public IEnumerator LoadLevelFailure()
	{
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Failure");
	}

	void StartCountdown()
	{
		if (TimeRemainingText) {
			TimeRemainingText.GetComponent<Text> ().text = "Time remaining: " + GivenTime;
		}
		if (GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().IsPlaying) {
			CurrentTime += Time.deltaTime;
			if (CurrentTime >= 1) {
				CurrentTime = 0;
				GivenTime--;
			}
			if (GivenTime <= 0) {
				StartCoroutine (LoadLevelFailure ());
			}
		}
	}

	void ChangeColors()
	{
		if (TitleText) {
			TitleText.GetComponent<Text> ().color = Random.ColorHSV ();
		}
		if (PlayText) {
			PlayText.GetComponent<Text> ().color = Random.ColorHSV ();
		}
		if (QuitText) {
			QuitText.GetComponent<Text> ().color = Random.ColorHSV ();
		}
	}


	public void PlayGame()
	{
		GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().IsPlaying = true;
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	// Update is called once per frame
	void Update () {
		SetFanStatus ();
		SetRAMStatus ();
		SetHDDStatus ();
		ChangeColors ();
		LoadBackMenu ();
		CheckAllInfected ();
		StartCountdown ();
	}

	public void Loadlevel(string name)
	{
		SceneManager.LoadScene (name);
	}

	void SetHDDStatus()
	{
		if (HDDStatusText) {
			if (HDDInfected) {
				HDDStatusText.GetComponent<Text> ().text = "HDD INFECTED";
				HDDStatusText.GetComponent<Text> ().color = Color.red;
			}
			else {
				HDDStatusText.GetComponent<Text> ().text = "HDD NOT INFECTED";
				HDDStatusText.GetComponent<Text> ().color = Color.green;
			}
		}
	}

	void SetRAMStatus()
	{
		if (RAMStatusText) {
			if (RAMInfected) {
				RAMStatusText.GetComponent<Text> ().text = "RAM INFECTED";
				RAMStatusText.GetComponent<Text> ().color = Color.red;
			}
			else {
				RAMStatusText.GetComponent<Text> ().text = "RAM NOT INFECTED";
				RAMStatusText.GetComponent<Text> ().color = Color.green;
			}
		}
	}

	void SetFanStatus()
	{
		if (FanStatusText) {
			if (FanInfected) {
				FanStatusText.GetComponent<Text> ().text = "FAN INFECTED";
				FanStatusText.GetComponent<Text> ().color = Color.red;
			} 
			else {
				FanStatusText.GetComponent<Text> ().text = "FAN NOT INFECTED";
				FanStatusText.GetComponent<Text> ().color = Color.green;
			}
		}
	}

	void CheckAllInfected()
	{
		if (FanInfected && RAMInfected && HDDInfected) {
			Level1Mesh.GetComponent<Renderer> ().material.color = Random.ColorHSV ();
			Level2Mesh.GetComponent<Renderer> ().material.color = Random.ColorHSV ();
			Level3Mesh.GetComponent<Renderer> ().material.color = Random.ColorHSV ();
			StartCoroutine (LoadLevelSuccess ());
		}
	}

	IEnumerator LoadLevelSuccess()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Success");
	}
}
