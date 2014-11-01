using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LanguageSettingsPanel : SettingsPanel {
	
	public static int selectedLanguage;

	public override string Title
	{
		get {
			return Settings.lang.language;
		}
	}

	public override void Do () {
		base.Do ();

		if (timer <= 0) {
			if (InputManager.GetAxis ("Vertical", 0) > 0.5f) {
				if (selectedLanguage > 0) {
					selectedLanguage --;
					timer = 0.1f;
				}
			} else if (InputManager.GetAxis ("Vertical", 0) < -0.5f) {
				if (selectedLanguage < Settings.lang.languages.Length - 1) {
					selectedLanguage ++;
					timer = 0.1f;
				}
			}
		}

		if (InputManager.GetButtonDown("o", 0)) {
			Settings.lang = new Language();
			Settings.SetLanguage(Settings.lang.languages[selectedLanguage]);
		}
	}

	// Update is called once per frame
	public override void Draw () {
		base.Draw ();

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.025f);

		for(int i = 0; i < Settings.lang.languages.Length; i++) {

			if (Settings.lang.languages[i] == Settings.lang.languages[selectedLanguage]) {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1);
			} else {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.65f);
			}
			
			GUI.Box (new Rect (Screen.width * 0.41f,
								Screen.height * 0.25f + Screen.height * 0.075f * i,
								Screen.width * 0.25f,
								Screen.width * 0.05f),
			         			Settings.lang.languages[i].ToUpper());
		}

		// Show Tooltips
		Interface.Tooltip(Settings.lang.select, Settings.oButton, 0.35f);
		Interface.Tooltip(Settings.lang.back, Settings.aButton, 0.55f);
	}
}
