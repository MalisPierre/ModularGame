using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum AxisMode
{
	Both, // Use both
	OnlyHorizontal, // Only horizontal
	OnlyVertical // Only vertical
}

public class Joystick2D : MonoBehaviour {

	public GameObject	_Background;
	public GameObject	_Foreground;
	public Vector2		_Position;
	public float 		_MaxDistance;

	public void Initialize ()
	{
		
	}

	public void OnDrag()
	{
		Debug.Log ("On Drag");
		float Distance = Vector3.Distance (_Background.transform.position, Input.mousePosition);
		if (Distance > _MaxDistance)
			this._Foreground.transform.position = 
				_Background.transform.position - (_Background.transform.position - Input.mousePosition).normalized * _MaxDistance;
		else
			this._Foreground.transform.position = 
				_Background.transform.position - (_Background.transform.position - Input.mousePosition);//.normalized;// * _MaxDistance;
	}

	public void OnUp()
	{
		Debug.Log ("On Click");
		this._Foreground.transform.position = _Background.transform.position;
	}

	public void OnDown()
	{
		Debug.Log ("On Click");
	}

	public float GetHorizontalMovement()
	{
		return 0.0f;
	}

	public float GetVerticalMovement()
	{
		return 0.0f;
	}

	public Vector3 GetMovement()
	{
		if (_Foreground.transform.position == _Background.transform.position)
		{
			return new Vector3 (0, 0, 0);
		} 
		else 
		{
			return _Background.transform.position - _Foreground.transform.position;
		}
	}

	public void Hide()
	{
		this.gameObject.SetActive (false);
	}

	public void Show()
	{
		this.gameObject.SetActive (true);
	}

    public void Delete()
    {
        Destroy(this.gameObject);
    }


}
