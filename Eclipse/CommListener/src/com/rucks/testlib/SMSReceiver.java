package com.rucks.testlib;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.telephony.SmsMessage;
import android.widget.Toast;

public class SMSReceiver extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
        // Parse the SMS.
        Bundle bundle = intent.getExtras();
        SmsMessage[] msgs = null;
        String str = "";
        if (bundle != null)
        {
            // Retrieve the SMS.
            //Object[] pdus = (Object[]) bundle.get("pdus");
            //msgs = new SmsMessage[pdus.length];
            
            // Display the SMS as Toast.
            Toast.makeText(context, str, Toast.LENGTH_SHORT).show();
        }
    }
}
