using UnityEngine;
using System.Collections;

public class SceneReport : GUIBase {
	public GUISkin gSkin;
	private string report = "";
	private string[] strGender = new string[] {"Male", "Female"};
	private string[] strMode = new string[] {"Touch", "Button", "Accelerometer"};
	// Use this for initialization
	void Start () {
		report += "Nickname: " + Controller.nickName + "\n";
		report += "Gender: " + strGender[Controller.gender] + "\n";
		report += "Age: " + Controller.age + "\n";
		report += "Total Time: " + Controller.timeDur.ToString("F2") + "s\n";
		report += "Mode: " + strMode[Controller.ControlMode] + "s\n";
		report += "Count: " + Controller.count + "\n";
		report += "Total Faces Seen: " + Controller.totalFace + "\n";
	}
	protected override void OnDraw ()
	{
		GUI.Label (new Rect(50, 300 ,600 , 600), report, gSkin.label);
		if (GUI.Button (new Rect(200, 900, 250, 100), "Restart", gSkin.button)) {
			Application.LoadLevel(0);
		}
		base.OnDraw ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel(0);		
		}
	}
}
