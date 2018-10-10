using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public partial class SplashScreen {


	//https://soleilrouge.herokuapp.com/Games/DownloadLoadOrderGet/?name=platform_solver&version=1.0.A

	IEnumerator DownloadLoadOrder() {
		

		string url = "https://soleilrouge.herokuapp.com/Games/DownloadLoadOrderGet/?name=" + EngineInstance.Instance.GetConfigName() + "&version=" + EngineInstance.Instance.GetConfigVersion();

		Debug.Log ("Url = [" + url + "]");
		//Request.redirectLimit = 1;
		_Request = UnityWebRequest.Get (url);
		yield return _Request.SendWebRequest ();
		//yield return _Request.Send();

		//_AssetStatus = new WWW (url);
		//yield return _AssetStatus;
		if (_Request.isNetworkError || _Request.isHttpError)
		{
			Debug.LogWarning("Erreur: Impossible de télécharger la Config");
			ShowDownloadErrorPanel ();
		}
		else
		{
			Directory.CreateDirectory (PathBuilder.GetConfigFolder ());
			Debug.Log ("Writing Config [" + PathBuilder.GetLoadOrderFile () + "]");
			System.IO.File.WriteAllBytes(PathBuilder.GetLoadOrderFile (), _Request.downloadHandler.data);
			yield return new WaitForSeconds (1.0f);
			HideDownloadConfig ();
			StartCheckLoadConfig();
		}
	}

	public void TryToDownloadLoadOrder()
	{
		this._Status = SplashScreenStatus.DOWNLOAD_CONFIG;
		if (_AllowDownload == true) {
			DisplayDownloadConfig ();
			StartCoroutine (DownloadLoadOrder ());

		} else {
			DisplayAllowDownload ();
		}
	}

	public void RefreshDownloadConfigProgressBar(float percent_value)
	{
		this._DownloadConfigProgressText.text = percent_value + " %";
		this._DownloadConfigProgressImage.SetPosition (new Vector3 (0.0f, 0.02f, 0.0f), new Vector3 (percent_value / 100, 0.98f, 0.0f));
	}



}
