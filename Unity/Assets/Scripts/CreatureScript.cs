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
	
	private const string ATK = "Attack";
	private const string DEF = "Defense";
	
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
		LoadStats();
		
		//grow once so that we can set the scale
		Grow ();
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
			PlayerPrefs.SetString(ATK, atk.ToString());
			PlayerPrefs.SetString(DEF, def.ToString());
		}
	}
	
	private void LoadStats()
	{
		if(Application.platform == RuntimePlatform.Android)
		{
			atk = ulong.Parse(PlayerPrefs.GetString(ATK, "0"));
			def = ulong.Parse(PlayerPrefs.GetString(DEF, "0"));
		}
		else{
			atk = 0;
			def = 0;
		}
	}
	
	private void Grow()
	{
		/*if(Attack == 0 && Defense == 0)
		{
			transform.localScale = new Vector3(1f,1f,1f);
		}
		transform.localScale += new Vector3(.1f,.1f,.1f);*/
		
		float scale = 1 + ((atk + def) * 0.1f);
		transform.localScale = new Vector3(scale, scale, scale);
	}
}
