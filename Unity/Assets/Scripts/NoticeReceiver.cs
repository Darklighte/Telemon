using UnityEngine;
using System.Collections;

public class NoticeReceiver : MonoBehaviour 
{
	private ulong smsGet;
	private ulong smsSend;
	
	public ulong SmsGet
	{
		get
		{
			return smsGet;
		}
	}
	
	public ulong SmsSend
	{
		get
		{
			return smsSend;
		}	
	}
	
	// Use this for initialization
	void Start () 
	{
		smsGet = 0;
		smsSend = 0;
		//pull save data from device and set smsGet/smsSet.
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
		
		smsGet += tempGet;
		smsSend += tempSend;
		
		//saving is platform-specific
		if(Application.platform == RuntimePlatform.Android)
		{
			//update and save stats.
			
		}
	}
}
