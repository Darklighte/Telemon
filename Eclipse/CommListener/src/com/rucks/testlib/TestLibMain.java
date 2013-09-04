package com.rucks.testlib;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.Menu;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

public class TestLibMain extends UnityPlayerActivity 
{	
	public static final String SMS_RECEIVED ="android.provider.Telephony.SMS_RECEIVED";
	
	private static final String COUNT_DIFFS = "CountDiffsFile";
	private static final String SMS_SENT = "SMSSent";
	private static final String SMS_GOTTEN = "SMSReceived";
	
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
        super.onCreate(savedInstanceState);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) 
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.test_lib_main, menu);
        return true;
    }
    
    @Override
    protected void onResume()
    {
    	super.onResume();
    	
    	String message = "";
    	
    	//pull out stored values
    	SharedPreferences countDiffs = getSharedPreferences(COUNT_DIFFS, 0);   	
    	long smsReceived = countDiffs.getLong(SMS_GOTTEN, 0);
    	long smsSent = countDiffs.getLong(SMS_SENT, 0);
    	
    	//build and send message
    	message = Long.toString(smsReceived) + "|" + Long.toString(smsSent);
    	UnityPlayer.UnitySendMessage("PlatformBridge", "ReceiveNotification", message);
    	
    	//reset stored values
    	SharedPreferences.Editor editor = countDiffs.edit();
    	editor.putLong(SMS_GOTTEN, 0);
    	editor.putLong(SMS_SENT, 0);
    	editor.commit();
    	

    	
       	//start BroadcastReceiver that runs when app is running. 
    	//Should only need to track sms receiving during running application, because 
    	//if the person is playing our game they aren't sending texts, right?
    	BroadcastReceiver receiverSMS = new BroadcastReceiver()
        {
    		@Override
            public void onReceive(Context context, Intent intent)
            {
                 if (intent.getAction().equals(SMS_RECEIVED))
                 {
                	 String message = "1|0";
                	 UnityPlayer.UnitySendMessage("PlatformBridge", "ReceiveNotification", message);
                 }
            }
        };//Java is magic.
    	
    	IntentFilter filter = new IntentFilter(SMS_RECEIVED);
        registerReceiver(receiverSMS, filter);
    }
    
    @Override
    protected void onPause()
    {
    	super.onPause();
    	
    	//kill listeners that run when app is running, 
    	//start listeners that run when app is closed.
        //Intent SMSInServiceIntent = new Intent(this, SMSListenerService.class);
        //SMSInServiceIntent.setAction(SMSListenerService.ACTION);
        //startService(SMSInServiceIntent);
    } 
}
