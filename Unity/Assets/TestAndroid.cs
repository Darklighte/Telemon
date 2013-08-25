using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class TestAndroid : MonoBehaviour {
	
	[DllImport("commsetup")]
	private static extern int fibonacci();
	
	//AndroidJavaClass unityPlayer = new AndroidJavaClass("com.rucks.testlib.TestLibMain");
	//AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	//AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

	// Use this for initialization
	void Start () {
//		AndroidJNIHelper.debug = true; 
//		using (AndroidJavaClass jc = new AndroidJavaClass("com.rucks.testlib.TestLibMain")) { 
//			jc.CallStatic("UnitySendMessage", "Main Camera", "JavaMessage", "whoowhoo"); 
//		} 
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,150,100), "I am a button")) {
			print ("You clicked the button!");
			fibonacci();
		}
	}
}
