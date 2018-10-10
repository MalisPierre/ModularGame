using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonSharp.Interpreter;

public class Input2D : MonoBehaviour {

	public ScriptedInstance			_Instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnValueChanged()
	{
		_Instance.CallNoParams ("OnValueChanged");
	}

	public void OnEndEdit()
	{
		_Instance.CallNoParams ("OnEndEdit");
	}

	public void SetValue(string NewValue)
	{
		this.GetComponent<InputField> ().text = NewValue;
	}

	public string GetValue()
	{
		return this.GetComponent<InputField> ().text;
	}

	public void Initialize ()
	{
		if (_Instance._FileName != "")
			_Instance.Init ();
	}

	public DynValue Call(string FuncName, DynValue []Params)
	{
		return this._Instance.Call (FuncName, Params);
	}


    public void Delete()
    {
        Destroy(this.gameObject);
    }


}
