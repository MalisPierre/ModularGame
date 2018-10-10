using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public partial class SplashScreen {

	//https://soleilrouge.herokuapp.com/Games/DownloadHeaderGet/?name=common_assets&version=1.0.A

	IEnumerator DownloadHeader(HeaderData CurrentHeader) {
		Debug.Log ("Downloading Header " + CurrentHeader._Name);
		string url = "https://soleilrouge.herokuapp.com/Games/DownloadHeaderGet/?name=" + CurrentHeader._Name + "&version=" + CurrentHeader._Version;

		Debug.Log ("Url = [" + url + "]");
		//Request.redirectLimit = 1;
		_Request = UnityWebRequest.Get (url);

		yield return _Request.SendWebRequest();

		//_AssetStatus = new WWW (url);
		//yield return _AssetStatus;
		if (_Request.isNetworkError || _Request.isHttpError)
		{
			Debug.LogWarning("Erreur: Impossible de télécharger le Header");
			ShowDownloadErrorPanel ();
		}
		else
		{
			Directory.CreateDirectory (PathBuilder.GetDataFolder());
			Debug.Log ("Writing Header [" + PathBuilder.GetContentHeaderFile (CurrentHeader._Name) + "]");
			System.IO.File.WriteAllBytes(PathBuilder.GetContentHeaderFile (CurrentHeader._Name), _Request.downloadHandler.data);
			yield return 1;
			HideDownloadHeader ();
			CheckLoadConfig();
		}
	}

	public void TryToDownloadHeader(HeaderData CurrentHeader)
	{
		if (_AllowDownload == true) {
			DisplayDownloadHeader (CurrentHeader._Name);
			StartCoroutine (DownloadHeader (CurrentHeader));

		} else {
			DisplayAllowDownload ();
		}
	}

	public void RefreshDownloadHeaderProgressBar(float percent_value)
	{
		this._DownloadHeaderProgressText.text = percent_value + " %";
		this._DownloadHeaderProgressImage.SetPosition (new Vector3 (0.0f, 0.02f, 0.0f), new Vector3 (percent_value / 100, 0.98f, 0.0f));
	}


}
