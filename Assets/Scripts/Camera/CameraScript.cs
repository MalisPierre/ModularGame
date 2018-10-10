using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;


public partial class CameraScript : MonoBehaviour {

	public ScriptedInstance			_ScriptInstance;
	public static CameraScript		Instance { get; private set; }

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {
	}

	public void Initialize(string ScriptPath)
	{
		this._ScriptInstance.LoadScript (ScriptPath);
	}
	
	// Update is called once per frame
	void Update () {
		this._ScriptInstance.Update ();
	}

	public float GetZoom()
	{
		if (this.GetComponent<Camera> ().orthographic == true)
			return this.GetComponent<Camera> ().orthographicSize;
		else
			return this.GetComponent<Camera> ().fieldOfView;
	}

	public void SetZoom(float NewZoom)
	{
		if (this.GetComponent<Camera> ().orthographic == true)
			this.GetComponent<Camera> ().orthographicSize = NewZoom;
		else
			this.GetComponent<Camera> ().fieldOfView = NewZoom;
	}

	public void SetOrthographic()
	{
		this.GetComponent<Camera> ().orthographic = true;
	}

	public void SetPerspective()
	{
		this.GetComponent<Camera> ().orthographic = false;
	}


}
