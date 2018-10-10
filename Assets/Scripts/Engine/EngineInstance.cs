using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using MoonSharp.Interpreter;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class EngineInstance	 : MonoBehaviour {


	public static EngineInstance		Instance { get; private set; }

	public ScriptedInstance			_ScriptInstance;

	public ContentLoader			_ContentLoader;

	public bool _Initialized = false;

	public string	_ConfigName;
	public string	_ConfigVersion;

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {
		//_ScriptInstance.Init ();
	}

	public string GetConfigName()
	{
		return _ConfigName;//"platform_solver";
	}

	public string GetConfigVersion()
	{
		return _ConfigVersion;//"1.0.A";
	}

	public static string GetPlatformName()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
			return "Windows+x32";

		case RuntimePlatform.WindowsEditor:
			return "Windows+x32";

		case RuntimePlatform.Android:
			return "Android";

		default:
			return "Windows+x32";
		}
	}


	public void InitScriptEngine(string EnginePath, string CameraPath, string UserInterfacePath)
	{
		CameraScript.Instance.Initialize (CameraPath);
		UserInterface2D.Instance._ScriptInstance.LoadScript (UserInterfacePath);
		ScriptAPI.Camera.CallNoParams ("Init");
		ScriptAPI.UserInterface_2D.CallNoParams ("Init");
		//ScriptAPI.QuestHandler.CallNoParams ("Init");
		this._ScriptInstance.LoadScript (EnginePath);
		Debug.Log ("BEFORE ENGINE CALL INIT");
		this._ScriptInstance.CallNoParams ("Init");
		_Initialized = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (_Initialized == true)
			_ScriptInstance.CallNoParams ("Update");
	}

	public ContentLoader GetContentManager()
	{
		return this._ContentLoader;
	}

	public void LoadLevel(string Name)
	{
		//SceneManager.LoadScene("Scenes/Scene/" + Name, LoadSceneMode.Single);
	}

	public void ExitGame()
	{
	


		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
			Application.Quit ();
			return;

		case RuntimePlatform.WindowsEditor:
			#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
			#endif
			return;

		case RuntimePlatform.Android:
			Application.Quit ();
			return;

		default:
			Application.Quit ();
			return;
		}

	
	
	}


}
