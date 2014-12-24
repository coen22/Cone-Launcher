package com.example.test;

/*
 * Special thanks to FrankkieNL
 * This code is based on his launcher
 * All rights go to him for this script
 */

import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.BitmapRegionDecoder;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

public class MakeImageCache {
	
	public static Context context;
	
	private static Bitmap[] bitmap;
	private static String[] appID;
	private static String[] name;
	
	public static int getTotalApps() {
		return name.length;
	}
	
	public static String getName(int i) {
		return name[i];
	}
	
    public static void getApps() {
    	
        PackageManager packageManager = context.getPackageManager();
        
        // OUYA Games
        Intent mainIntent = new Intent(Intent.ACTION_MAIN, null);
        mainIntent.addCategory(Intent.CATEGORY_LAUNCHER);
        mainIntent.addCategory("tv.ouya.intent.category.GAME");
        List<ResolveInfo> infos = packageManager.queryIntentActivities(mainIntent, 0);
        
        // OUYA Apps
        Intent mainIntent2 = new Intent(Intent.ACTION_MAIN, null);
        mainIntent2.addCategory(Intent.CATEGORY_LAUNCHER);
        mainIntent2.addCategory("tv.ouya.intent.category.APP");
        List<ResolveInfo> infos2 = packageManager.queryIntentActivities(mainIntent2, 0);
        infos.addAll(infos2);
        
        ResolveInfo info;
        Resources resources;
        String packageName;
        
        bitmap = new Bitmap[infos.size()];
        appID = new String[infos.size()];
        name = new String[infos.size()];
        
        for (int i = 0; i < appID.length; i++) {
        		info = infos.get(i);
            packageName = info.activityInfo.applicationInfo.packageName;
            
            // get the icon
            try {
                resources = packageManager.getResourcesForApplication(info.activityInfo.applicationInfo);
                int identifier = resources.getIdentifier(packageName + ":drawable/ouya_icon", "", "");
                Drawable ouyaImage = null;
                
                if (identifier == 0) {
                    ouyaImage = info.loadIcon(packageManager);
                } else {
                    ouyaImage = packageManager.getResourcesForApplication(info.activityInfo.applicationInfo).getDrawable(identifier);
                }
                
                bitmap[i] = ((BitmapDrawable) ouyaImage).getBitmap();
                appID[i] = packageName;
                name[i] = info.activityInfo.applicationInfo.name;
                	System.out.println(name[i]);
            } catch (PackageManager.NameNotFoundException e) {
                e.printStackTrace();
            } catch (Resources.NotFoundException e) {
                e.printStackTrace();
            }
        }
    }
}
