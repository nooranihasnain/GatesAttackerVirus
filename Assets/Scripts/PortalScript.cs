using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

	public Transform DestinationPortal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.gameObject.CompareTag ("Player")) {
			GameObject Player = GameObject.FindWithTag ("Player");
			Player.transform.position = new Vector3 (DestinationPortal.position.x, Player.transform.position.y, DestinationPortal.position.z);
		}
	}
}
