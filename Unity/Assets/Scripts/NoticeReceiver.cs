using UnityEngine;
using System.Collections;

public class NoticeReceiver : MonoBehaviour 
{
	private string testText = "";
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI () 
	{
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), testText);
	}
	
	void ReceiveNotification(string message)
	{
		switch(message)
		{
		case "SMSin":
			testText = "Holy crap, got a text.";
			break;
		case "SMSout":
			testText = "Holy crap, sent a text.";
			break;
		default:
			testText = "Something's wrong: Received message " + message;
			break;
		}	
	}
}
