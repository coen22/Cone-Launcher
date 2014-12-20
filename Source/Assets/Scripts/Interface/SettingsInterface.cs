using UnityEngine;
using System.Collections;

public class SettingsInterface : Interface {
	private int selectedMenuItem = 0;

	public static bool axisDown = false;
	private bool mainCatagories = true;
	private SettingsPanel settingsPanel = null;

	public static string selectedCatagory;

	private float introAnim = 1;

	IEnumerator Start() {
		introAnim = 0.5f;

		while (introAnim != 0) {
			if (introAnim > 0)
				introAnim -= 1.5f * Time.deltaTime;
			
			if (introAnim < 0)
				introAnim = 0;

			yield return null;
		}
	}

	void Update() {
		if (mainCatagories){
			if (!axisDown) {
				if (InputManager.GetAxis ("Vertical", 0) > 0.5f) {
					if (selectedMenuItem > 0) {
						selectedMenuItem --;
						StartCoroutine(DelayButtonPress());
					}
				} else if (InputManager.GetAxis ("Vertical", 0) < -0.5f) {
					if (selectedMenuItem < Settings.settings.Count - 1) {
						selectedMenuItem ++;
						StartCoroutine(DelayButtonPress());
					}
				}
			}

			if (InputManager.GetButtonDown("a", 0)) {
				if (introAnim == 0)
					StartCoroutine( BackToMenu());
			}
		} else {
			if (InputManager.GetButtonDown("a", 0)) {
				mainCatagories = true;
				settingsPanel = null;
			} else {
				settingsPanel.Do();
			}
		}

		if (InputManager.GetButtonDown("o", 0)) {
			mainCatagories = false;
			settingsPanel = GetSettingsCatagory(selectedCatagory);
		}
	}

	public SettingsPanel GetSettingsCatagory(string catagory) {
		switch(catagory) {
			case "wifi":
				return new WifiSettingsPanel();
			case "language":
				return new LanguageSettingsPanel();
			case "developer":
				return new DeveloperSettingsPanel();
			default:
				return new SettingsPanel();
		}
	}

	public override void OnGUI() {
		base.OnGUI ();

		Settings.guiSkin.box.alignment = TextAnchor.MiddleLeft;

		if (mainCatagories) {
			ShowCatagories();
			Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.75f);
		} else {
			ShowCatagoriesUnselected();
			Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.3f);
		}

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.045f);
		
		GUI.Box (new Rect (Screen.width * (0.06f - introAnim), Screen.height * 0.15f, Screen.width * 0.4f, Screen.width * 0.05f),
		         Settings.lang.settings.ToUpper());
		
		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.02f);
	}

	void ShowCatagories() {
		// Show Tooltips
		Tooltip(Settings.lang.select, Settings.oButton, 0.25f);
		Tooltip(Settings.lang.back, Settings.aButton, 0.4f);
		Tooltip(Settings.lang.androidSettings, Settings.yButton, 0.55f);

		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.025f);

		// Show All Catagories
		foreach(string s in Settings.settings) {
			if (s == Settings.settings[selectedMenuItem]) {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1);
				selectedCatagory = s;
			} else {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.65f);
			}
			
			GUI.Box (new Rect (Screen.width * (0.07f - introAnim), Screen.height * 0.25f + Screen.height * 0.075f * Settings.settings.IndexOf(s), Screen.width * 0.25f, Screen.width * 0.05f),
				s.ToUpper());
		}
	}

	void ShowCatagoriesUnselected() {
		Settings.guiSkin.box.fontSize = Mathf.RoundToInt(Screen.width*0.025f);

		// Show All Catagories
		foreach(string s in Settings.settings) {
			if (s == Settings.settings[selectedMenuItem]) {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.6f);
			} else {
				Settings.guiSkin.box.normal.textColor = new Color (1, 1, 1, 0.35f);
			}
			
			GUI.Box (new Rect (Screen.width * (0.07f - introAnim), Screen.height * 0.25f + Screen.height * 0.075f * Settings.settings.IndexOf(s), Screen.width * 0.25f, Screen.width * 0.05f),
			         s.ToUpper());
		}

		// Draw Settings
		settingsPanel.Draw ();
	}

	public IEnumerator DelayButtonPress() {
		axisDown = true;
		
		for (float i = 0; i <= 0.1f; i += Time.deltaTime) {
			
			if (!axisDown)
				yield break;
			
			yield return null;
		}

		axisDown = false;
	}

	IEnumerator BackToMenu() {
		while (introAnim < 0.5f) {
			if (introAnim < 0.5f)
				introAnim += 1.5f * Time.deltaTime;

			yield return null;
		}

		Application.LoadLevel("Launcher");
	}
}
