using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

#if UNITY_EDITOR

using UnityEditor;

#endif


public class UtilsEditor : UtilsInstance {

//

	public static UtilsEditor	Instance { get; private set; }



#if UNITY_EDITOR

    public void Init()
	{
		Instance = this;
	}


    public void SaveMaterial(Material material, string AssetPath)
    {
        AssetDatabase.CreateAsset(material, AssetPath + ".mat");
    }

	public SaveHolder GetSaveHolder(string Name)
	{
		GameObject Prefab = ContentLoader.GetElementInEditor(Name);
		GameObject Instance = (GameObject)PrefabUtility.InstantiatePrefab(Prefab);
		Instance.transform.position = Vector3.zero;

		return Instance.GetComponent<SaveHolder>();
	}
    
	public void SelectElement(Element NewObject)
	{
		Debug.Log ("Before Call");
		Selection.activeGameObject = NewObject.gameObject;
		Debug.Log ("After Call");
	}

#endif

}
