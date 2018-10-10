using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonSharp.Interpreter;

public class Slider2D : Item2D {

	public ScriptedInstance			_ScriptInstance;

	void Start () {

	}

	void Update () {

	}

	public void Initialize ()
	{
		if (_ScriptInstance._FileName != "")
			_ScriptInstance.Init ();
	}

	public void OnSlider()
	{
		_ScriptInstance.CallNoParams ("OnSlider");
	}

	public void SetPadding(bool PaddingMode)
	{
		this.GetComponent<Slider> ().wholeNumbers = PaddingMode;
	}
		
	public void SetMinValue(float NewValue)
	{
		this.GetComponent<Slider> ().minValue = NewValue;
	}
		
	public void SetMaxValue(float NewValue)
	{
		this.GetComponent<Slider> ().maxValue = NewValue;
	}
			
	public void SetValue(float NewValue)
	{
		this.GetComponent<Slider> ().value = NewValue;
	}

	public float GetValue()
	{
		return this.GetComponent<Slider> ().value;
	}

	public DynValue Call(string FuncName, DynValue []Params)
	{
		return this._ScriptInstance.Call (FuncName, Params);
	}

    public void Delete()
    {
        Destroy(this.gameObject);
    }

}
