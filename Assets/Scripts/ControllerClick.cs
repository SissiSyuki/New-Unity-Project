using UnityEngine;
using System.Collections;

public class ControllerClick : GUIBase {
	public GameObject o;
	public GUISkin gSkin;
	private float speed = 90;
	private int btnClicked = 0;
	private bool btnUpPressed = false, btnDownPressed = false, btnLeftPressed = false, btnRightPressed = false;
	// Use this for initialization
	void Start () {

	}
	protected override void OnDraw ()
	{
		GUI.skin = gSkin;
		if (Controller.ControlMode == 1) {
			if (GUI.RepeatButton (new Rect (640 - 200, 1136 - 400, 100, 100), "↑")) {
				o.transform.RotateAround (Vector3.zero, new Vector3 (1, 0, 0), speed * Time.deltaTime);
				Controller.Get().startTimer();
				if (!btnUpPressed){
					Controller.count++;
					Debug.Log("Count" + Time.realtimeSinceStartup);
				}
				btnUpPressed = true;
			}
			else if (Event.current.type == EventType.Repaint){
				btnUpPressed = false;
			}
			if (GUI.RepeatButton (new Rect (640 - 200, 1136 - 200, 100, 100), "↓")) {
				o.transform.RotateAround (Vector3.zero, new Vector3 (1, 0, 0), -speed * Time.deltaTime);
				Controller.Get().startTimer();
				if (!btnDownPressed){
					Controller.count++;
				}
				btnDownPressed = true;
			}
			else if (Event.current.type == EventType.Repaint){
				btnDownPressed = false;
			}
			if (GUI.RepeatButton (new Rect (640 - 300, 1136 - 300, 100, 100), "←")) {
				o.transform.RotateAround (Vector3.zero, new Vector3 (0, 1, 0), speed * Time.deltaTime);
				Controller.Get().startTimer();
				if (!btnLeftPressed){
					Controller.count++;
				}
				btnLeftPressed = true;
			}
			else if (Event.current.type == EventType.Repaint){
				btnLeftPressed = false;
			}
			if (GUI.RepeatButton (new Rect (640 - 100, 1136 - 300, 100, 100), "→")) {
				o.transform.RotateAround (Vector3.zero, new Vector3 (0, 1, 0), -speed * Time.deltaTime);
				Controller.Get().startTimer();
				if (!btnRightPressed){
					Controller.count++;
				}
				btnRightPressed = true;
			}
			else if (Event.current.type == EventType.Repaint){
				btnRightPressed = false;
			}
		} else {
			btnClicked = 0;
		}
		base.OnDraw ();
	}
	// Update is called once per frame
	void Update () {

	}
}
