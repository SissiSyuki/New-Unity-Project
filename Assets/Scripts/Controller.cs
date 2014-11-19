using UnityEngine;
using System.Collections;

public class Controller : GUIBase {
	public GUISkin gSkin;
	public static string nickName = "Pikachu";
	public static int age = 0;
	public static int gender = 0;
	public static int count = 0;
	public static int totalFace = 0;
	private int lastFace = -1;
	private int faceGot = 0;
	private static Controller m_Instance = null;
	public static Controller Get()
	{
		if (m_Instance == null)
			m_Instance = (Controller)FindObjectOfType(typeof(Controller));
		return m_Instance;
	}
	public GameObject o;
	private float detectOffset = 0.03f;
	public static int ControlMode = 0;

	public static float timeDur = 0;
	public static bool timer = false;
	public float oriTime = 0;
	private int[] faceOrder = new int[]{0, 1, 2, 3, 4, 5};
	public bool[] face;
	// Use this for initialization
	void Start () {
		Shuffle (faceOrder);
		face = new bool[6] {false,false,false,false,false,false};
		count = 0;
		totalFace = 0;
		oriTime = Time.realtimeSinceStartup;
	}
	public void startTimer(){
		if (timer)
						return;
		timer = true;

		oriTime = Time.realtimeSinceStartup;
	}
	protected override void OnDraw ()
	{
		GUI.skin = gSkin;
		string faceStr = "";
		for (int i = 0; i < 6; i++) {
			if (!face[faceOrder[i]]){
				faceStr += "[" + (faceOrder[i] + 1) + "]";
			}
			else{
				faceStr += "[X] ";
			}
		}
		GUI.Label (new Rect(0,20,500,80), faceStr);
		/*
		if (GUI.Button (new Rect(0,0,200,100), "Touch Mode")) {
			ControlMode = 0;
			timeDur = 0;
			timer = false;
		}
		if (GUI.Button (new Rect(200,0,200,100), "Button Mode")) {
			ControlMode = 1;
			timeDur = 0;
			timer = false;
			resetFace();
		}
*/
		if (timer) {
			/*
			if(GUI.Button (new Rect(400,0,300,100), "Stop Timer")){
				timer = false;
			}
			*/
			timeDur = Time.realtimeSinceStartup - oriTime;

		}

		GUI.Label (new Rect (0, 100, 400, 100), "Duration:" + timeDur.ToString("F2") + "s");
		base.OnDraw ();
	}
	public void resetFace(){
		face [0] = false;
		face [1] = false;
		face [2] = false;
		face [3] = false;
		face [4] = false;
		face [5] = false;

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel(0);		
		}
		if (Vector3.Dot (o.transform.forward, Vector3.forward) > (1 - detectOffset)) { // 6
			if (lastFace != 5){
				lastFace = 5;
				totalFace++;
			}
			if (faceOrder[faceGot] == 5){
				faceGot++;
				face [5] = true;
			}
		} else if (Vector3.Dot (o.transform.forward, Vector3.forward) < -(1 - detectOffset)) { // 1
			if (lastFace != 0){
				lastFace = 0;
				totalFace++;
			}
			if (faceOrder[faceGot] == 0){
				faceGot++;
				face [0] = true;
			}
		} else if (Vector3.Dot (o.transform.up, Vector3.forward) > (1 - detectOffset)) { // 2
			if (lastFace != 1){
				lastFace = 1;
				totalFace++;
			}
			if (faceOrder[faceGot] == 1){
				faceGot++;
				face [1] = true;
			}
		} else if (Vector3.Dot (o.transform.up, Vector3.forward) < -(1 - detectOffset)) { // 5
			if (lastFace != 4){
				lastFace = 4;
				totalFace++;
			}
			if (faceOrder[faceGot] == 4){
				faceGot++;
				face [4] = true;
			}
		} else if (Vector3.Dot (o.transform.right, Vector3.forward) > (1 - detectOffset)) { // 3
			if (lastFace != 2){
				lastFace = 2;
				totalFace++;
			}
			if (faceOrder[faceGot] == 2){
				faceGot++;
				face [2] = true;
			}
		} else if (Vector3.Dot (o.transform.right, Vector3.forward) < -(1 - detectOffset)) { // 4
			if (lastFace != 3){
				lastFace = 3;
				totalFace++;
			}
			if (faceOrder[faceGot] == 3){
				faceGot++;
				face [3] = true;
			}
		}
		if (face [0] && face [1] && face [2] && face [3] && face [4] && face [5]) {
			Application.LoadLevel(3);		
		}
	}
	public int[] Shuffle(int[] array)
	{
		for (int i = array.Length; i > 1; i--)
		{
			// Pick random element to swap.
			int j = Random.Range(0, i -1);// random.Next(i); // 0 <= j <= i-1
			// Swap.
			int tmp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = tmp;
		}
		return array;
	}
}
