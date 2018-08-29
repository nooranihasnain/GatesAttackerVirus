using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectRAM : MonoBehaviour {

	public GameObject RAM;
	public bool IsInfected { get; set; }

	private float Timer = 0;
	public float DelayTimer = 8f;

	public static float InfectedCount = 0;

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
			if (Timer >= DelayTimer) {
				IsInfected = true;
				Timer = 0;
				InfectedCount++;
				GetComponent<AudioSource> ().enabled = false;
				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().IncrementSpeed (4f);
				if (InfectedCount >= 3) {
					GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ().RAMInfected = true;
				}
			}
			RAM.GetComponent<Renderer> ().material.color = Random.ColorHSV ();
			GetComponent<AudioSource> ().enabled = true;
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")) {
			Timer = 0;
			if (!IsInfected) {
				RAM.GetComponent<Renderer> ().material.color = Color.black;
			}
			GetComponent<AudioSource> ().enabled = false;
		}
	}
}
