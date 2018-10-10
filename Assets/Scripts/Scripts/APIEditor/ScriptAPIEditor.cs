using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

#if UNITY_EDITOR

using UnityEditor;

#endif


public partial class ScriptAPIEditor : ScriptAPI {

#if UNITY_EDITOR

    public static UtilsEditor GetUtils()
    {
        return GameObject.FindObjectOfType<UtilsEditor>();
        //return UtilsEditor.Instance;
    }

    public static AssetManager GetAssetManager()
    {
       return GameObject.Find("_Utils").GetComponent<AssetManager>();
    }

    public static Call GetCall()
    {
        return GameObject.Find("_Utils").GetComponent<Call>();
    }

    public static RandomGenerator GetRandomGenerator()
    {
        return GameObject.Find("_Utils").GetComponent<RandomGenerator>();
    }

    public static Raycast GetRaycast()
    {
        return GameObject.Find("_Utils").GetComponent<Raycast>();
    }

    public static Scene GetScene()
    {
        return GameObject.Find("_Utils").GetComponent<Scene>();
    }


    
    public class Save : ScriptAPI.Save
    {
    		public static SaveNode CreateNode(string NewKey)
		{
			return SaveNode.Create (NewKey);
		}

		public static SaveValueFloat CreateValueFloat(string NewKey, float NewValue)
		{
			return SaveValueFloat.Create (NewKey, NewValue);
		}

		public static SaveValueInt CreateValueInt(string NewKey, int NewValue)
		{
			return SaveValueInt.Create (NewKey, NewValue);
		}

		public static SaveValueString CreateValueString(string NewKey, string NewValue)
		{
			return SaveValueString.Create (NewKey, NewValue);
		}

		public static void WriteBynary(string NewPath, byte[]Data)
		{
			SaveHandler.WriteBynary (Data, NewPath);
		}
			
		public static Texture2D LoadTexture(string Path)
		{
			return SaveHandler.LoadTexture (Path);
		}


		public static void WriteTexture(Texture2D Img, string NewPath)
		{
			SaveHandler.WriteTexture (Img, NewPath);
		}

		public static void WriteSave(SaveNode SaveGame, string NewPath)
		{
			SaveHandler.WriteSave (SaveGame, NewPath);
		}

		public static SaveNode ReadSave(string NewPath)
		{
			SaveHandler Handler = new SaveHandler ();
			return Handler.ReadSave (NewPath);
		}

		public static string GetSaveName(string FolderPath, int Idx)
		{
			return SaveHandler.GetSaveName(FolderPath, Idx);
		}

		public static string GetSaveName(string FolderPath, string Extention, int Idx)
		{
			return SaveHandler.GetSaveName(FolderPath, Extention, Idx);
		}

		public static string GetSaveFile(string FolderPath, int Idx)
		{
			return SaveHandler.GetSaveFile(FolderPath, Idx);
		}

		public static string GetSaveFile(string FolderPath, string Extention, int Idx)
		{
			return SaveHandler.GetSaveFile(FolderPath, Extention, Idx);
		}

		public static int GetSavesLen(string FolderPath)
		{
			return SaveHandler.GetSavesLen (FolderPath);
		}

		public static int GetSavesLen(string FolderPath, string Extention)
		{
			return SaveHandler.GetSavesLen (FolderPath, Extention);
		}

		public static bool SaveFileExist(string Name)
		{
			return SaveHandler.SaveFileExist(Name);
		}
    }
#endif

}
