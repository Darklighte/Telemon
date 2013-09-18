using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class CreatureScript : MonoBehaviour 
{
	
	private NoticeReceiver platformBridge;
	private	ulong atk = 0;
	private	ulong def = 0;
	private string creatureName;
	
	private const string ATK = "Attack";
	private const string DEF = "Defense";
	private const string STAGE = "Stage";
	private const string CUR_POINTS = "CurrentPoints";
	private const string CUR_THRESHOLD = "CurrentThreshold";
	
	// variables for use in evolutionary stages
	private const float MIN_THRESH_MULT = .5f;
	private const float MAX_BABY_THRESH_MULT = 1.5f;
	private const float MAX_ADO_THRESH_MULT = 2f;
	private const float MAX_ADULT_THRESH_MULT = 2.5f;
	private const int BABY_STAGE_START = 1;
	private const int ADO_STAGE_START = 5;
	private const int ADULT_STAGE_START = 9;
	
	private ulong[] thresholds = 
	{
		10,
		20,
		50,
		100,
		200,
		640,
		720,
		900,
		1280,
		1440,
		1920,
		2560,
		3200
	};
	
	private ulong curThreshold = 0;
	private ulong curPoints = 0;
	
	private uint stage = 0; // 0 is baby stage!
	
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
			PlayerPrefs.SetString(STAGE, stage.ToString());
			PlayerPrefs.SetString(CUR_POINTS, curPoints.ToString());
			PlayerPrefs.SetString(CUR_THRESHOLD, curThreshold.ToString());
		}
	}
	
	private void LoadStats()
	{
		if(Application.platform == RuntimePlatform.Android)
		{
			atk = ulong.Parse(PlayerPrefs.GetString(ATK, "0"));
			def = ulong.Parse(PlayerPrefs.GetString(DEF, "0"));
			stage = uint.Parse(PlayerPrefs.GetString(STAGE, "0"));
			curPoints = ulong.Parse(PlayerPrefs.GetString(CUR_POINTS, "0"));
			curThreshold = ulong.Parse(PlayerPrefs.GetString(CUR_THRESHOLD, thresholds[stage].ToString()));
		}
		else
		{
			atk = 0;
			def = 0;
			stage = 1;
			curPoints = 0;
			curThreshold = thresholds[stage];
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
	
	private void ModifyThreshold(ulong amountChanged)
	{
		if(stage > BABY_STAGE_START)
		{
			float multiplier = 1f;
			curThreshold += amountChanged;
			if(stage > ADULT_STAGE_START)
			{
				multiplier = 2.5f;
			}
			else if(stage > ADO_STAGE_START)
			{
				multiplier = 2.0f;
			}
			else
			{
				multiplier = 1.5f;
			}
			
			if(curThreshold > (ulong)(thresholds[stage] * multiplier))
				curThreshold = (ulong)(thresholds[stage] * multiplier);
			else if(curThreshold < thresholds[stage] / 2)
				curThreshold = thresholds[stage] / 2;
		}
		SaveStats();
	}
	
	private void GainPoints(ulong pointsGained)
	{
		curPoints += pointsGained;
		if(curPoints > curThreshold)
		{
			AdvanceStage();	
		}
		SaveStats();
	}
	
	private void AdvanceStage()
	{	
		if(stage + 1 < thresholds.Length)
		{
			curPoints = 0;
			curThreshold = thresholds[++stage];
			
			
			// CODE WILL NEED TO BE INSERTED HERE TO PROCESS THE EVOLUTION
		}
		SaveStats();
	}
}