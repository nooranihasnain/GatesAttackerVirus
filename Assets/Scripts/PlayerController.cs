using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	Left,	//negative of z axis
	Right,	//positive of z axis
	Up,		//negative of x axis
	Down	//positive of x axis
};

public class PlayerController : MonoBehaviour {

	private Rigidbody PlayerRb;
	[SerializeField]
	private float MovementSpeed = 3f;
	public Direction CurrDir = Direction.Up;
	public bool IsPlaying = false;

	public GameObject Engine;

	// Use this for initialization
	void Start () {
		PlayerRb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (IsPlaying && Engine.GetComponent<EngineController>().EngineOn) {
			SetVelocity ();
		}
	}

	public void IncrementSpeed(float Inc)
	{
		MovementSpeed += Inc;
	}

	void Update()
	{
		if (IsPlaying && Engine.GetComponent<EngineController>().EngineOn) {
			KeyboardControls ();
		}
		SetCamStatus ();
	}

	void SetVelocity()
	{
		Vector3 CDirection = new Vector3 ();
		switch (CurrDir) {
			case Direction.Up:	//-ve x
			{
				CDirection = new Vector3 (-1, 0, 0);
				PlayerRb.velocity = CDirection * MovementSpeed;
				break;
			}
			case Direction.Down:	//+ve x
			{
				CDirection = new Vector3 (1, 0, 0);
				PlayerRb.velocity = CDirection * MovementSpeed;
				break;
			}
			case Direction.Left:	//-ve z
			{
				CDirection = new Vector3 (0, 0, -1);
				PlayerRb.velocity = CDirection * MovementSpeed;
				break;
			}
			default:	//+ve z
			{
				CDirection = new Vector3 (0, 0, 1);
				PlayerRb.velocity = CDirection * MovementSpeed;
				break;
			}
		}
	}

	void SetCamStatus()
	{
		if (IsPlaying) {
			float CurrOrthoSize = Camera.main.orthographicSize;
			Camera.main.orthographicSize = Mathf.Lerp (CurrOrthoSize, 30f, 2 * Time.deltaTime);
		}
	}

	void KeyboardControls()
	{
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			CurrDir = Direction.Up;
			PlayerRb.rotation = Quaternion.Euler (-90, 0, 0);
		} 
		else if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			CurrDir = Direction.Down;
			PlayerRb.rotation = Quaternion.Euler (-90, 180, 0);
		} 
		else if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			CurrDir = Direction.Left;
			PlayerRb.rotation = Quaternion.Euler (-90, -90, 0);
		} 
		else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			PlayerRb.rotation = Quaternion.Euler (-90, 90, 0);
			CurrDir = Direction.Right;
		}
	}
}
