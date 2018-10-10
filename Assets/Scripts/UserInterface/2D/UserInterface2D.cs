using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class UserInterface2D : MonoBehaviour {

	public ScriptedInstance			_ScriptInstance;

	public static UserInterface2D Instance { get; private set; }

	public List<Panel2D>	_Panels;

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}
		
	void Start () {
		//_ScriptInstance.Init();
		//_ScriptInstance.Call ("Init", new DynValue[0]);
	}

	void Update () {
		
	}


	public Panel2D FindPanel(string PanelId)
	{
		return _Panels.Find (x => x.gameObject.name == PanelId);
	}

	public void CreatePanel(string AssetId, string PanelId)
	{
		GameObject Prefab = EngineInstance.Instance._ContentLoader.GetPanel (AssetId);

		if (Prefab == null)
			Debug.LogError ("UI Panel [" + "UI/2D/Panels/" + PathBuilder.GetFileFromPath(AssetId) + "] not Found !");

		GameObject Instance =Instantiate(
			Prefab, 
			new Vector3(0, 0, 0),
			Quaternion.identity) as GameObject;

		Instance.transform.name = PanelId;
		Instance.transform.SetParent (this.gameObject.transform, false);

		_Panels.Add (Instance.GetComponent<Panel2D> ());
	}

	public void DeletePanel(string PanelId)
	{
		Panel2D Panel = _Panels.Find (x => x.gameObject.name == PanelId);
		Panel.Delete ();
		_Panels.Remove (Panel);
	}



}
