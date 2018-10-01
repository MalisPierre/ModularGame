using System.Collections.Generic;
using UnityEngine;
using System.Collections;

using MoonSharp.Interpreter;
using System;
using System.IO;

public partial class ScriptAPI {


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

	public static string GetKeyText(KeyCode Code)
	{
		return Code.ToString ();
	}



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

	}

	public static string GetFloatToString(float value)
	{
		return value.ToString ("F2");
	}



	public static bool CheckInput(KeyCode Code)
	{
		return Input.GetKey (Code);
	}

	public static bool CheckInputUp(KeyCode Code)
	{
		return Input.GetKeyUp (Code);
	}

	public static bool CheckInputDown(KeyCode Code)
	{
		return Input.GetKeyDown (Code);
	}
			
	public static bool CheckMouseLeftButton()
	{
		return Input.GetMouseButton (0);
	}

	public static bool CheckMouseLeftButtonUp()
	{
		return Input.GetMouseButtonUp (0);
	}

	public static bool CheckMouseLeftButtonDown()
	{
		return Input.GetMouseButtonDown (0);
	}

	public static Vector3 GetPosition()
	{
       return ScriptedInstance.Instance.GetPosition();
	}

	public static void SetPosition(Vector3 Pos)
	{
		ScriptedInstance.Instance.SetPosition(Pos);
	}

	public static void MoveUp(float Speed)
	{
		ScriptedInstance.Instance.MoveUp(Speed);
	}

	public static void MoveRight(float Speed)
	{
		ScriptedInstance.Instance.MoveRight(Speed);
	}

	public static void MoveForward(float Speed)
	{
		ScriptedInstance.Instance.MoveForward(Speed);
	}


}
