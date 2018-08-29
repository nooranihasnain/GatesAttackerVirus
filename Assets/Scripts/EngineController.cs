using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour {

	private GameObject Player;
	private Light EngineLight;
	public Material TransparentMaterial;
	public Material NormalMaterial;

	public bool EngineOn { get; set; }

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag ("Player");
		EngineLight = GetComponent<Light> ();
		EngineLight.type = LightType.Point;
	}
	
	// Update is called once per frame
	void Update () {
		Controls ();
	}

	void Controls()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (EngineOn) {
				Player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				EngineOn = false;
				EngineLight.intensity = 0f;
				Player.GetComponent<Renderer> ().material = TransparentMaterial;
			} 
			else {
				EngineOn = true;
				EngineLight.intensity = 5f;
				Player.GetComponent<Renderer> ().material = NormalMaterial;
			}
		}
	}
}
