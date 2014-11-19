using UnityEngine;
using System.Collections;

public class ControllerGyroscope : GUIBase {
	public GameObject o;
	private float speed = 90;
	private Vector3 v3;
	// Use this for initialization
	void Start () {
		Controller.Get().startTimer();
	}
	protected override void OnDraw ()
	{
		//GUI.Label (new Rect(0,300,1000,1000), "X:" + v3.x + "\nY:" + v3.y + "\nZ:" + v3.z);
		base.OnDraw ();
	}
	// Update is called once per frame
	void Update () {
		v3 = Input.gyro.rotationRate;
		//Vector3 mov = new Vector3 (Input.gyro.rotationRate.x, Input.gyro.rotationRate.y, 0);
		//o.transform.RotateAround (Vector3.zero, mov, -speed * Time.deltaTime);
		o.transform.rotation = Input.gyro.attitude * Quaternion.Euler (0, 0, 90);
	}
}
