using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectHDD : MonoBehaviour {

	public GameObject HDD;
	private GameObject Player;

	//Delay stuff
	private float CurrentTimer = 0f;
	[SerializeField]
	private float TotalDelay = 6f;
	public bool IsInfected = false;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")  && !IsInfected) {
			CurrentTimer += Time.deltaTime;
			if (CurrentTimer >= TotalDelay) {
				CurrentTimer = 0;
				IsInfected = true;
				GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ().HDDInfected = true;
				Player.GetComponent<PlayerController> ().IncrementSpeed (2f);
				GetComponent<AudioSource> ().enabled = false;
			}
			HDD.GetComponent<Renderer> ().material.color = Random.ColorHSV ();
			GetComponent<AudioSource> ().enabled = true;
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")) {
			CurrentTimer = 0f;
			if (!IsInfected) {
				HDD.GetComponent<Renderer> ().material.color = Color.black;
			}
			GetComponent<AudioSource> ().enabled = false;
		}
	}
}
