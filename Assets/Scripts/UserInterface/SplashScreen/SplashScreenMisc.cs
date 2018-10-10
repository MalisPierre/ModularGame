using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public partial class SplashScreen {

	public void StartLoadingContent2()
	{
		this._Status = SplashScreenStatus.LOAD_CONTENT;

		LoadBackground (_LoadOrder.GetLoadingBundle(), _LoadOrder.GetLoadingAsset());
		StartCoroutine (DisplayFlashScreen ());
	}


	public void LoadBackground(string AssetBundlePath, string AssetFilePath)
	{
		
		var bundleLoad = AssetBundle.LoadFromFile(PathBuilder.BuildPath(PathBuilder.GetDataFolder(), AssetBundlePath));

		RuntimeAnimatorController Instance = bundleLoad.LoadAsset<RuntimeAnimatorController> (AssetFilePath);
		bundleLoad.Unload (false);
		Debug.Log ("Animation = " + Instance.name);
		this._LoadingBackground.GetComponent<Animator> ().runtimeAnimatorController = Instance;

	}

	private IEnumerator DisplayFlashScreen()
	{
		_SplashPanel.SetActive (true);
		_SplashScreenAudio.Play ();
		_LoadingPanel.SetActive (false);
		//_Logo.GetComponent<Animation> ().Play();
		yield return new WaitForSeconds (_WaitTimer * 2);
		//StartLoading ();
		StartCoroutine(ProcessContent ());
	}

	private IEnumerator ProcessContent()
	{		
		_LoadingPanel.SetActive (true);
		_SplashPanel.SetActive (false);

		//_ContentIdx = 0;
		//_ContentsToLoad = new List<string> ();
		_CurrentContentIdx = 0;
		_CurrentBundleIdx = 0;
		_TotalBundleLoaded = 0;
		RefreshLoadingProgressBar ();
		yield return new WaitForSeconds (0.25f);

		LoadNextBundle ();

	}

	public void LoadNextBundle()
	{

		if (_CurrentContentIdx < _ContentDataList.Count) {
			// CONTINUE LOADING CONTENT

			if (_CurrentBundleIdx < _ContentDataList[_CurrentContentIdx].GetBundleCount()) 
			{
				// INSTANTIATE CONTENT IF NEEDS TO BEs
				if (_CurrentBundleIdx == 0)
					EngineInstance.Instance._ContentLoader.AddContent (_ContentDataList [_CurrentContentIdx]);
				// CONTINUE LOADING BUNDLE
				string BundleToLoad = _ContentDataList [_CurrentContentIdx].GetBundle(_CurrentBundleIdx)._Name;
				_LoadingInfosText.text = "Loading\n[" + _ContentDataList [_CurrentContentIdx] + "]\n[" + BundleToLoad + "]";
				EngineInstance.Instance._ContentLoader.AddBundleAsync (_ContentDataList [_CurrentContentIdx].GetName(), BundleToLoad);
				_CurrentBundleIdx = _CurrentBundleIdx + 1;
				RefreshBundleLoadedPercent ();
			}
			else
			{

				// NEXT CONTENT
				_CurrentContentIdx = _CurrentContentIdx + 1;
				_CurrentBundleIdx = 0;
				LoadNextBundle ();
			}
		} else {
			ClosePanel ();
		}
	}

	private void ClosePanel()
	{
		Debug.LogWarning ("CLOSE PANEL");
		this._Status = SplashScreenStatus.FINISHED;

	}

	public void RefreshBundleLoadedPercent()
	{
		_TotalBundleLoaded = _TotalBundleLoaded + 1;
		RefreshLoadingProgressBar ();

	}

	public void RefreshLoadingProgressBar()
	{
		//float RedValue = 1.0f - GetPercentage ();
		//float GreenValue = GetPercentage ();
		_LoadingText.text = (Mathf.Round(GetPercentage () * 100.0f)) + " %";
		_LoadingProgressImage.SetPosition (new Vector3 (0.0f, 0.5f, 0.0f), new Vector3 (GetPercentage (), 0.5f, 0.0f));
		//_LoadingProgressImage.SetColor(new Color(RedValue, GreenValue, 0.0f));
	}

	public float GetPercentage()
	{
		return (float)_TotalBundleLoaded / _TotalBundleNumber;
	}

}
