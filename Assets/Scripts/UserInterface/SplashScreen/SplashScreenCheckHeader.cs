using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public partial class SplashScreen {

	void FinishLoadConfig()
	{
		_ContentDataList = new List<ContentData> ();
		_TotalBundleNumber = 0;
		for (int i = 0; i < _LoadOrder.GetHeaderCount(); i = i + 1) {
			string CurrentHeaderPath = PathBuilder.GetContentHeaderFile (_LoadOrder.GetHeader (i)._Name);
			SaveHandler Handler = new SaveHandler ();
			ContentData CurrentData = ContentData.ReadData(Handler.ReadSave (CurrentHeaderPath));
			_TotalBundleNumber = _TotalBundleNumber + CurrentData.GetBundleCount ();
			_ContentDataList.Add (CurrentData);
		}
		CheckLoadBundles ();
	}

	void CheckLoadConfig()
	{
		Debug.Log ("SplashScreenStart 8");
		for (int i = 0; i < _LoadOrder.GetHeaderCount(); i = i + 1) {
			string CurrentHeaderPath = PathBuilder.GetContentHeaderFile (_LoadOrder.GetHeader (i)._Name);
			if (!File.Exists (CurrentHeaderPath)) {
				Debug.LogWarning ("Header not found [" + CurrentHeaderPath + "]");
				TryToDownloadHeader (_LoadOrder.GetHeader (i));
				return;
			} else { 
			}
		}
		FinishLoadConfig ();
		Debug.Log ("SplashScreenStart 9");
		//_DataToLoad
	}



	void StartCheckLoadConfig()
	{
		this._Status = SplashScreenStatus.DOWNLOAD_HEADERS;
		SaveHandler handler = new SaveHandler();
		_ConfigRoot = handler.ReadSave (PathBuilder.GetLoadOrderFile ());
		SaveHandler Handler = new SaveHandler();
		_LoadOrder = LoadOrderData.SaveNodeToLoadOrderData (Handler.ReadSave (PathBuilder.GetLoadOrderFile ()));
		//_TotalBundleNumber = _TotalBundleNumber;
		//Handler.ReadFile (PathBuilder.GetLoadOrderFile ());
			//_ConfigRoot);
		CheckLoadConfig ();
	}


}
