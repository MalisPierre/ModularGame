using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScriptExtention{

	[MenuItem("LaVipere/Script Extention/Convert To Txt")]
	static void ConvertLuaToTxt()
	{
		//Directory.GetFiles("/", "*.lua");
		Debug.Log("Searching In[" + Application.dataPath + "]");

		string[] filePaths = System.IO.Directory.GetFiles (Application.dataPath, "*.lua", SearchOption.AllDirectories);

		Debug.Log ("Files to be renamed == " + filePaths.Length);
		for (int i = 0; i < filePaths.Length; i++) {
			Debug.Log ("Renaming [" + filePaths [i] + "]");

			FileInfo fii = new FileInfo(filePaths [i]);
			fii.MoveTo(Path.ChangeExtension(filePaths [i], ".txt"));
		}
		Debug.Log("Files Renamed !");
	}

	[MenuItem("LaVipere/Script Extention/Convert To Lua")]
	static void ConvertTxtToLua()
	{
		//Directory.GetFiles("/", "*.lua");
		Debug.Log("Searching In[" + Application.dataPath + "]");

		string[] filePaths = System.IO.Directory.GetFiles (Application.dataPath, "*.txt", SearchOption.AllDirectories);

		Debug.Log ("Files to be renamed == " + filePaths.Length);
		for (int i = 0; i < filePaths.Length; i++) {
			Debug.Log ("Renaming [" + filePaths [i] + "]");

			FileInfo foo = new FileInfo(filePaths [i]);
			foo.MoveTo(Path.ChangeExtension(filePaths [i], ".lua"));
		}
		Debug.Log("Files Renamed !");
	}


}
