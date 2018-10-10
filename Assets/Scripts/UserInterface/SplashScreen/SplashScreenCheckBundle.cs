using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public partial class SplashScreen {

	public void CheckLoadBundles()
	{
		this._Status = SplashScreenStatus.DOWNLOAD_BUNDLES;
		for (int i = 0; i < _ContentDataList.Count; i = i + 1) {
			string CurrentHeaderPath = PathBuilder.GetContentHeaderFile (_LoadOrder.GetHeader (i)._Name);


			Debug.Log ("Current Content Path = " + CurrentHeaderPath + " BundleCount = " + _ContentDataList[i].GetBundleCount());

			for (int j = 0; j < _ContentDataList[i].GetBundleCount(); j = j + 1) {
				
				//BundleData CurrentBundle = BundleData.GetFromSaveNode(Handler.ReadSave (CurrentHeaderPath));
				if (!File.Exists (PathBuilder.GetBundleFile(_ContentDataList[i].GetName(), _ContentDataList[i].GetBundle (j)._Name))) {
					Debug.LogWarning ("Bundle [" + _ContentDataList[i].GetName () + "][" + _ContentDataList[i].GetBundle (j)._Name + "] NOT EXIST");
					TryToDownloadBundle (_ContentDataList[i].GetName (), _ContentDataList[i].GetBundle (j));
					return;
				} else {
					Debug.Log ("Bundle [" + _ContentDataList[i].GetName () + "][" + _ContentDataList[i].GetBundle (j)._Name + "] Found");
				}
			}

		}
		Debug.LogWarning ("END OF FUNCTION REACHED");
		StartLoadingContent2 ();


	}
}
