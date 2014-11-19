using UnityEngine;
using System.Collections;

public class ControllerAccelerometer : MonoBehaviour {
	public GameObject o;
	private float speed = 90;
	private Vector3 lastDir = Vector3.zero;
	// Use this for initialization
	void Start () {
		Controller.Get().startTimer();
	}
	void OnGUI(){
	}
	// Update is called once per frame
	void Update () {
		if (lastDir.y * Input.acceleration.y <= 0 || lastDir.x * Input.acceleration.x <= 0) {
			Controller.count++;
			lastDir = Input.acceleration;
		}
		Vector3 mov = new Vector3 (Mathf.Abs (-Input.acceleration.y) > 0.2f ? -Input.acceleration.y : 0, Mathf.Abs (Input.acceleration.x) > 0.2f ? Input.acceleration.x : 0, 0);
		o.transform.RotateAround (Vector3.zero, mov, -speed * Time.deltaTime);

	}
}
