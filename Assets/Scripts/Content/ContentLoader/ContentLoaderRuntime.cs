using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ContentLoader {


	public AudioClip GetAudioClip(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".wav";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetAudioClip(ContentPath, FilePath);
	}

	public Font GetFont(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".ttf";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetFont(ContentPath, FilePath);
	}

	public GameObject GetElement(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".prefab";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetElement(ContentPath, FilePath);
	}

	public SaveNode GetSaveNodeData(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".prefab";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetSaveNodeData(ContentPath, FilePath);
	}

	public GameObject GetButton3d(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".prefab";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetButton3d(ContentPath, FilePath);
	}
		
	public Sprite GetSprite(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".png";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetSprite(ContentPath, FilePath);
	}

    public Texture2D GetTexture(string BasePath)
    {
        string[] Sep = BasePath.Split(':');
        string ContentPath = Sep[0];
        string BundlePath = Sep[1];
        string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep[2] + ".png";
        return this.FindCurrentContent(ContentPath).FindBundle(BundlePath).GetTexture(ContentPath, FilePath);
    }

    public RuntimeAnimatorController GetController(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".controller";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetController(ContentPath, FilePath);
	}

	public GameObject GetBlock(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".prefab";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetBlock(ContentPath, FilePath);
	}

	public GameObject GetPanel(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".prefab";
		return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetPanel(ContentPath, FilePath);
	}



	public string GetScript(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".txt";
		bool ScriptMode = this.FindCurrentContent (ContentPath)._ScriptMode;
		if (ScriptMode == false)
			return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetScriptAsTextAsset(ContentPath, FilePath);
		else
			return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetScriptAsTextAsset(ContentPath, FilePath);
			//return this.FindCurrentContent(ContentPath).FindBundle (BundlePath).GetScriptAsFile(ContentPath, FilePath);
	}


}
