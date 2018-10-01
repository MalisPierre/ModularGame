using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;
using System.IO;
using System.Threading;

[System.Serializable]
public class ScriptedInstance : MonoBehaviour {

    public static ScriptedInstance Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);

    }

    [SerializeField]
	public string 	_FileName;

	[SerializeField]
	public bool 	_CallUpdate;

	[SerializeField]
	public Script	_Script = null;


	public static void RegisterTypes()
	{
		UserData.RegisterType<Color>();

		UserData.RegisterType<KeyCode>();

		
		UserData.RegisterType<Sprite>();
        UserData.RegisterType<Material>();
        UserData.RegisterType<Texture2D>();
		UserData.RegisterType<byte>();

		UserData.RegisterType<Font>();
		UserData.RegisterType<Vector3>();
		UserData.RegisterType<Quaternion>();


		UserData.RegisterType<ScriptAPI>();
		UserData.RegisterType<ScriptedInstance>();
    }

    public void LoadScript(string ScriptName)
	{
		try
		{
			ScriptedInstance.RegisterTypes();
			this._Script = new Script ();
			_FileName = ScriptName;

            TextAsset TextScript = (TextAsset)Resources.Load(ScriptName, typeof(TextAsset)) as TextAsset;
            if (TextScript == null)
                Debug.LogError("TextScript Is Null");
            string LuaData = TextScript.text;


			this._Script.DoString (LuaData);
	
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

	void Start()
	{
		Init();
	}

	public void Init()
	{
		LoadScript (this._FileName);
		this._Script.Call (_Script.Globals["Init"]);
	}

	public void Update()
	{
		if ((this._Script != null) && (this._CallUpdate == true)) {
			this._Script.Call (_Script.Globals["Update"]);
		}
	}








	public Vector3 GetPosition()
	{
		return this.transform.position;
	}

	public void SetPosition(Vector3 Pos)
	{
		this.transform.position = Pos;
	}

	public void MoveUp(float Speed)
	{
		this.transform.position = this.transform.position + (new Vector3(0.0f, Speed * Time.deltaTime, 0.0f));
	}

	public void MoveRight(float Speed)
	{
		this.transform.position = this.transform.position + (new Vector3(Speed * Time.deltaTime, 0.0f, 0.0f));
	}

	public void MoveForward(float Speed)
	{
		this.transform.position = this.transform.position + (new Vector3(0.0f, 0.0f, Speed * Time.deltaTime));
	}


}
