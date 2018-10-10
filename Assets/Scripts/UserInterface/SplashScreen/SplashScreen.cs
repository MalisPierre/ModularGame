using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;


public enum SplashScreenStatus {
	NOT_STARTED = 0,
	DOWNLOAD_CONFIG = 1,
	DOWNLOAD_HEADERS = 2,
	DOWNLOAD_BUNDLES = 3,
	LOAD_CONTENT = 4,
	FINISHED = 5
}

public partial class SplashScreen : MonoBehaviour {


	public SplashScreenStatus					_Status;
	public bool									_AllowDownload = false;

	public GameObject 							_DownloadBundlePanel;
	public UnityEngine.UI.Text 					_DownloadBundleText;
	public UnityEngine.UI.Text					_DownloadBundleProgressText;
	public Image2D 								_DownloadBundleProgressImage;

	public GameObject 							_DownloadHeaderPanel;
	public Text 								_DownloadHeaderText;
	public Text									_DownloadHeaderValue;
	public UnityEngine.UI.Text					_DownloadHeaderProgressText;
	public Image2D 								_DownloadHeaderProgressImage;

	public AudioSource							_SplashScreenAudio;

	public GameObject 							_DownloadConfigPanel;
	public UnityEngine.UI.Text					_DownloadConfigProgressText;
	public Image2D 								_DownloadConfigProgressImage;

	public GameObject 							_AllowDownloadPanel;
	public GameObject 							_SplashPanel;

	public GameObject 							_DownloadErrorPanel;



	public GameObject 							_LoadingPanel;
	public UnityEngine.UI.Image 				_LoadingBackground;
	public UnityEngine.UI.Image 				_LoadingLogo;
	public UnityEngine.UI.Text					_LoadingInfosText;
	public UnityEngine.UI.Text					_LoadingText;
	public Image2D 								_LoadingProgressImage;

	public LoadOrderData 						_LoadOrder;
	public List<ContentData>					_ContentDataList;
	public int 									_TotalBundleNumber;
	public int									_TotalBundleLoaded;
	public int 									_CurrentContentIdx;
	public int									_CurrentBundleIdx;
	public SaveNode								_ConfigRoot;
	public UnityWebRequest						_Request;
	public bool 								_Continue = true;

	public float								_WaitTimer = 1.25f;
	public string 								_LoadOrderPath = "Config/LoadOrder";

	public static SplashScreen					Instance { get; private set; }

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {

		this._SplashPanel.SetActive (true);
		this._DownloadConfigPanel.SetActive (false);
		this._DownloadBundlePanel.SetActive (false);
		this._DownloadHeaderPanel.SetActive (false);
		this._AllowDownloadPanel.SetActive (false);
		this._LoadingPanel.SetActive (false);
		this._DownloadErrorPanel.SetActive (false);

		this._Status = SplashScreenStatus.NOT_STARTED;
		string ConfigFilePath;
		ConfigFilePath = PathBuilder.GetLoadOrderFile ();

		if (!File.Exists (ConfigFilePath)) {
			TryToDownloadLoadOrder ();
		}
		else
		{
			StartCheckLoadConfig();
		}



	}


	
	// Update is called once per frame
	void Update () {
		if ((this._Status == SplashScreenStatus.DOWNLOAD_BUNDLES) && (this._DownloadBundlePanel.activeSelf == true)) 
		{
			float percent_value = Mathf.Round(this._Request.downloadProgress * 100.0f);
			//this._DownloadBundleValue.text = percent_value  + " %";
			RefreshDownloadBundleProgressBar(percent_value);
		}
		else if ((this._Status == SplashScreenStatus.DOWNLOAD_HEADERS) && (this._DownloadBundlePanel.activeSelf == true)) 
		{
			float percent_value = Mathf.Round(this._Request.downloadProgress * 100.0f);
			//this._DownloadHeaderValue.text = Mathf.Round(this._Request.downloadProgress * 100.0f)  + " %";
			RefreshDownloadHeaderProgressBar(percent_value);
		}
		else if ((this._Status == SplashScreenStatus.DOWNLOAD_CONFIG) && (this._DownloadConfigPanel.activeSelf == true)) 
		{
			float percent_value = Mathf.Round(this._Request.downloadProgress * 100.0f);
			//this._DownloadHeaderValue.text = Mathf.Round(this._Request.downloadProgress * 100.0f)  + " %";
			RefreshDownloadConfigProgressBar(percent_value);
		}
		else if ((this._Status == SplashScreenStatus.FINISHED) && (_Continue == true)) 
		{
			_Continue = false;
			Debug.LogWarning ("CLOSING SPLASH SCREEN");
			for (int i = 0; i < EngineInstance.Instance._ContentLoader._Content.Count; i = i + 1) {
				for (int j = 0; j < EngineInstance.Instance._ContentLoader._Content[i]._Bundles.Count; j = j + 1)
					Debug.Log ("Content[" + EngineInstance.Instance._ContentLoader._Content[i]._name + "] => " + EngineInstance.Instance._ContentLoader._Content[i]._Bundles[j]._name);
			}
			Debug.Log ("---");
			Debug.Log ("---");
			EngineInstance.Instance.InitScriptEngine (
				_LoadOrder.GetEngine(), 
				_LoadOrder.GetCamera(), 
				_LoadOrder.GetUI());
			Destroy (this.gameObject);
		}
	}

	public void HideDownloadBundle()
	{
		this._DownloadBundlePanel.SetActive (false);
	}

	public void DisplayDownloadBundle(string ContentName, string BundleName)
	{
		this._DownloadBundleText.text = "Downloading Bundle [" + ContentName + "][" + BundleName + "]";
		this._DownloadBundlePanel.SetActive (true);
	}


	public void HideDownloadHeader()
	{
		this._DownloadHeaderPanel.SetActive (false);
	}

	public void DisplayDownloadHeader(string Name)
	{
		this._DownloadHeaderText.text = "Downloading Header [" + Name + "]";
		this._DownloadHeaderPanel.SetActive (true);
	}




	public void HideDownloadConfig()
	{
		this._DownloadConfigPanel.SetActive (false);
	}

	public void DisplayDownloadConfig()
	{
		this._DownloadConfigPanel.SetActive (true);
	}

	public void DisplayAllowDownload()
	{
		this._AllowDownloadPanel.SetActive (true);
	}

	public void AllowDownload()
	{
		this._AllowDownload = true;
		this._AllowDownloadPanel.SetActive (false);

		if (this._Status == SplashScreenStatus.DOWNLOAD_CONFIG) {
			TryToDownloadLoadOrder ();
		}
		if (this._Status == SplashScreenStatus.DOWNLOAD_HEADERS) {
			CheckLoadConfig ();
		}
		if (this._Status == SplashScreenStatus.DOWNLOAD_BUNDLES) {
			CheckLoadBundles ();
		}
	}

	public void NotAllowDownload()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_STANDALONE
			Application.Quit();
		#endif
	}

	public void ShowDownloadErrorPanel()
	{
		this._DownloadErrorPanel.SetActive (true);

	}

	public void ConfirmDownloadError()
	{
		this._DownloadErrorPanel.SetActive (false);
		if (this._Status == SplashScreenStatus.DOWNLOAD_CONFIG) {
			TryToDownloadLoadOrder ();
		}
		if (this._Status == SplashScreenStatus.DOWNLOAD_HEADERS) {
			CheckLoadConfig ();
		}
		if (this._Status == SplashScreenStatus.DOWNLOAD_BUNDLES) {
			CheckLoadBundles ();
		}
	}






}
