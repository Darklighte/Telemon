using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	private CreatureScript creature;
	
	// Use this for initialization
	void Start () 
	{
		//Get a reference to the creature and hold it so we only have to get it once
		creature =  (CreatureScript)GameObject.Find("Creature").GetComponent("CreatureScript");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		int widthDev2 = Screen.width/2;
		int heightDev2 = Screen.height/2;
		int left = Screen.width - (3*widthDev2/2);
		int top = 3*heightDev2/2;
		
		if(Application.platform == RuntimePlatform.WindowsEditor)
		{
			//attack box
			if (GUI.Button(new Rect(10,50,widthDev2, 30), "Simulate incoming text"))
			{
				creature.Defense++;
			}
			
			//defense box
			if(GUI.Button(new Rect(10,85,widthDev2, 30), "Simulate outcoming text"))
			{
				creature.Attack++;
			}
		}
		
		
		GUI.Box(new Rect(left,top,widthDev2, top/3), "\n\n\nStats\n\nAttack: " + creature.Attack + "\nDefense: " + creature.Defense);
	}
}
