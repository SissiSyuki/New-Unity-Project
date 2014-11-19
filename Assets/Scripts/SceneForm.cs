using UnityEngine;
using System.Collections;

public class SceneForm : GUIBase {
	string age = "";
	public GUISkin gSkin;
	// Use this for initialization
	void Start () {
	
	}
	protected override void OnDraw ()
	{
		GUI.skin = gSkin;
		GUI.Label(new Rect(0, 300, 300, 80), "Nickname:");
		GUI.Label(new Rect(0, 400, 300, 80), "Gender:");
		GUI.Label(new Rect(0, 500, 300, 80), "Age:");
		GUI.Label(new Rect(0, 600, 300, 80), "Control Type:");
		Controller.nickName = GUI.TextField(new Rect(300, 300, 300, 80), Controller.nickName, 25);
		Controller.gender = GUI.SelectionGrid(new Rect(300, 400,450,60), Controller.gender,new string[] {"Male", "Female"}, 2, "toggle");
		age = GUI.TextField(new Rect(300, 500, 400, 80), Controller.age.ToString());
		Controller.ControlMode = GUI.SelectionGrid(new Rect(300, 600,400,280), Controller.ControlMode,new string[] {"Touch", "Button", "Accelerometer", "Gyroscope"}, 1, "toggle");
		int temp = 0;
		if (int.TryParse (age, out temp)) {
			Controller.age = temp;
		} else if (age == "") {
			Controller.age = 0;		
		}
		if (GUI.Button (new Rect (200, 900, 200, 100), "Start")) {
			if (Controller.ControlMode == 0 || Controller.ControlMode == 1){
				Application.LoadLevel(1);
			}
			else if (Controller.ControlMode == 2){
				Application.LoadLevel(2);
			}
			else {
				Application.LoadLevel(4);
			}
		}
		base.OnDraw ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
