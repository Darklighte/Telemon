package com.nomoargames.telemon;

import android.app.Service;
import android.content.ContentResolver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Handler;
import android.os.IBinder;

/**
 * @name SMSListenerService
 * @author Anna
 * Listens for incoming text messages and notifies game that a new text was received.
 */
public class SMSListenerService extends Service 
{
	public static final String ACTION="android.provider.Telephony.SMS_RECEIVED";
	private SMSListenerIn incomingSMSListener;
	private ContentResolver contentResolver;
	private SMSListenerOut outListener;

	@Override
	public IBinder onBind(Intent autoGenParam) 
	{
		return null;
	}
/**
 * Public methods
 */	
	@Override
	public void onCreate()
	{
		super.onCreate();
		
		//broadcast listener setup
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
        // Registers the receiver so that the service will listen for broadcasts.
        registerReceiver(incomingSMSListener, theFilter);
        
        //register outgoing sms contentobserver
        outListener = new SMSListenerOut(new Handler(), this);
        contentResolver = getContentResolver();
        contentResolver.registerContentObserver(Uri.parse("content://sms/"),true, outListener);
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId) 
	{
	    // We want this service to continue running until it is explicitly
	    // stopped, so return sticky.
		// Ostensibly this makes the service get restarted if it is killed
	    return START_STICKY;
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		unregisterReceiver(incomingSMSListener);
		contentResolver.unregisterContentObserver(outListener);
	}
	
	private void notifyReceivedSMS() 
	{        
        //update count of SMS received.
    	SharedPreferences countDiffs = getSharedPreferences(TelemonMain.COUNT_DIFFS, 0);   	
    	long smsReceived = countDiffs.getLong(TelemonMain.SMS_GOTTEN, 0);
    	SharedPreferences.Editor editor = countDiffs.edit();
    	editor.putLong(TelemonMain.SMS_GOTTEN, ++smsReceived);
    	editor.commit();
    }
}

