using UnityEngine;
using System.Collections;

public class LanguageFrench : Language {

	// Translation info
	// Change the <return info> to what it should be in your language
	// Do this for lines like:
	// return "<return info>";
	
	// Example
	
	// return "hi, ";
	// return "salut, ";

	public override string[] languages
	{
		get {
			return new string[] {"anglais", "français", "néerlandais", "german", "portuguese", "spanish", "italian"};
		}
	}

	public override string hello
	{
		get {
			return "salut, ";
		}
	}

	public override string settings
	{
		get {
			return "paramètres";
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
			return "ecran";
		}
	}
	
	public override string wallpaper
	{
		get {
			return "papier peint";
		}
	}
	
	public override string account
	{
		get {
			return "compte";
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
			return "développeur";
		}
	}
	
	public override string updates
	{
		get {
			return "des mises à jour";
		}
	}

	
	public override string connect
	{
		get {
			return "connecter";
		}
	}

	// TODO Translate These
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
			return "ouvrir";
		}
	}
	
	public override string rate
	{
		get {
			return "évaluer";
		}
	}
	
	public override string unstall
	{
		get {
			return "enlever";
		}
	}
	
	public override string more
	{
		get {
			return "plus";
		}
	}

	public virtual string select
	{
		get {
			return "sélectionner";
		}
	}
}
