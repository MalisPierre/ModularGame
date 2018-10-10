using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;
using System.IO;
using System.Threading;

/*
public class CallEngine : CallData
{

	public CallEngine CreateCall(string Func, DynValue []Params)
	{
		_FuncName = Func;
		_Params = Params;
	}

	public DynValue Call()
	{
		EngineInstance.Instance._ScriptInstance.Call (this._FuncName, this._Params);
	}
}

public class CallElement : CallData
{
	protected Element _Obj;

	public CallElement CreateCall(string Func, Element Obj, DynValue []Params)
	{
		_FuncName = Func;
		_Obj = Obj;
		_Params = Params;
	}

	public Element GetObject()
	{
		return this._Obj;
	}

	public DynValue Call()
	{
		this._Obj.Call (this._FuncName, this._Params);
	}
}

public class CallData{

	protected string				_FuncName;
	protected DynValue []			_Params;

	public CallData Create(string Func, DynValue []Params)
	{
		this._FuncName = Func;
		this._Params = Params;
	}

	public string GetFunctionName()
	{
		return this._FuncName;
	}

	public DynValue GetParams()
	{
		return this._Params;
	}



}
*/
public partial class ScriptedInstance {

}
