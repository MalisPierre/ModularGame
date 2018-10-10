using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class Bundle {
#if UNITY_EDITOR

	public static string LoadScriptInEditor(string FilePath)
	{
		Debug.LogWarning ("Loading Script As File");
		if (!File.Exists (FilePath)) {
			Debug.LogError ("SCRIPT IS NULL [" + FilePath + "]");
			return "";
		}
		return File.ReadAllText(FilePath);
	}

	public static GameObject GetElementInEditor(string FilePath)
	{
		GameObject Ret = (GameObject)AssetDatabase.LoadAssetAtPath(FilePath, typeof(GameObject));
		if (Ret == null)
			Debug.LogError ("ELEMENT IS NULL [" + FilePath + "] on bundle ");
		return Ret;
	}

    public static Texture2D GetTextureInEditor(string FilePath)
	{
		Texture2D Ret = (Texture2D)AssetDatabase.LoadAssetAtPath(FilePath, typeof(Texture2D));
		if (Ret == null)
			Debug.LogError ("TEXTURE IS NULL [" + FilePath + "] on bundle ");
		return Ret;
	}

#endif

}
