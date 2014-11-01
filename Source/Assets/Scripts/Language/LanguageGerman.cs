using UnityEngine;
using System.Collections;

public class LanguageGerman : Language {

	// Translation info
	// Change the <return info> to what it should be in your language
	// Do this for lines like:
	// return "<return info>";
	
	// Example (French)
	
	// return "hi, ";
	// return "salut, ";

	public override string[] languages
	{
		get {
			return new string[] {"english", "french", "dutch", "german", "portuguese", "spanish", "italian"};
		}
	}

	public override string hello
	{
		get {
			return "hi, ";
		}
	}

	public override string settings
	{
		get {
			return "settings";
		}
	}

	public override string wifi
	{
		get {
			return "wifi";
		}
	}

	public override string bluetooth
	{
		get {
			return "bluetooth";
		}
	}

	public override string screen
	{
		get {
			return "screen";
		}
	}

	public override string wallpaper
	{
		get {
			return "wallpaper";
		}
	}

	public override string account
	{
		get {
			return "account";
		}
	}

	public override string language
	{
		get {
			return "language";
		}
	}

	public override string developer
	{
		get {
			return "developer";
		}
	}

	public override string updates
	{
		get {
			return "updates";
		}
	}

	public override string connect
	{
		get {
			return "connect";
		}
	}
	
	public override string rescan
	{
		get {
			return "rescan";
		}
	}

	public override string back
	{
		get {
			return "back";
		}
	}

	public override string options
	{
		get {
			return "options";
		}
	}

	public override string open
	{
		get {
			return "open";
		}
	}

	public override string rate
	{
		get {
			return "rate";
		}
	}

	public override string unstall
	{
		get {
			return "unstall";
		}
	}

	public override string more
	{
		get {
			return "more";
		}
	}

	public override string select
	{
		get {
			return "select";
		}
	}

	public override string androidSettings
	{
		get {
			return "android settings";
		}
	}
}