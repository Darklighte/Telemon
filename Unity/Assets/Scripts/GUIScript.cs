using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	private CreatureScript creature;
	private NoticeReceiver platformBridge;
	public bool serviceToggle;
	private bool displayPrivacyPolicy;
		
	// Use this for initialization
	void Start () 
	{
		//Get a reference to the creature and hold it so we only have to get it once
		creature =  (CreatureScript)GameObject.Find("Creature").GetComponent("CreatureScript");
		platformBridge = (NoticeReceiver)GameObject.Find("PlatformBridge").GetComponent("NoticeReceiver");
		
		// Assume the service is off when we start.
		// This should be initialized to the previously-set value.
		serviceToggle = false;
		
		// Don't display the privacy policy at start.
		displayPrivacyPolicy = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		int width = Screen.width;
		int height = Screen.height / 8;
		int widthDiv2 = Screen.width / 2;
		int left = 0;
		int top = 6 * Screen.height / 8;
		
		//  Button size parameters
		int topBtn = 7 * Screen.height / 8;
		int leftBtn = 0;
		int widthBtn = Screen.width / 3;
		int heightBtn = Screen.height / 8;
		
		// Privacy Policy window size parameters
		int topPriv = 0;
		int leftPriv = 0;
		int widthPriv = Screen.width;
		int heightPriv = 6 * Screen.height / 8;
		
		if(Application.platform == RuntimePlatform.WindowsEditor)
		{
			//attack box
			if (GUI.Button(new Rect(10,50,widthDiv2, 30), "Simulate incoming text"))
			{
				if(serviceToggle)
					creature.Defense++;
			}
			
			//defense box
			if(GUI.Button(new Rect(10,85,widthDiv2, 30), "Simulate outcoming text"))
			{
				if(serviceToggle)
					creature.Attack++;
			}
		}
		
		// Reset Button
		if(GUI.Button(new Rect(leftBtn, topBtn, widthBtn, heightBtn), "Reset"))
		{
			// Reset the creature's attack and defense values.
			creature.Attack = 0;
			creature.Defense = 0;
		}
		
		// Buttons for service toggle.
		if(serviceToggle)
		{
			// Service On Button
			if(GUI.Button(new Rect(leftBtn + widthBtn, topBtn, widthBtn, heightBtn), "Service is On"))
			{
				serviceToggle = !serviceToggle;
				platformBridge.ToggleListeners(serviceToggle);
			}
		}
		else
		{
			// Service Off Button
			if(GUI.Button(new Rect(leftBtn + widthBtn, topBtn, widthBtn, heightBtn), "Service is Off"))
			{
				serviceToggle = !serviceToggle;
				platformBridge.ToggleListeners(serviceToggle);
			}
		}
		
		// Privacy Policy
		if(GUI.Button(new Rect(leftBtn + widthBtn*2, topBtn, widthBtn, heightBtn), "Privacy"))
		{
			displayPrivacyPolicy = !displayPrivacyPolicy;
		}
		
		// Privacy Policy display box
		if(displayPrivacyPolicy)
		{
			GUI.Box(new Rect(leftPriv, topPriv, widthPriv, heightPriv), 
				"Privacy Policy:\n" +
				"We're not dicks and not tracking your data personally.\n" +
				"You should probably be more worried about Google doing that.");
		}
		
		GUI.Box(new Rect(left, top, width, height), "\nStats\n\nAttack: " + creature.Attack + "\nDefense: " + creature.Defense);
	}
}