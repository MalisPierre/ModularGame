using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

[System.Serializable]
public class Button3D : MonoBehaviour {

	public ScriptedInstance			_Instance;

	void Start () {
		_Instance.Init();
	}

	void Update () {
		
	}

	public void OnClick()
	{
		_Instance.CallNoParams ("OnClick");
	}

	public void Delete()
	{

	}

	public void Hide()
	{
		this.gameObject.SetActive (false);
	}

	public void Show()
	{
		this.gameObject.SetActive (true);
	}


}
