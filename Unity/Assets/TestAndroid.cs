using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
//using Commsetup;

public class TestAndroid : MonoBehaviour {
	
	[DllImport("commsetup")]
	private static extern void printLog();
	
	//public string touch;
	
	private readonly AndroidJavaClass _ActivityClass;
	
	//AndroidJavaClass unityPlayer = new AndroidJavaClass("com.rucks.testlib.TestLibMain");
	//AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	//AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	
//	public TestAndroid()
//	{
//		_ActivityClass = new AndroidJavaClass("com.rucks.testlib.TestLibMain");
//	}
	
	
//	AndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some_string"); 
	AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	
	// Use this for initialization
	void Start () {
		AndroidJNIHelper.debug = true; 
//		using (AndroidJavaClass jc = new AndroidJavaClass("com.rucks.testlib.TestLibMain")) { 
//			jc.CallStatic("UnitySendMessage", "Main Camera", "JavaMessage", "whoowhoo"); 
//		}
		
//		using (AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer") )
//		{
//		   using (AndroidJavaObject activity = unityClass.GetStatic<AndroidJavaObject>("currentActivity") )
//		   {    
////		      activity.Call("startSensorService");       
//		   }
//		}
		
		if( System.IO.File.Exists("libcommsetup.so") )
		{
			Debug.Log("FILE EXIST");	
		}
		else
		{
			Debug.Log("NOOOOOOOOO");	
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		//touch = Input.GetTouch(0);
		
		if(	Input.touchCount> 0 && 
			Input.GetTouch(0).position.x > 20 && 
			Input.GetTouch(0).position.x < 320 &&
			Input.GetTouch(0).phase == TouchPhase.Began)
		{
			printLog();
		}
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (20,20,300,200), "I am a button")) {
			print ("You clicked the button!");
			printLog();
		}
		//GUI.TextArea(new Rect (20, 350, 300, 200), "TEXT");
	}
}
