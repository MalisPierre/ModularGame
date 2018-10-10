using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public partial class SplashScreen {

	IEnumerator DownloadBundle(string ContentName, BundleData CurrentBundle) {
		Debug.Log ("Downloading Bundle " + CurrentBundle._Name);
		string url = "https://soleilrouge.herokuapp.com/Games/DownloadBundleGet/?platform=" + 
			EngineInstance.GetPlatformName() + "&name=" + CurrentBundle._Url + "&version=" + CurrentBundle._Version;
		Debug.Log ("Url = [" + url + "]");
		//Request.redirectLimit = 1;
		_Request = UnityWebRequest.Get (url);

		yield return _Request.SendWebRequest();

		//_AssetStatus = new WWW (url);
		//yield return _AssetStatus;
		if (_Request.isNetworkError || _Request.isHttpError)
		{
			Debug.LogWarning("Erreur: Impossible de télécharger le Bundle");
			ShowDownloadErrorPanel ();
		}
		else
		{
			Directory.CreateDirectory (PathBuilder.GetContentFolder (ContentName));
			Debug.Log ("Writing Bundle [" + PathBuilder.GetBundleFile (ContentName, CurrentBundle._Name) + "]");
			System.IO.File.WriteAllBytes(PathBuilder.GetBundleFile (ContentName, CurrentBundle._Name), _Request.downloadHandler.data);
			yield return 1;
			HideDownloadBundle ();
			CheckLoadBundles();
		}
	}


	public void TryToDownloadBundle(string ContentName, BundleData CurrentBundle)
	{
		if (_AllowDownload == true) {
			DisplayDownloadBundle (ContentName, CurrentBundle._Name);
			StartCoroutine (DownloadBundle (ContentName, CurrentBundle));

		} else {
			DisplayAllowDownload ();
		}
	}

	public void RefreshDownloadBundleProgressBar(float percent_value)
	{
		this._DownloadBundleProgressText.text = percent_value + " %";
		this._DownloadBundleProgressImage.SetPosition (new Vector3 (0.0f, 0.02f, 0.0f), new Vector3 (percent_value / 100, 0.98f, 0.0f));
	}


}
