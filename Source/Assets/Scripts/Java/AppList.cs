using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using System.Runtime.InteropServices;

public class AppList : MonoBehaviour {

	public class App {
		public string name;
		public string id;
		public Texture icon;

		public App(string n, string i, Texture ic) {
			name = n;
			id = i;
			icon = ic;
		}
	}

	public static List<App> apps = new List<App>();

	public static void GetApps() {
		IntPtr clas = AndroidJNI.FindClass ("MakeImageCache");
		clas = AndroidJNI.NewGlobalRef (clas);

		IntPtr funcID = AndroidJNI.GetMethodID(clas, "getApps", "()V");
		AndroidJNI.CallStaticVoidMethod (clas, funcID, null);

		IntPtr nameID = AndroidJNI.GetMethodID(clas, "getName", "(I)Ljava/lang/String;");
		nameID = AndroidJNI.NewGlobalRef (nameID);

		IntPtr length = AndroidJNI.GetMethodID(clas, "getTotalApps", "()I");
		length = AndroidJNI.NewGlobalRef (length);
		int j = AndroidJNI.CallIntMethod(clas, length, null);
		Debug.Log("hehehe " + j);

		jvalue[] val = new jvalue[1];
		val[0] = new jvalue();

		Debug.Log("loading apps ...");

		for (int i = 0; i < j; i++) {
			val[0].i = i;
			Debug.Log("hehehe");
			Debug.Log(AndroidJNI.CallStaticStringMethod(clas, nameID, val));
		}

		Debug.Log("loaded apps!");
	}

	public static bool LaunchApp(string bundleID) {
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