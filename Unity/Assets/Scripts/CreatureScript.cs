using UnityEngine;
using System.Collections;

public class CreatureScript : MonoBehaviour {
	
	private NoticeReceiver platformBridge;
	private	ulong atk = 0;
	private	ulong def = 0;
	
	// Use this for initialization
	void Start () 
	{
		//get reference to PlatformBridge once, and hold it
		//consider switching this to a 
		platformBridge = (NoticeReceiver)GameObject.Find("PlatformBridge").GetComponent("NoticeReceiver");
	}
	
	// Update is called once per frame
	void Update () 
	{
		atk = platformBridge.SmsSend;
		def = platformBridge.SmsGet;
	}
	
	void OnGUI()
	{
		int widthDev2 = Screen.width/2;
		int heightDev2 = Screen.height/2;
		int left = Screen.width - (3*widthDev2/2);
		int top = 3*heightDev2/2;
		
		GUI.Box(new Rect(left,top,widthDev2, top/3), "\n\n\nStats\n\nAttack: " + atk + "\nDefense: " + def);
	}
}
