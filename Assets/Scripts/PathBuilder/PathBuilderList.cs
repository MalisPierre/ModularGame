using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public partial class PathBuilder {


	public static string GetScriptsFolder(string ContentName)
	{
		return BuildPath (GetContentFolder(ContentName), "Scripts");
	}

	public static string GetScriptsFile(string BasePath)
	{
		if (BasePath.Count (xy => xy == ':') != 2)
			Debug.LogError ("Error !! Script Not Formatted [" + BasePath + "]");
		
		string[] Sep = BasePath.Split (':');

		string FilePath = "assets/contents/" + Sep [0] + "/" + Sep [1] + "/" + Sep [2] + ".txt";
		return FilePath;
	}

	public static string GetAudioFolderData()
	{
		return "Audio";
	}

	public static string GetAudioFileData(string Filename)
	{
		return BuildPath (GetAudioFolderData (), PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetAudioFolderContent(string FileName)
	{
		return "Assets/Contents/" + PathBuilder.GetContentFromPath(FileName) + "/Resources/Audio/";
	}

	//"assets/contents/base_content/resources/audio/sound/ambiance/beach_003.wav"
	public static string GetAudioFileContent(string Filename)
	{
		return BuildPath (GetAudioFolderContent (Filename), PathBuilder.GetFileFromPath(Filename)) + ".wav";
	}

	public static string GetSceneFolder()
	{
		return "Scene";
	}
		
	public static string GetSceneFile(string Filename)
	{
		return BuildPath (PathBuilder.GetSceneFolder(), PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetDialogFile(string Filename)
	{
		return BuildPath ("Dialogs", PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetImageContainerData(string Filename)
	{
		return BuildPath ("ImageContainer", PathBuilder.GetFileFromPath(Filename));
	}

	//Assets/Contents/paradise_island_01/Resources/ImageContainer/StrandedIsland/BehindRock/Peter_Stranded.prefab
	public static string GetImageContainerContent(string Filename)
	{
		return "Assets/Contents/" + PathBuilder.GetContentFromPath (Filename) + "/Resources/ImageContainer/" + PathBuilder.GetFileFromPath (Filename) + ".prefab";
	}

	//Assets/Contents/base_content/Resources/UI/2D/Panels/ToolTip.prefab
	public static string GetPanelContent(string Filename)
	{
		return "Assets/Contents/" + PathBuilder.GetContentFromPath (Filename) + "/Resources/UI/2D/Panels/" + PathBuilder.GetFileFromPath (Filename) + ".prefab";
	}

	//Assets/Contents/paradise_island_01/Resources/Scene/StrandedIsland/LittleSpot.prefab
	public static string GetSceneContent(string Filename)
	{
		return "Assets/Contents/" + PathBuilder.GetContentFromPath (Filename) + "/Resources/Scene/" + PathBuilder.GetFileFromPath (Filename) + ".prefab";
	}

	public static string GetSpriteData(string Filename)
	{
		return BuildPath ("Images", PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetAnimationData(string Filename)
	{
		return BuildPath ("Animations", PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetElementFile(string Filename)
	{
		return BuildPath (PathBuilder.GetSceneFolder(), PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetButton3dFile(string Filename)
	{
		return BuildPath (PathBuilder.GetSceneFolder(), PathBuilder.GetFileFromPath(Filename));
	}

	public static string GetLoadOrderFile()
	{
		return BuildPath (PathBuilder.GetConfigFolder (), "LoadOrder");
	}

	public static string GetContentHeaderFile(string HeaderName)
	{
		return BuildPath (PathBuilder.GetDataFolder (), HeaderName + ".content");
	}

	public static string GetBundleFile(string ContentName, string BundleName)
	{
		return BuildPath (PathBuilder.GetDataFolder (), BuildPath(ContentName, BundleName));
	}
		
	public static string GetContentFolder(string ContentName)
	{
		return BuildPath (PathBuilder.GetDataFolder (), ContentName);
	}

}
