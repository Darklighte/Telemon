package com.rucks.testlib;

import android.app.Service;
import android.database.ContentObserver;
import android.os.Handler;
import android.widget.Toast;

public class SMSListenerOut extends ContentObserver 
{
	Handler handler;
	Service listeningService;
	public SMSListenerOut(Handler handler, Service parentService) 
	{
		super(handler);
		listeningService = parentService;
	}
	
	@Override
    public void onChange(boolean selfChange) 
	{
        super.onChange(selfChange);
        //TODO: Tell game an SMS was received.

        Toast.makeText(listeningService.getApplicationContext(), "Detected sent SMS!", Toast.LENGTH_SHORT).show();
    }
}
