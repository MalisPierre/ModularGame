using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SaveHolder : MonoBehaviour {

	public SaveNode		_SaveData;

	void Start () {

	}

	void Update () {

	}

	public void Bake(string Name, SaveNode NodeData)
	{
		this.transform.name = Name;
		this._SaveData = NodeData;
	}

	public void Write (string Path)
	{
		Debug.Log ("Writing Save Holder on {" + Path + "}");
		#if UNITY_EDITOR
		Object PrefabToSave = PrefabUtility.CreateEmptyPrefab(Path + ".prefab");//EditorUtility.CreateEmptyPrefab(Path + ".prefab");
		PrefabUtility.ReplacePrefab(this.gameObject, PrefabToSave);//EditorUtility.ReplacePrefab(this.gameObject, PrefabToSave);
		AssetDatabase.Refresh();
		Object.DestroyImmediate (this.gameObject);
		#endif
	}

}
