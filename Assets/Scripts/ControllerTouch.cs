using UnityEngine;
using System.Collections;

public class ControllerTouch : GUIBase {
	Vector2 oriPos;
	public GameObject o;
	private float speed = 1;
	// Use this for initialization
	private int screenTouched = 0;
	void Start () {
	
	}
	protected override void OnDraw ()
	{
		//GUI.Label (new Rect (0, 300, 200, 100), "Screen Touched:" + screenTouched.ToString ());
		base.OnDraw ();
	}
	// Update is called once per frame
	void Update () {
		if (Controller.ControlMode == 0) {
						if (Input.touchCount > 0) {
								Touch t = Input.GetTouch (0);
								if (t.phase == TouchPhase.Began) {
					oriPos = t.position;
					Controller.count++;
					Controller.Get().startTimer();
								} else if (t.phase == TouchPhase.Moved) {
										o.transform.RotateAround (Vector3.zero, new Vector3 (0, 1, 0), (oriPos.x - t.position.x) * speed * Time.deltaTime);
										o.transform.RotateAround (Vector3.zero, new Vector3 (-1, 0, 0), (oriPos.y - t.position.y) * speed * Time.deltaTime);
								} else if (t.phase == TouchPhase.Ended) {

								}
						}
				} else {
			screenTouched = 0;
				}

	}
}
