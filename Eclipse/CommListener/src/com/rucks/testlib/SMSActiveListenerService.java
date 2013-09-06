package com.rucks.testlib;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;

public class SMSActiveListenerService extends Service 
{

	public static final String ACTION="android.provider.Telephony.SMS_RECEIVED";
	@Override
	public IBinder onBind(Intent intent) 
	{
		return null;
	}
	
	@Override
	public void onCreate()
	{
		super.onCreate();
		
		
	}

}
