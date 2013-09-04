using UnityEngine;
using System.Collections;

public class CreatureScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
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
		
		long atk = 0;
		long def = 0;
		GUI.Box(new Rect(left,top,widthDev2, top/3), "\n\n\nStats\n\nAttack: " + atk + "\nDefense: " + def);
	}
}
