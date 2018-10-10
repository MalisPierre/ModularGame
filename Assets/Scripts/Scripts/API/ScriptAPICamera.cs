using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public partial class ScriptAPI {



	public class Camera
	{
		//CAMERA
		public static float GetZoom()
		{
			return CameraScript.Instance.GetZoom ();
		}

		public static void SetZoom(float NewZoom)
		{
			CameraScript.Instance.SetZoom (NewZoom);
		}

		public static void SetOrthographic()
		{
			CameraScript.Instance.SetOrthographic ();
		}

		public static void SetPerspective()
		{
			CameraScript.Instance.SetPerspective ();
		}


		//TRANSFORMS

		public static void LookAt(Vector3 TargetPos)
		{
			CameraScript.Instance.LookAt (TargetPos);
		}

		public static void SmoothLookAt(Vector3 TargetPos, float Speed)
		{
			CameraScript.Instance.SmoothLookAt (TargetPos, Speed);
		}

		public static void SmoothSetAt(Quaternion TargetRot, float Speed)
		{
			CameraScript.Instance.SmoothSetAt (TargetRot, Speed);
		}

		public static void MoveToward(Vector3 TargetPos, float Speed)
		{
			CameraScript.Instance.MoveToward (TargetPos, Speed);
		}

		public static Vector3 Get3DMousePosition ()
		{
			return CameraScript.Instance.Get3DMousePosition();
		}

		public static void SetPosition(Vector3 NewPos)
		{
			CameraScript.Instance.SetPosition(NewPos);
		}

		public static void MoveUp(float Value)
		{
			CameraScript.Instance.MoveUp (Value);
		}

		public static void MoveRight(float Value)
		{
			CameraScript.Instance.MoveRight (Value);
		}

		public static void MoveForward(float Value)
		{
			CameraScript.Instance.MoveForward (Value);
		}


		public static void RotateUp(float Value)
		{
			CameraScript.Instance.RotateUp (Value);
		}

		public static void RotateDown(float Value)
		{
			CameraScript.Instance.RotateDown (Value);
		}

		public static void RotateRight(float Value)
		{
			CameraScript.Instance.RotateRight (Value);
		}

		public static void RotateLeft(float Value)
		{
			CameraScript.Instance.RotateLeft (Value);
		}

		public static float GetRotationX()
		{
			return  CameraScript.Instance.GetRotationX ();
		}

		public static float GetRotationY()
		{
			return  CameraScript.Instance.GetRotationY ();
		}

		public static float GetRotationZ()
		{
			return  CameraScript.Instance.GetRotationZ ();
		}

		public static Vector3 GetRotation()
		{
			return  CameraScript.Instance.GetRotation ();
		}

		public static Vector3 GetPosition()
		{
			return  CameraScript.Instance.GetPosition ();
		}

		public static void SetRotation(Vector3 Rot)
		{
			CameraScript.Instance.SetRotation (Rot);
		}

		// SCRIPT
		public static DynValue Call(string FuncName, DynValue []Params)
		{
			return CameraScript.Instance._ScriptInstance.Call (FuncName, Params);
		}

		public static DynValue CallNoParams(string FuncName)
		{
			return CameraScript.Instance._ScriptInstance.CallNoParams (FuncName);
		}

	}



}
