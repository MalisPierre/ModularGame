using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;



[System.Serializable]
public partial class Bundle
{
	public string 				_name;
	public AssetBundle			_bundle;
	public bool 				_Loaded;



	public static Bundle CreateBundle(string NewName, AssetBundle NewBundle)
	{
		Bundle Bund = new Bundle ();
		Bund._name = NewName;
		Bund._bundle = NewBundle;
		Bund._Loaded = true;
		return Bund;
	}

	public static Bundle CreateBundle(string NewName)
	{
		Bundle Bund = new Bundle ();
		Bund._name = NewName;
		Bund._bundle = null;
		Bund._Loaded = false;
		return Bund;
	}

	public void GetBundleReference(string ContentName)
	{
		_bundle = AssetBundle.LoadFromFile ("Data/" + ContentName + "/" + this._name);
	}

	public void ClearBundleReference()
	{
		_bundle.Unload (false);
	}



}