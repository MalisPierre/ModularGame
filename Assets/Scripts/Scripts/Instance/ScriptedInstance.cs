using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;
using System.IO;
using System.Threading;

[System.Serializable]
public partial class ScriptedInstance {

	[SerializeField]
	public string 	_FileName;

	[SerializeField]
	public bool 	_CallUpdate;

	[SerializeField]
	public Script	_Script = null;

	public IEnumerator WaitXSeconds(float duration)
	{
		yield return new WaitForSeconds (duration);
	}

	public static void RegisterTypesRuntime()
	{
		UserData.RegisterType<Color>();

		UserData.RegisterType<KeyCode>();

		UserData.RegisterType<Content>();
		UserData.RegisterType<ContentLoader>();

		UserData.RegisterType<Button3D>();


		UserData.RegisterType<Panel2D>();
		UserData.RegisterType<Button2D>();
		UserData.RegisterType<Slider2D>();
		UserData.RegisterType<Text2D>();
		UserData.RegisterType<Image2D>();
		UserData.RegisterType<Input2D>();
		UserData.RegisterType<Joystick2D>();

		UserData.RegisterType<Element>();


		UserData.RegisterType<RuntimeAnimatorController> ();
		UserData.RegisterType<AnimationClip> ();
		UserData.RegisterType<Sprite>();
        UserData.RegisterType<Material>();
        UserData.RegisterType<Texture2D>();
		UserData.RegisterType<byte>();

		UserData.RegisterType<Font>();
		UserData.RegisterType<Vector3>();
		UserData.RegisterType<Quaternion>();


		UserData.RegisterType<SaveHolder>();
		UserData.RegisterType<SaveNode>();
		UserData.RegisterType<SaveValueFloat>();
		UserData.RegisterType<SaveValueInt>();
		UserData.RegisterType<SaveValueString>();

		UserData.RegisterType<ScriptAPI>();
		UserData.RegisterType<ScriptHolder> ();
		UserData.RegisterType<ScriptedInstance>();
        UserData.RegisterType<UtilsInstance>();
        UserData.RegisterType<AssetManager>();
        UserData.RegisterType<Call>();
        UserData.RegisterType<RandomGenerator>();
        UserData.RegisterType<Raycast>();
        UserData.RegisterType<Scene>();
    }

	public static void RegisterTypesEditor()
	{
		UserData.RegisterType<Color>();

		UserData.RegisterType<KeyCode>();


		UserData.RegisterType<Content>();
		UserData.RegisterType<ContentLoader>();

		UserData.RegisterType<Button3D>();


		UserData.RegisterType<Panel2D>();
		UserData.RegisterType<Button2D>();
		UserData.RegisterType<Slider2D>();
		UserData.RegisterType<Text2D>();
		UserData.RegisterType<Image2D>();
		UserData.RegisterType<Input2D>();
		UserData.RegisterType<Joystick2D>();

		UserData.RegisterType<Element>();


		UserData.RegisterType<RuntimeAnimatorController> ();
		UserData.RegisterType<AnimationClip> ();
		UserData.RegisterType<Sprite>();
        UserData.RegisterType<Material>();
        UserData.RegisterType<Texture2D>();
		UserData.RegisterType<byte>();

		UserData.RegisterType<Font>();
		UserData.RegisterType<Vector3>();
		UserData.RegisterType<Quaternion>();


		UserData.RegisterType<SaveHolder>();
		UserData.RegisterType<SaveNode>();
		UserData.RegisterType<SaveValueFloat>();
		UserData.RegisterType<SaveValueInt>();
		UserData.RegisterType<SaveValueString>();

		UserData.RegisterType<ScriptAPIEditor>();
		UserData.RegisterType<ScriptHolder> ();
		UserData.RegisterType<ScriptedInstance>();
        UserData.RegisterType<UtilsEditor>();
        UserData.RegisterType<AssetManager>();
        UserData.RegisterType<Call>();
        UserData.RegisterType<RandomGenerator>();
        UserData.RegisterType<Raycast>();
        UserData.RegisterType<Scene>();
    }

#if UNITY_EDITOR

	public void InitInEditor()
	{
		LoadScriptInEditor ();
	}

	public void LoadScriptInEditor()
	{
		try
		{
			ScriptedInstance.RegisterTypesEditor();
			this._Script = new Script ();

			string LuaData = ContentLoader.GetScriptInEditor (this._FileName);

			this._Script.DoString (LuaData);
			Table BaseTable = _Script.Call (_Script.Globals ["ListFileDepedencies"]).Table;
			string FileData = "";
			foreach(DynValue value in BaseTable.Values)
			{
				FileData = ContentLoader.GetScriptInEditor (value.String);
				this._Script.DoString (FileData);
			}

			this._Script.Globals ["Debug"] = (Action<string>)ScriptAPIEditor.IDebug;
			this._Script.Globals["KeyCode"] = UserData.CreateStatic<KeyCode>();

			this._Script.Globals["Color"] = (Func<float, float, float, float, Color>)ScriptAPIEditor.CreateColor;
			this._Script.Globals["Vector3"] = (Func<float, float, float, Vector3>)ScriptAPIEditor.CreateVector3;


			this._Script.Globals["SaveNode"] = UserData.CreateStatic<SaveNode>();
			Debug.Log("Adding Framework to script");
			this._Script.Globals["Framework"] = UserData.CreateStatic<ScriptAPIEditor>();


			if (this._Script == null) {
				Debug.LogError ("MY SCRIPT IS NULL ????????????????");

			}
		}
		catch (SyntaxErrorException ex)
		{
			Debug.LogError ("Error trying to loading script [" + this._FileName + "] ! " + ex.DecoratedMessage);
		}
	}

#endif

    public void LoadScript(string ScriptName)
	{
		try
		{
			ScriptedInstance.RegisterTypesRuntime();
			this._Script = new Script ();
			_FileName = ScriptName;

			string LuaData = ContentLoader.Instance.GetScript (ScriptName);


			//= File.ReadAllText(PathBuilder.GetScriptsFile(_FileName));



			this._Script.DoString (LuaData);
			Table BaseTable = _Script.Call (_Script.Globals ["ListFileDepedencies"]).Table;
			string FileData = "";
			foreach(DynValue value in BaseTable.Values)
			{
				FileData = EngineInstance.Instance._ContentLoader.GetScript (value.String);
				this._Script.DoString (FileData);
			}
				
			this._Script.Globals ["Debug"] = (Action<string>)ScriptAPI.IDebug;
			this._Script.Globals["KeyCode"] = UserData.CreateStatic<KeyCode>();

			this._Script.Globals["Color"] = (Func<float, float, float, float, Color>)ScriptAPI.CreateColor;
			this._Script.Globals["Vector3"] = (Func<float, float, float, Vector3>)ScriptAPI.CreateVector3;

	
			this._Script.Globals["SaveNode"] = UserData.CreateStatic<SaveNode>();
	
			this._Script.Globals["Framework"] = UserData.CreateStatic<ScriptAPI>();

			if (this._Script == null) {
				Debug.LogError ("MY SCRIPT IS NULL ????????????????");

			}
		}
		catch (SyntaxErrorException ex)
		{
			Debug.LogError ("Error trying to loading script [" + ScriptName + "] ! " + ex.DecoratedMessage);
		}
	}

	public void Init()
	{
		LoadScript (this._FileName);
	}




	public void Update()
	{
		if ((this._Script != null) && (this._CallUpdate == true)) {
			this._Script.Call (_Script.Globals["Update"]);
		}
	}


}
