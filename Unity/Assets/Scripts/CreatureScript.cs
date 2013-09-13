using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class CreatureScript : MonoBehaviour {
	
	private NoticeReceiver platformBridge;
	private	ulong atk = 0;
	private	ulong def = 0;
	private string creatureName;
	
	public ulong Attack
	{
		get
		{
			return atk;
		}
		set
		{
			atk = value;
			SaveStats();
			Grow ();
		}
	}
	
	public ulong Defense
	{
		get
		{
			return def;
		}
		set
		{
			def = value;
			SaveStats();
			Grow();
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		//load stats from playerprefs
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	private void SaveStats()
	{
		//saving is platform-specific
		if(Application.platform == RuntimePlatform.Android)
		{
			//Commented out until we're sure the base functionality is working, 
			//because it's much easier to test when your count starts over from 0 every time you push a new build.
			
			/*
			//Get a binary formatter
   			BinaryFormatter binFormatter = new BinaryFormatter();
			
    		//Create an in memory stream
		    MemoryStream memStream = new MemoryStream();
			
		    //PlayerPrefs can store strings, so convert serialized ulongs into strings and save them.
		    binFormatter.Serialize(memStream, atk);
		    PlayerPrefs.SetString("Attack", Convert.ToBase64String(memStream.GetBuffer()));
			binFormatter.Serialize(memStream, def);
			memStream.Flush();
			PlayerPrefs.SetString("Defense", Convert.ToBase64String(memStream.GetBuffer()));
			memStream.Close();
			*/
			
			//save tranforms
		}
	}
	
	private void Grow()
	{
		if(Attack == 0 && Defense == 0)
		{
			transform.localScale = new Vector3(1f,1f,1f);
		}
		transform.localScale += new Vector3(.1f,.1f,.1f);
		
	}
}
