using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MouseAction {
	None = 0,
	MoveRight = 1,
	MoveLeft = 2,
	MoveUp = 3,
	MoveDown = 4
}

public enum MouseMode {
	Free = 0,
	Locked = 1,
}


public class InputManager : MonoBehaviour {




	public static InputManager Instance { get; private set; }

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}


	// Use this for initialization
	void Start () {
		
	}

	public bool CheckInput(KeyCode NewKey)
	{
		return Input.GetKey (NewKey);
	}

	public bool CheckInputUp(KeyCode NewKey)
	{
		return Input.GetKeyUp (NewKey);
	}

	public bool CheckInputDown(KeyCode NewKey)
	{
		return Input.GetKeyDown (NewKey);
	}

	public bool CheckMouseLeftButton()
	{
		return Input.GetMouseButton (0);
	}

	public bool CheckMouseLeftButtonUp()
	{
		return Input.GetMouseButtonUp (0);
	}

	public bool CheckMouseLeftButtonDown()
	{
		return Input.GetMouseButtonDown (0);
	}

	public bool CheckMouseRightButton()
	{
		return Input.GetMouseButton (1);
	}

	public bool CheckMouseRightButtonUp()
	{
		return Input.GetMouseButtonUp (1);
	}

	public bool CheckMouseRightButtonDown()
	{
		return Input.GetMouseButtonDown (1);
	}

	public bool CheckMouseMiddleButton()
	{
		return Input.GetMouseButton (2);
	}

	public bool CheckMouseMiddleButtonUp()
	{
		return Input.GetMouseButtonUp (2);
	}

	public bool CheckMouseMiddleButtonDown()
	{
		return Input.GetMouseButtonDown (2);
	}

	public bool CheckMouseWheelUp()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") > 0.0f)
			return true;
		else
			return false;
	}

	public bool CheckMouseWheelDown()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") < 0.0f)
			return true;
		else
			return false;
	}

	public bool CheckMouse(MouseAction NewAction)
	{
		if (
			(NewAction == MouseAction.MoveRight) &&
			(Input.GetAxis ("Mouse X") > 0))
			return true;
		else if (
			(NewAction == MouseAction.MoveLeft) &&
			(Input.GetAxis ("Mouse X") < 0))
			return true;
		else if (
			(NewAction == MouseAction.MoveUp) &&
			(Input.GetAxis ("Mouse Y") > 0))
			return true;
		else if (
			(NewAction == MouseAction.MoveDown) &&
			(Input.GetAxis ("Mouse Y") < 0))
			return true;
		else
			return false;
	}

	public void SetCursorMode(MouseMode NewMode)
	{
		if (NewMode == MouseMode.Locked)
			LockCursor ();
		else
			FreeCursor ();

	}

	private void FreeCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public int GetTouchNumbers()
	{
		return Input.touchCount;
	}

	public float GetTouchDistance(int idx1, int idx2)
	{
		return (Input.GetTouch (idx1).position - Input.GetTouch (idx2).position).magnitude;
	}

	public float GetTouchCloser(int idx1, int idx2)
	{
		return ((Input.GetTouch (idx1).position - Input.GetTouch (idx1).deltaPosition) - (Input.GetTouch (idx2).position - Input.GetTouch (idx2).deltaPosition)).magnitude;
	}

}
