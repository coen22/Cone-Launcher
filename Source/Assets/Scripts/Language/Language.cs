using UnityEngine;
using System.Collections;

public class Language {

	public virtual string[] languages
	{
		get {
			return new string[] {"english", "french", "dutch", "german", "portuguese", "spanish", "italian"};
		}
	}

	public virtual string hello
	{
		get {
			return "hi, ";
		}
	}

	public virtual string settings
	{
		get {
			return "settings";
		}
	}

	public virtual string wifi
	{
		get {
			return "wifi";
		}
	}

	public virtual string bluetooth
	{
		get {
			return "bluetooth";
		}
	}

	public virtual string screen
	{
		get {
			return "screen";
		}
	}

	public virtual string wallpaper
	{
		get {
			return "wallpaper";
		}
	}

	public virtual string account
	{
		get {
			return "account";
		}
	}

	public virtual string language
	{
		get {
			return "language";
		}
	}

	public virtual string developer
	{
		get {
			return "developer";
		}
	}

	public virtual string updates
	{
		get {
			return "updates";
		}
	}

	public virtual string connect
	{
		get {
			return "connect";
		}
	}
	
	public virtual string rescan
	{
		get {
			return "rescan";
		}
	}

	public virtual string back
	{
		get {
			return "back";
		}
	}

	public virtual string options
	{
		get {
			return "options";
		}
	}

	public virtual string open
	{
		get {
			return "open";
		}
	}

	public virtual string rate
	{
		get {
			return "rate";
		}
	}

	public virtual string unstall
	{
		get {
			return "unstall";
		}
	}

	public virtual string more
	{
		get {
			return "more";
		}
	}

	public virtual string select
	{
		get {
			return "select";
		}
	}

	public virtual string androidSettings
	{
		get {
			return "android settings";
		}
	}
}