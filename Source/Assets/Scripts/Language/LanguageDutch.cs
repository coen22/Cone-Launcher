using UnityEngine;
using System.Collections;

public class LanguageDutch : Language {

	public override string[] languages
	{
		get {
			return new string[] {"engels", "frans", "nederlands", "duits", "portugees", "spaans", "italiaans"};
		}
	}

	public override string hello
	{
		get {
			return "hey, ";
		}
	}

	public override string settings
	{
		get {
			return "instellingen";
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
			return "scherm";
		}
	}
	
	public override string wallpaper
	{
		get {
			return "achtergrond";
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
			return "taal";
		}
	}
	
	public override string developer
	{
		get {
			return "ontwikkelaar";
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
			return "verbind";
		}
	}
	
	public override string rescan
	{
		get {
			return "opniew scannen";
		}
	}
	
	public override string back
	{
		get {
			return "terug";
		}
	}
	
	public override string options
	{
		get {
			return "opties";
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
			return "beoordeel";
		}
	}
	
	public override string unstall
	{
		get {
			return "verwijder";
		}
	}
	
	public override string more
	{
		get {
			return "meer";
		}
	}

	public override string select
	{
		get {
			return "selecteer";
		}
	}
}
