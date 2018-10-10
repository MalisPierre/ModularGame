using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class BuildSettingsWindow : EditorWindow
{

	[SerializeField]
	public bool					_DevelopmentBuild;

	public Texture2D 			_Icon;

	public void UpdateSettings()
	{
		EditorUserBuildSettings.development = this._DevelopmentBuild;
		EditorUserBuildSettings.allowDebugging = this._DevelopmentBuild;

		//PlayerSettings.Android.bundleVersionCode;
		//PlayerSettings.companyName = "";
		//PlayerSettings.productName = "";


		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTargetGroup.Android, BuildTarget.Android);
		//PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, _Icon);
		//EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug
		//AndroidInput.touchCountSecondary
	}

	public static void Init()
	{
		// Get existing open window or if none, make a new one:
		BuildSettingsWindow window = (BuildSettingsWindow)EditorWindow.GetWindow(typeof(BuildSettingsWindow));
		window._DevelopmentBuild = false;

		window.Show();
	}

	/*
	[ExecuteInEditMode]
	void OnGUI()
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		//_Script._FileName = EditorGUILayout.TextField("Text Field", _Script._FileName);

		_Icon = (Texture2D)EditorGUI.ObjectField(new Rect (5, 5, 200, 20), "Build Icon:", _Icon, typeof(Texture2D));

		this._DevelopmentBuild = EditorGUILayout.Toggle("Debug Mode", this._DevelopmentBuild);
		if (GUILayout.Button ("Update Settings")) {
			UpdateSettings ();
			//Selection.gameObjects = 
		}
	}
*/

}

public class BuildSettings {

	[MenuItem("LaVipere/Build Settings")]
	static void BuildSettingsProcess()
	{
		BuildSettingsWindow.Init ();
	}
}
