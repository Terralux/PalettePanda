using UnityEngine;
using System.Collections;

public class SlowDown : MonoBehaviour {

	[Range(0f,1f)]
	public float curTime = 1f;

	void OnGUI(){
		curTime = GUI.VerticalSlider (new Rect (10, 10, 30, 100), curTime, 1f, 0f);
		GUI.Box (new Rect (45, 10, 100, 30), curTime.ToString ());
		Time.timeScale = curTime;
	}
}
