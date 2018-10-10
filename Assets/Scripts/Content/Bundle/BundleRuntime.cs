using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public partial class Bundle {


	private AudioClip LoadAudioClip(string FilePath)
	{
		AudioClip Ret = _bundle.LoadAsset<AudioClip> (FilePath);
		if (Ret == null)
			Debug.LogError ("AUDIO CLIP NULL [" + FilePath + "]");
		return Ret;
	}

    private Texture2D LoadTexture(string FilePath)
    {
        Texture2D Ret = _bundle.LoadAsset<Texture2D>(FilePath);
        if (Ret == null)
            Debug.LogError("Texture2D IS NULL [" + FilePath + "]");
        return Ret;
    }

    private Sprite LoadSprite(string FilePath)
	{
		Sprite Ret = _bundle.LoadAsset<Sprite> (FilePath);
		if (Ret == null)
			Debug.LogError ("SPRITE IS NULL [" + FilePath + "]");
		return Ret;
	}

	private RuntimeAnimatorController LoadController(string FilePath)
	{
		RuntimeAnimatorController Ret = _bundle.LoadAsset<RuntimeAnimatorController> (FilePath);
		if (Ret == null)
			Debug.LogError ("CONTROLLER IS NULL [" + FilePath + "]");
		return Ret;
	}

	private Font LoadFont(string FilePath)
	{
		Font Ret = _bundle.LoadAsset<Font> (FilePath);
		if (Ret == null)
			Debug.LogError ("FONT IS NULL [" + FilePath + "] on bundle {" + _bundle.name + "}");
		return Ret;
	}

	private GameObject LoadElement(string FilePath)
	{
		GameObject Ret = _bundle.LoadAsset<GameObject> (FilePath);
		if (Ret == null)
			Debug.LogError ("ELEMENT IS NULL [" + FilePath + "] on bundle {" + _bundle.name + "}");
		return Ret;
	}

	private GameObject LoadButton3d(string FilePath)
	{
		GameObject Ret = _bundle.LoadAsset<GameObject> (FilePath);
		if (Ret == null)
			Debug.LogError ("BUTTON 3D IS NULL [" + FilePath + "] on bundle {" + _bundle.name + "}");
		return Ret;
	}

	private GameObject LoadBlock(string FilePath)
	{
		GameObject Ret = _bundle.LoadAsset<GameObject> (FilePath);
		if (Ret == null)
			Debug.LogError ("BLOCK IS NULL [" + FilePath + "]");
		return Ret;
	}

	private GameObject LoadPanel(string FilePath)
	{
		GameObject Ret = _bundle.LoadAsset<GameObject> (FilePath);
		if (Ret == null)
			Debug.LogError ("PANEL IS NULL [" + FilePath + "]");
		return Ret;
	}

	private string LoadScriptAsTextAsset(string FilePath)
	{
		//Debug.LogWarning ("Loading Script As TextAsset [" + FilePath + "]");
		TextAsset Ret = _bundle.LoadAsset<TextAsset> (FilePath);
		if (Ret == null)
			Debug.LogError ("SCRIPT IS NULL [" + FilePath + "]");
		return Ret.text;
	}

	private string LoadScriptAsFile(string FilePath)
	{
		//Debug.LogWarning ("Loading Script As File [" + FilePath + "]");
		if (!File.Exists (FilePath)) {
			Debug.LogError ("SCRIPT IS NULL [" + FilePath + "]");
			return "";
		}
		return File.ReadAllText(FilePath);
	}

	public AudioClip GetAudioClip(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadAudioClip (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadAudioClip (FilePath);
		}
	}

    public Texture2D GetTexture(string ContentPath, string FilePath)
    {
        if (_Loaded == true)
        {
            return LoadTexture(FilePath);
        }
        else
        {
            GetBundleReference(ContentPath);
            return LoadTexture(FilePath);
        }
    }

    public Sprite GetSprite(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadSprite (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadSprite (FilePath);
		}
	}

	public RuntimeAnimatorController GetController(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadController (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadController (FilePath);
		}
	}

	public SaveNode GetSaveNodeData(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadElement (FilePath).GetComponent<SaveHolder> ()._SaveData;
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadElement (FilePath).GetComponent<SaveHolder> ()._SaveData;
		}
	}

	public Font GetFont(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadFont (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadFont (FilePath);
		}
	}

	public GameObject GetElement(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadElement (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadElement (FilePath);
		}
	}

	public GameObject GetButton3d(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadButton3d (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadButton3d (FilePath);
		}
	}

	public GameObject GetBlock(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadBlock (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadBlock (FilePath);
		}
	}

	public GameObject GetPanel(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadPanel (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadPanel (FilePath);
		}
	}

	public string GetScriptAsTextAsset(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadScriptAsTextAsset (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadScriptAsTextAsset (FilePath);
		}
	}

	public string GetScriptAsFile(string ContentPath, string FilePath)
	{
		if (_Loaded == true) {
			return LoadScriptAsFile (FilePath);
		}
		else
		{
			GetBundleReference (ContentPath);
			return LoadScriptAsFile (FilePath);
		}
	}

}
