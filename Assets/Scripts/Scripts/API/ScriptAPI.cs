using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using System;
using System.IO;

public partial class ScriptAPI {

	// IDEBUG
	public static void WriteDirectory(string Path)
	{
		Directory.CreateDirectory (Path);
	}

	public static float GetDistance(Vector3 PointA, Vector3 PointB)
	{
		return Vector3.Distance(PointA, PointB);
	}


	public static void IDebug(string Text)
	{
		Debug.Log (Text);
	}

	public static void OpenUrl(string Url)
	{
		Application.OpenURL (Url);
	}

	public static string GetFrameworkVersion()
	{
		return "1.1.A";
	}

	public static string GetKeyText(KeyCode Code)
	{
		return Code.ToString ();
	}

	/*
	public static CallElement CreateCallElement(string FuncName, Element Obj, DynValue [] Params)
	{
		
	}*/



	public static Vector3 CreateVector3(float x, float y, float z)
	{
		return new Vector3 (x, y, z);
	}

	public static Color CreateColor(float r, float g, float b, float a)
	{
		return new Color (r, g, b, a);
	}

	public static KeyCode CreateKeyCode(string Name)
	{
		return (KeyCode)System.Enum.Parse (typeof(KeyCode), Name);
	}

	public static string GetKeyCode(KeyCode Key)
	{
		return Key.ToString ();
	}

	public static float GetTime()
	{
		return Time.time;
	}

	public static float GetFloatRound(float Base)
	{
		return Mathf.Round(Base);
	}

	public static float GetFloatTruncate(float value, int digits)
	{
		return Mathf.Round (value * 100.0f) / 100.0f;
		//return (float)Math.Round(value, digits);
		//double mult = Math.Pow(10.0, digits);
		//double result = Math.Truncate( mult * value ) / mult;
		//return (float) result;
	}

	public static string GetFloatToString(float value)
	{
		return value.ToString ("F2");
	}

	public class PathManager
	{

		public static string GetDataFolder()
		{
			return PathBuilder.GetDataFolder ();
		}

		public static string GetConfigFolder()
		{
			return PathBuilder.GetConfigFolder ();
		}

		public static string GetSaveFolder()
		{
			return PathBuilder.GetSaveFolder ();
		}

	}




}
