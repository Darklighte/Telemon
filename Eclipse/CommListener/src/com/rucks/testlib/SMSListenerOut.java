package com.rucks.testlib;

import android.app.Service;
import android.content.ContentResolver;
import android.content.SharedPreferences;
import android.database.ContentObserver;
import android.database.Cursor;
import android.net.Uri;
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

        Uri uriSMSURI = Uri.parse("content://sms/");
        ContentResolver resolver = listeningService.getContentResolver();
        
        Cursor cur = listeningService.getContentResolver().query(uriSMSURI, null, null, null, null);
        cur.moveToNext();
        String protocol = cur.getString(cur.getColumnIndex("protocol"));
        if(protocol == null)
        {
        	SharedPreferences countDiffs = listeningService.getSharedPreferences(TestLibMain.COUNT_DIFFS, 0);   	
        	long smsReceived = countDiffs.getLong(TestLibMain.SMS_SENT, 0);
        	SharedPreferences.Editor editor = countDiffs.edit();
        	editor.putLong(TestLibMain.SMS_SENT, ++smsReceived);
        	editor.commit();
        	Toast.makeText(listeningService.getApplicationContext(), cur.toString(), Toast.LENGTH_SHORT).show();
        }
    }
}
