using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settings : MonoBehaviour
#if UNITY_ANDROID && !UNITY_EDITOR	
	, OuyaSDK.IRequestGamerInfoListener
#endif
{
	public Texture oButtonPublic;
	public Texture uButtonPublic;
	public Texture yButtonPublic;
	public Texture aButtonPublic;
	public Texture ouyaLogoPublic;

	public Texture wallpaperPublic;

	public GUISkin guiSkinPublic;

	public static Texture oButton;
	public static Texture uButton;
	public static Texture yButton;
	public static Texture aButton;
	public static Texture ouyaLogo;

	public static GUISkin guiSkin;

	public static List<string> settings = new List<string>();

	// Settings (yes, the actual user settings)
	public static Language lang;
	public static string userName = "'_'";
	public static Texture wallpaper;
	public static bool developer;

	IEnumerator Start () {
		oButton = oButtonPublic;
		uButton = uButtonPublic;
		yButton = yButtonPublic;
		aButton = aButtonPublic;
		ouyaLogo = ouyaLogoPublic;
		guiSkin = guiSkinPublic;
		wallpaper = wallpaperPublic;

		SetLanguage("");

		settings.Add (lang.wifi);
		settings.Add(lang.bluetooth);
		settings.Add(lang.screen);
		settings.Add(lang.wallpaper);
		settings.Add(lang.account);
		settings.Add(lang.language);
		settings.Add(lang.developer);
		settings.Add(lang.updates);

		guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);

		#if UNITY_ANDROID && !UNITY_EDITOR
			OuyaSDK.registerRequestGamerInfoListener(this);

			yield return new WaitForSeconds (0.5f);
		OuyaSDK.requestGamerInfo();
		#endif

		yield return null;
	}

	public static void SetLanguage(string language) {
		switch (language.ToLower()) {
			case "dutch":
				Settings.lang = new LanguageDutch();
			break;
			case "french":
				Settings.lang = new LanguageFrench();
			break;
			case "german":
				Settings.lang = new LanguageGerman();
			break;
			case "italian":
				Settings.lang = new LanguageItalian();
			break;
			case "portuguese":
				Settings.lang = new LanguagePortuguese();
			break;
			case "spanish":
				Settings.lang = new LanguageSpanish();
			break;
			default:
				Settings.lang = new Language();
			break;
		}
	}

	// OUYA Stuff
	public void RequestGamerInfoOnSuccess(string uuid, string username) {
		userName = username;
	}

	public void RequestGamerInfoOnSuccess(OuyaSDK.GamerInfo info) {
	}

	public void RequestGamerInfoOnFailure(int errorCode, string errorMessage) {
		userName = System.Reflection.MethodBase.GetCurrentMethod().ToString();
	}
	
	public void RequestGamerInfoOnCancel() {
		userName = System.Reflection.MethodBase.GetCurrentMethod().ToString();
	}

	#if UNITY_ANDROID && !UNITY_EDITOR
	void OnDestroy()
	{
		OuyaSDK.unregisterRequestGamerInfoListener(this);
	}
	#endif
}
