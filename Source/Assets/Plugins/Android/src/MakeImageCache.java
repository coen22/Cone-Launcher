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
	
    public List<Bitmap> getBitmaps() {
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
        
        Resources resources;
        List<Bitmap> out = new List<Bitmap>();
        String packageName;
        for (ResolveInfo info : infos) {
            packageName = info.activityInfo.applicationInfo.packageName;
            
            // Check if image thumbnail for this package already exists
            File thumbFile = new File("/sdcard/BAXY/thumbnails/" + packageName + ".png");
            if (!thumbFile.exists()) {
                //make
                try {
                    resources = packageManager.getResourcesForApplication(info.activityInfo.applicationInfo);
                    int identifier = resources.getIdentifier(packageName + ":drawable/ouya_icon", "", "");
                    Drawable ouyaImage = null;
                    
                    if (identifier == 0) {
                        ouyaImage = info.loadIcon(packageManager);
                    } else {
                        ouyaImage = packageManager.getResourcesForApplication(info.activityInfo.applicationInfo).getDrawable(identifier);
                    }
                    
                    out.add(((BitmapDrawable) ouyaImage).getBitmap());
                } catch (PackageManager.NameNotFoundException e) {
                    e.printStackTrace();
                } catch (IOException e) {
                    e.printStackTrace();
                } catch (Resources.NotFoundException e) {
                    e.printStackTrace();
                }
            }
        }
        
        return out;
    }
}
