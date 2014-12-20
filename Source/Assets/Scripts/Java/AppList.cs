
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;

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

	public static void GetAppIcons() {
		// System.IntPtr clas = AndroidJNI.FindCLass("MakeImageCache");
	}

	public static void LaunchApp(string bundleID){
		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

		//if the app is installed, no errors. Else, doesn't get past next line
		AndroidJavaObject launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage",bundleID);
		
		ca.Call("startActivity",launchIntent);
	}
}