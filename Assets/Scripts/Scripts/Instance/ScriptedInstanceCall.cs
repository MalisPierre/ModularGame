using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;
using System.IO;
using System.Threading;


public partial class ScriptedInstance {


	public DynValue Call(string FunctionName, DynValue []Params)
	{	
		try
		{
			return _Script.Call (_Script.Globals [FunctionName], Params);
		}
		catch (Exception e)
		{
			Debug.LogError ("ERROR  EXECUTING CALL {" + _FileName + "}{" + FunctionName + "} ==> [" + e.Message + "]:" + e.HelpLink);
			return null;
		}

	}

	public DynValue CallNoParams(string FunctionName)
	{	
		try
		{
			return _Script.Call (_Script.Globals [FunctionName]);
		}
		catch (Exception e)
		{
			Debug.LogError ("ERROR  EXECUTING CALL NO PARAMS {" + _FileName + "}{" + FunctionName + "} ==> [" + e.Message + "]:" + e.HelpLink);
			return null;
		}

	}

	public IEnumerator CallCoroutine(string FunctionName, DynValue []Params)
	{		
		try
		{
			_Script.Call (_Script.Globals [FunctionName]);
		}
		catch (Exception e)
		{
			Debug.LogError ("ERROR  EXECUTING COROUTE CALL {" + _FileName + "}{" + FunctionName + "} ==> [" + e.Message + "]:" + e.HelpLink);
		}
		yield return null;
	}

	public DynValue CallCoroutineNoParams(string FunctionName)
	{
		try
		{
			return  _Script.CreateCoroutine (_Script.Globals [FunctionName]);
		}
		catch (Exception e)
		{
			Debug.LogError ("ERROR  EXECUTING COROUTINE {" + _FileName + "}{" + FunctionName + "} ==> [" + e.Message + "]:" + e.HelpLink);
			return null;
		}
	}

	public DynValue CallCoroutineNoParams2(string FunctionName)
	{
		Thread.Sleep(5000);
		return null;
		//TailCallData dt = new TailCallData ();
		//dt.Function = (DynValue)_Script.Globals [FunctionName];
		//return DynValue.NewTailCallReq (dt);
	}

	/*
	public void CallCoroutine(string FunctionName, DynValue []Params)
	{
		//return _Script.CreateCoroutine(_Script.Globals [FunctionName]);
		string code = @"
	return function()
		Framework.IDebug(""TATA"");
		local x = 0
		while true do
			x = x + 1
			Framework.IDebug(""TETE"");
			coroutine.yield(x)
		end
	end
	";

		// Load the code and get the returned function
		Script script = new Script();

		DynValue function = script.DoString(code);
		script.Globals["Framework"] = UserData.CreateStatic<ScriptAPI>();
		// Create the coroutine in C#
		DynValue coroutine = script.CreateCoroutine(function);

		while (true)
		{
			DynValue x = coroutine.Coroutine.Resume();
			Console.WriteLine("{0}", x);
		}
	}*/



}
