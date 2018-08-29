using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightDetector : MonoBehaviour {

	public Material SpotLightWhite;
	public Material SpotLightRed;

	private GameObject EngineObj;

	// Use this for initialization
	void Start () {
		EngineObj = GameObject.FindWithTag ("Engine");
		GetComponent<Renderer> ().material = SpotLightWhite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")) {
			if (EngineObj.GetComponent<EngineController> ().EngineOn) {
				GetComponent<Renderer> ().material = SpotLightRed;
				GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Die");
				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().enabled = false;
				GameObject.FindWithTag ("Player").GetComponent<AudioSource> ().enabled = true;
				GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ().velocity = Vector3.zero;
				StartCoroutine (GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ().LoadLevelFailure ());
			} 
			else {
				GetComponent<Renderer> ().material = SpotLightWhite;
			}
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")) {
			if (EngineObj.GetComponent<EngineController> ().EngineOn) {
				GetComponent<Renderer> ().material = SpotLightWhite;
			}
		}
	}
}
