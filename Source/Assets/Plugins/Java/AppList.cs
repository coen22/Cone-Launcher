using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using System.Runtime.InteropServices;

public class AppList : MonoBehaviour {

	public class app {
		string name;
		string id;
		Texture icon;

		public app(string n, string i, Texture ic) {
			name = n;
			id = i;
			icon = ic;
		}
	}

	public static List<app> apps;

	private static void GetAppIcons() {
		IntPtr clas = AndroidJNI.FindClass ("MakeImageCache");
		IntPtr funcID = AndroidJNI.GetMethodID(clas, "getBitmaps", "");
		AndroidJNI.CallStaticVoidMethod (clas, funcID, null);
	}

	public static bool LaunchApp(string bundleID){
		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

		try {
			// if the app is installed, no errors. Else, doesn't get past next line
			AndroidJavaObject launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleID);
			ca.Call("startActivity", launchIntent);
		} catch (Exception e) {
			return false;
			Debug.LogError(e.Message);
		}

		return true;
	}
}