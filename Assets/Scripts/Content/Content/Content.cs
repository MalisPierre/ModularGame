using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;




[System.Serializable]
public class Content
{
	public string 				_name;
	public List<Bundle>			_Bundles;
	public bool 				_ScriptMode = false;
	public bool					_IsCore = false;



	public static Content CreateContent(string NewName)
	{
		Content Cont = new Content ();

		Cont._name = NewName;
		Cont._Bundles = new List<Bundle> ();
		Cont._ScriptMode = false;
		Cont._IsCore = false;
		return Cont;
	}

	public static Content CreateContent(ContentData NewData)
	{
		Content Cont = new Content ();

		Cont._name = NewData.GetName ();
		Cont._Bundles = new List<Bundle> ();
		Cont._ScriptMode = NewData._IsCore;
		Cont._IsCore = NewData._ScriptMode;
		return Cont;
	}

	public void AddBundle(Bundle NewBundle)
	{
		this._Bundles.Add (NewBundle);
	}

	public string GetName()
	{
		return this._name;
		//return this._Bundles.name;
	}


	// LOAD CONTENT
	public IEnumerator AddBundleAsync(string BundlePath)
	{

		List<AssetBundle> AlreadyLoadedInMemory = AssetBundle.GetAllLoadedAssetBundles().ToList();
		AssetBundle MyBundle = AlreadyLoadedInMemory.Find (x => x.name == BundlePath);
		if (MyBundle == null) {
			// NOT IN MEMORY, MUST LOAD                            PathBuilder.GetBundleFile (ContentName, CurrentBundle._Name)
			Debug.Log("Loading Bundle [" + PathBuilder.GetBundleFile(this._name, BundlePath) + "]");
			var bundleLoadRequest = AssetBundle.LoadFromFileAsync (PathBuilder.GetBundleFile(this._name, BundlePath));
			yield return bundleLoadRequest;

			if (bundleLoadRequest.assetBundle == null) {
				Debug.LogError ("Failed to load AssetBundle!");
			}
			this.AddBundle (Bundle.CreateBundle(BundlePath, bundleLoadRequest.assetBundle));
			yield return new WaitForSeconds (0.5f);
			SplashScreen.Instance.LoadNextBundle ();

		} else {
			// ALREADY IN MEMORY , GET REFERENCE
			//Debug.LogError ("BUNDLE[" + BundlePath + "] already loaded !!!");
			this.AddBundle (Bundle.CreateBundle(BundlePath, MyBundle));
			yield return new WaitForSeconds (0.5f);
			SplashScreen.Instance.LoadNextBundle ();
		}

	}

	public Bundle FindBundle(string BundleName)
	{
		Bundle Ret = _Bundles.Find (x => x._name == BundleName);
		if (Ret == null)
			Debug.LogError ("Error! Bundle[" + BundleName + "] not found inside [" + this._name + "]");
		return Ret;
	}


}
