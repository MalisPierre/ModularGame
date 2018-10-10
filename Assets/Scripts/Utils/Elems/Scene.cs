using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    public static Scene Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }





    public void LoadSceneAdditive(string Name)
    {
        string[] Sep = Name.Split(':');
        string ContentPath = Sep[0];
        string BundlePath = Sep[1];
        string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep[2];

        SceneManager.LoadScene(FilePath, LoadSceneMode.Additive);
    }

    public void SetActiveScene(string Name)
    {
        string[] Sep = Name.Split(':');
        string ContentPath = Sep[0];
        string BundlePath = Sep[1];
        string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep[2] + ".unity";
        Debug.Log("Set Active Scene On " + FilePath);
        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(FilePath));
    }

    public void UnloadSceneAsync(string Name, string FuncPostProcess)
    {
        StartCoroutine(AsyncUnloadSceneAdditiveAsync(Name, FuncPostProcess));
    }

    public void LoadSceneAdditiveAsync(string Name, string FuncPostProcess)
    {
        StartCoroutine(AsyncLoadSceneAdditiveAsync(Name, FuncPostProcess));
    }

    private IEnumerator AsyncLoadSceneAdditiveAsync(string Name, string FuncPostProcess)
    {
        string[] Sep = Name.Split(':');
        string ContentPath = Sep[0];
        string BundlePath = Sep[1];
        string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep[2];

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(FilePath, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("Calling Function " + FuncPostProcess);
        EngineInstance.Instance._ScriptInstance.CallNoParams(FuncPostProcess);
    }



    private IEnumerator AsyncUnloadSceneAdditiveAsync(string Name, string FuncPostProcess)
    {
        string[] Sep = Name.Split(':');
        string ContentPath = Sep[0];
        string BundlePath = Sep[1];
        string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep[2];

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(FilePath);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log("Calling Function " + FuncPostProcess);
        EngineInstance.Instance._ScriptInstance.CallNoParams(FuncPostProcess);
    }
}
