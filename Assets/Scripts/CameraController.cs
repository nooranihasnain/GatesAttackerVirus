using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject Player;
	private Vector3 Offset;
	[SerializeField]
	private float Sway = 2f;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag ("Player");
		Offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, Player.transform.position + Offset, Time.deltaTime * Sway);
	}
}
