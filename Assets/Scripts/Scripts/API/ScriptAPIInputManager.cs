using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ScriptAPI {

	public class Input
	{

		// CheckInput
		public static bool CheckInput(KeyCode Code)
		{
			return InputManager.Instance.CheckInput (Code);
		}

		public static bool CheckInputUp(KeyCode Code)
		{
			return InputManager.Instance.CheckInputUp (Code);
		}

		public static bool CheckInputDown(KeyCode Code)
		{
			return InputManager.Instance.CheckInputDown (Code);
		}
			
		public static bool CheckMouseWheelUp()
		{
			return InputManager.Instance.CheckMouseWheelUp ();
		}

		public static bool CheckMouseWheelDown()
		{
			return InputManager.Instance.CheckMouseWheelDown ();
		}
			
		public static bool CheckMouseLeftButton()
		{
			return InputManager.Instance.CheckMouseLeftButton ();
		}

		public static bool CheckMouseLeftButtonUp()
		{
			return InputManager.Instance.CheckMouseLeftButtonUp ();
		}

		public static bool CheckMouseLeftButtonDown()
		{
			return InputManager.Instance.CheckMouseLeftButtonDown ();
		}

		public static bool CheckMouseRightButton()
		{
			return InputManager.Instance.CheckMouseRightButton ();
		}

		public static bool CheckMouseRightButtonUp()
		{
			return InputManager.Instance.CheckMouseRightButtonUp ();
		}

		public static bool CheckMouseRightButtonDown()
		{
			return InputManager.Instance.CheckMouseRightButtonDown ();
		}

		public static bool CheckMouseMiddleButton()
		{
			return InputManager.Instance.CheckMouseMiddleButton ();
		}

		public static bool CheckMouseMiddleButtonUp()
		{
			return InputManager.Instance.CheckMouseMiddleButtonUp ();
		}

		public static bool CheckMouseMiddleButtonDown()
		{
			return InputManager.Instance.CheckMouseMiddleButtonDown ();
		}

		public static int GetTouchNumbers()
		{
			return InputManager.Instance.GetTouchNumbers ();
		}

		public static float GetTouchDistance(int idx1, int idx2)
		{
			return InputManager.Instance.GetTouchDistance (idx1, idx2);
		}

		public static float GetTouchCloser(int idx1, int idx2)
		{
			return InputManager.Instance.GetTouchCloser (idx1, idx2);
		}

	}

}
