package com.rucks.testlib;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;

import com.unity3d.player.UnityPlayerActivity;

public class TestLibMain extends UnityPlayerActivity 
{	
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_test_lib_main);
     
        //start listener code here
        Intent SMSInServiceIntent = new Intent();
        SMSInServiceIntent.setAction(SMSListenerService.ACTION);
        startService(new Intent(this, SMSListenerService.class));
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) 
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.test_lib_main, menu);
        return true;
    }
}
