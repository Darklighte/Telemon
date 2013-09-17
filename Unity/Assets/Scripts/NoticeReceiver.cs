using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class NoticeReceiver : MonoBehaviour 
{	
	private CreatureScript creature;
	
	[DllImport("javabridge")]
	private static extern void ToggleListenersNative(bool toggleValue);
	
	// Use this for initialization
	void Start () 
	{
		//reference to CreatureScript once, and hold it so we only have to get it once
		creature = (CreatureScript)GameObject.Find("Creature").GetComponent("CreatureScript");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//number = GetNumber();
	}
	
	void OnGUI () 
	{
	}
	
	void ReceiveNotification(string message)  //message is the format receivedCount|sentCount
	{
		//parse out, update, and save stats.
		
		//parse message
		string[]SMSStrings = message.Split('|');
		ulong tempGet = 0;
		ulong tempSend = 0;
		
		if(!ulong.TryParse(SMSStrings[0], out tempGet))
		{
			//error, parse failed
		}
		
		if(!ulong.TryParse(SMSStrings[1], out tempSend))
		{
			//error, parse failed
		}
		
		//Did it this way because attacks being outgoing and defense against incoming things made sense.
		creature.Attack += tempSend;
		creature.Defense += tempGet;
	}
	
	public void ToggleListeners(bool toggleValue)
	{
		ToggleListenersNative(toggleValue);
	}
}
