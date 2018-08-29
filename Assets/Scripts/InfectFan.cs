using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectFan : MonoBehaviour {

	public GameObject[] AllFans = new GameObject[2];
	public bool IsInfected { get; set; }

	private float Timer = 0;
	public float WaitTime = 5f;

	// Use this for initialization
	void Start () {
		IsInfected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player") && !IsInfected) {
			Timer += Time.deltaTime;
			if (Timer >= WaitTime) {
				Timer = 0;
				IsInfected = true;
				GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ().FanInfected = true;
				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().IncrementSpeed (1);
				GetComponent<AudioSource> ().enabled = false;
			}
			for (int i = 0; i < AllFans.Length; i++) {
				AllFans [i].GetComponent<Renderer> ().material.color = Random.ColorHSV ();
				AllFans [i].GetComponent<Animator> ().enabled = false;
			}
			GetComponent<AudioSource> ().enabled = true;
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")) {
			Timer = 0;
			if (!IsInfected) {
				for (int i = 0; i < AllFans.Length; i++) {
					AllFans [i].GetComponent<Renderer> ().material.color = Color.black;
					AllFans [i].GetComponent<Animator> ().enabled = true;
				}
			}
			GetComponent<AudioSource> ().enabled = false;
		}
	}
}
