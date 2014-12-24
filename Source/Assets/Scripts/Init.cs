using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	void Start () {
		Application.targetFrameRate = 60;
		// AppList.GetApps ();
		Application.LoadLevel("Launcher");
	}
}
