using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	private CreatureScript creature;
	private NoticeReceiver platformBridge;
	public bool serviceToggle;
	private bool displayPrivacyPolicy;
	private const string SERVICE_TOGGLE = "serviceToggle";
	public GUISkin customSkin;
		
	// Use this for initialization
	void Start () 
	{
		//Get a reference to the creature and hold it so we only have to get it once
		creature =  (CreatureScript)GameObject.Find("Creature").GetComponent("CreatureScript");
		platformBridge = (NoticeReceiver)GameObject.Find("PlatformBridge").GetComponent("NoticeReceiver");
		
		// Assume the service is on when we start if there is no saved value.
		serviceToggle = (1 == PlayerPrefs.GetInt(SERVICE_TOGGLE, 1));
		
		// Don't display the privacy policy at start.
		displayPrivacyPolicy = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		GUI.skin = customSkin;
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
				if(Application.platform == RuntimePlatform.Android)
				{
					platformBridge.ToggleListeners(serviceToggle);
					SavePrefs();
				}
			}
		}
		else
		{
			// Service Off Button
			if(GUI.Button(new Rect(leftBtn + widthBtn, topBtn, widthBtn, heightBtn), "Service is Off"))
			{
				serviceToggle = !serviceToggle;
				if(Application.platform == RuntimePlatform.Android)
				{
					platformBridge.ToggleListeners(serviceToggle);
					SavePrefs();
				}
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
				"Privacy Policy:\n\n" +
				//"We're not dicks and not tracking your data personally.\n" +
				//"You should probably be more worried about Google doing that.");
				"By continuing to use this app, you agree to this privacy policy.\n" + 
				"This app counts sent and received SMS messages (text messages.)\n" + 
				"We do not read the contents of emails, texts, contact lists,\nor any other private data on your phone.\n" +
				"We do not in any way personally identify you or your device.\n"+
				"All data gathered by this app is stored locally on your phone only. We do not track this data.\n"+
				"This policy is subject to change as new features are added.\n" +
				"Last updated: September 13, 2013", "LegaleseBox");
		}
		
		GUI.Box(new Rect(left, top, width, height), "Attack: " + creature.Attack + "\nDefense: " + creature.Defense);
	}
	
	private void SavePrefs()
	{
		//save as a 1 if true, 0 if false
		PlayerPrefs.SetInt(SERVICE_TOGGLE, serviceToggle ? 1 : 0);
	}
}