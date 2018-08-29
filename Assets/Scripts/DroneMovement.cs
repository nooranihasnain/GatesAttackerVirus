using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DroneDirection
{
	Horizontal,
	Vertical
};

public class DroneMovement : MonoBehaviour {

	private Rigidbody DroneRb;
	[SerializeField]
	private float DroneSpeed = 3f;
	[SerializeField]
	private float DistanceMagnitude = 40f;
	public DroneDirection CurrDir = DroneDirection.Vertical;
	private bool IsUp = true;
	private bool IsLeft = true;
	private float UpperLimit;
	private float LowerLimit;
	private float LeftLimit;
	private float RightLimit;

	// Use this for initialization
	void Start () {
		DroneRb = GetComponent<Rigidbody> ();
		Vector3 CurrentPosition = DroneRb.position;
		if (CurrDir == DroneDirection.Vertical) {
			UpperLimit = CurrentPosition.x - DistanceMagnitude;
			LowerLimit = CurrentPosition.x + DistanceMagnitude;
		}
		if (CurrDir == DroneDirection.Horizontal) {
			LeftLimit = CurrentPosition.z - DistanceMagnitude;
			RightLimit = CurrentPosition.z + DistanceMagnitude;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrDir == DroneDirection.Vertical) {
			AlternateMovementVertical ();
		}
		else {
			AlternateMovementHorizontal ();
		}
	}

	void AlternateMovementHorizontal()
	{
		Vector3 CurrentPosition = DroneRb.position;
		Vector3 LeftDirection = new Vector3 (0, 0, -1);
		Vector3 RightDirection = new Vector3 (0, 0, 1);
		if (IsLeft) {
			DroneRb.velocity = LeftDirection * DroneSpeed;
		}
		else {
			DroneRb.velocity = RightDirection * DroneSpeed;
		}

		if (CurrentPosition.z >= RightLimit) {
			IsLeft = true;
		}
		if (CurrentPosition.z <= LeftLimit) {
			IsLeft = false;
		}
	}

	void AlternateMovementVertical()
	{
		Vector3 CurrentPosition = DroneRb.position;
		Vector3 UpwardDirection = new Vector3 (-1, 0, 0);
		Vector3 DownwardDirection = new Vector3 (1, 0, 0);
		if (IsUp) {
			DroneRb.velocity = UpwardDirection * DroneSpeed;
		}
		else {
			DroneRb.velocity = DownwardDirection * DroneSpeed;
		}

		if (CurrentPosition.x <= UpperLimit) {
			IsUp = false;
		}
		if (CurrentPosition.x >= LowerLimit) {
			IsUp = true;
		}
	}
}
