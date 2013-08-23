package com.rucks.testlib;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.IBinder;
import android.widget.Toast;

/**
 * @name SMSListenerService
 * @author Anna
 * Listens for incoming text messages and notifies game that a new text was received.
 */
public class SMSListenerService extends Service {

	public static final String ACTION="android.provider.Telephony.SMS_RECEIVED";
	private SMSListenerIn incomingSMSListener;
	@Override
	public IBinder onBind(Intent autoGenParam) {
		return null;
	}
/**
 * Public methods
 */
	@Override
	public void onCreate()
	{
		super.onCreate();
		final IntentFilter theFilter = new IntentFilter();
        theFilter.addAction(ACTION);
        incomingSMSListener = new SMSListenerIn() 
        {
            @Override
            public void onReceive(Context context, Intent intent) 
            {
                // Do whatever you need it to do when it receives the broadcast
               notifyReceivedSMS();
            }
        };
        // Registers the receiver so that your service will listen for broadcasts.
        registerReceiver(incomingSMSListener, theFilter);
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		unregisterReceiver(incomingSMSListener);
	}
	
	private void notifyReceivedSMS() {
		//this should eventually call Unity stuff.
		// TODO: Call actual game stuff once this has been verified to work.
        Toast.makeText(this, "SMSCount++!", Toast.LENGTH_LONG)
                .show();
    }
}
