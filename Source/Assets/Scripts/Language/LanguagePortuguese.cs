using UnityEngine;
using System.Collections;

public class LanguagePortuguese : Language {

	// Translation info
	// Change the <return info> to what it should be in your language
	// Do this for lines like:
	// return "<return info>";

	// Example (French)

	// return "hi, ";
	// return "salut, ";

	public override string hello
	{
		get {
			return "olá, ";
		}
	}

	public override string settings
	{
		get {
			return "Definições";
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
			return "ecrã";
		}
	}

	public override string wallpaper
	{
		get {
			return "papel de parede";
		}
	}

	public override string account
	{
		get {
			return "perfil";
		}
	}

	public override string language
	{
		get {
			return "lingua";
		}
	}

	public override string developer
	{
		get {
			return "desenvolvedor";
		}
	}

	public override string updates
	{
		get {
			return "atualizações";
		}
	}

	public override string connect
	{
		get {
			return "ligar";
		}
	}
	
	public override string rescan
	{
		get {
			return "re scanear";
		}
	}

	public override string back
	{
		get {
			return "voltar";
		}
	}

	public override string options
	{
		get {
			return "opções";
		}
	}

	public override string open
	{
		get {
			return "abrir";
		}
	}

	public override string rate
	{
		get {
			return "avaliar";
		}
	}

	public override string unstall
	{
		get {
			return "desinstalar";
		}
	}

	public override string more
	{
		get {
			return "mais";
		}
	}

	public override string select
	{
		get {
			return "selecionar";
		}
	}

	public override string androidSettings
	{
		get {
			return "definições do android";
		}
	}
}
