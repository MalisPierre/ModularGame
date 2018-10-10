using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ImageType {
	Normal,
	Cutout,
	Transparent,
    Background
};

public partial class Element : MonoBehaviour {
	
	public ScriptedInstance			_ScriptInstance;

	public void Init () {
		
		if (_ScriptInstance._FileName != "") {

			_ScriptInstance.Init ();
		}
	}

	public void OnEditor()
	{
		Debug.Log ("On Editor [" + this.gameObject.transform.name + "]");
		this.gameObject.GetComponent<MeshRenderer> ().sharedMaterial.SetFloat ("Intensity", 0.0f);
	}

	public void InitScript(string path)
	{
		_ScriptInstance._FileName = path;
		Init ();
	}
	// Update is called once per frame
	void Update () {
		if ((_ScriptInstance._CallUpdate == true) && (_ScriptInstance._Script != null))
			_ScriptInstance.CallNoParams ("Update");
	}

	public void SetParent(Element Obj)
	{
		this.transform.parent = Obj.transform;
	}

	public void Hide()
	{
		this.gameObject.SetActive (false);
	}

	public void Show()
	{
		this.gameObject.SetActive (true);
	}

	public DynValue Call(string FuncName, DynValue []Params)
	{
		return this._ScriptInstance.Call (FuncName, Params);
	}

	public void CallCoroutine(string FuncName, DynValue []Params)
	{
		StartCoroutine (this.CallCoroute (FuncName, Params));
	}

	private IEnumerator CallCoroute(string FuncName, DynValue []Params)
	{
		Closure resumerFunc = this._ScriptInstance._Script.DoString("return function(c, ...) coroutine.resume(c, ...); end").Function;

		DynValue dv = this._ScriptInstance._Script.CreateCoroutine(this._ScriptInstance._Script.Globals.Get(FuncName));

		// Resumes the coroutine until its completion
		for (int i = 0; i < 5; i++) {
			resumerFunc.Call (dv, "C# world");
		}
		yield return new WaitForSeconds(5.0f);
	}



	public string GetTag()
	{
		return this.gameObject.tag;
	}

	public string GetLayer()
	{
		return LayerMask.LayerToName(this.gameObject.layer);
	}

	public string GetName()
	{
		return this.gameObject.name;
	}

	public void Delete()
	{
		Destroy (this.gameObject);
	}


}
