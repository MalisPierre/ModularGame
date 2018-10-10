using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;



public partial class ContentLoader : MonoBehaviour {

	[SerializeField]
	public List<Content>	_Content;
	public static ContentLoader		Instance { get; private set; }
	
	public bool						_ModularContent;

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {

		_Content = new List<Content> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsModularContent()
	{
		return _ModularContent;
	}

	public int GetPotentialContentLenght()
	{
		return Directory.GetFiles("Data/", "*.*", SearchOption.AllDirectories)
			.Where(s => s.EndsWith(".manifest", StringComparison.OrdinalIgnoreCase)).ToList<string>().Count;
	}

	public string GetPotentialContentName(int Idx)
	{
		var Files = Directory.GetFiles("Data/", "*.*", SearchOption.AllDirectories)
			.Where(s => s.EndsWith(".manifest", StringComparison.OrdinalIgnoreCase)).ToList<string>();
		for (int i = 0; i < Files.Count; i = i + 1)
		{
			if (i == Idx)
				return Files [i].Replace (".manifest", "").Replace ("Data/", "");
		}
		return null;
	}

	public Content FindCurrentContent(string ContentName)
	{
		return _Content.Find (x => x.GetName() == ContentName);
	}

	public void AddContent(string ContentToLoad)
	{
		_Content.Add(Content.CreateContent (ContentToLoad));
	}

	public void AddContent(ContentData Data)
	{
		_Content.Add(Content.CreateContent (Data));
	}

	public void AddBundleAsync(string CurrentContent, string BundleToLoad)
	{
		Content ContentToUse = FindCurrentContent (CurrentContent);
		if (ContentToUse == null)
			Debug.LogError ("Error ! Content (" + CurrentContent + ") Not Found");
		StartCoroutine (FindCurrentContent (CurrentContent).AddBundleAsync (BundleToLoad));
	}
		


	public void UnloadAllContent()
	{

	}





}