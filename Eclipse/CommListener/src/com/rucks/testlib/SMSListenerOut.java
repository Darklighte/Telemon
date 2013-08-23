package com.rucks.testlib;

import android.database.ContentObserver;
import android.os.Handler;

public class SMSListenerOut extends ContentObserver 
{

	public SMSListenerOut(Handler handler) 
	{
		super(handler);
	}

	
	
	@Override
    public void onChange(boolean selfChange) 
	{
        super.onChange(selfChange);
        //TODO: Tell game an SMS was received.
    }
}
