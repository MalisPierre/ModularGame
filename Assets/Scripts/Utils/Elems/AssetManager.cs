using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

#if UNITY_EDITOR


using UnityEditor;

#endif

public class AssetManager : MonoBehaviour {

    public static AssetManager Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    public Element FindElementWithTag(string Tag, string Name)
    {
        //EngineInstance[] Engines = FindObjectsOfType<EngineInstance> ();
        //Element[] ElemObjs = FindObjectsOfType<Element> ();
        GameObject[] Objs = GameObject.FindGameObjectsWithTag(Tag);
        List<GameObject> MyList = new List<GameObject>(Objs);
        GameObject elem = MyList.Find(x => x.gameObject.name == Name);
        if (elem == null)
            Debug.LogError("Error! Element Not Found");
        return elem.GetComponent<Element>();

    }

    public Element FindElementByName(string Name)
    {
        Element[] ElemObjs = FindObjectsOfType<Element>();
        List<Element> MyList = new List<Element>(ElemObjs);
        Element elem = MyList.Find(x => x.gameObject.name == Name);
        if (elem == null)
            Debug.LogError("Error! Element [" + Name + "]Not Found");
        return elem;

    }

    public SaveNode GetSaveNodeData(string AssetPath)
    {
        return EngineInstance.Instance._ContentLoader.GetSaveNodeData(AssetPath);
    }

    public Texture2D GetTexure(string AssetPath)
    {
        return EngineInstance.Instance._ContentLoader.GetTexture(AssetPath);
    }

    public Sprite GetSprite(string AssetPath)
    {
        return EngineInstance.Instance._ContentLoader.GetSprite(AssetPath);
    }

    public Font GetFont(string AssetPath)
    {
        return EngineInstance.Instance._ContentLoader.GetFont(AssetPath);
    }

    public RuntimeAnimatorController GetAnimationController(string AssetPath)
    {
        return EngineInstance.Instance._ContentLoader.GetController(AssetPath);
    }

    public AnimationClip GetAnimation(string AssetPath)
    {
        AnimationClip Instance = null;
        string FullPath;
        if (EngineInstance.Instance._ContentLoader._ModularContent == true)
        {
            return null;
            //return EngineInstance.Instance._ContentLoader.FindCurrentContent (PathBuilder.GetContentFromPath (AssetPath)).GetImageContainer (AssetPath).GetComponent<ImageContainer>()._Image;
        }
        else
        {
            FullPath = PathBuilder.GetAnimationData(AssetPath);
            Instance = (AnimationClip)Resources.Load(FullPath, typeof(AnimationClip)) as AnimationClip;
        }
        if (Instance == null)
            Debug.LogError("Error loading animation : [" + FullPath + "]");
        return Instance;
    }

    public Element LoadElement(string Name, Vector3 NewPos)
    {
        GameObject Prefab = EngineInstance.Instance._ContentLoader.GetElement(Name);


        if (Prefab == null)
            Debug.LogError("Element [" + PathBuilder.GetSceneFile(Name) + "] not Found !");


        GameObject Instance = Instantiate(
            Prefab,
            NewPos,
            Quaternion.identity) as GameObject;

        Instance.transform.name = Name;
        if (Instance.GetComponent<Element>()._ScriptInstance._FileName != "")
            Instance.GetComponent<Element>().Init();
        return Instance.GetComponent<Element>();
    }

    public Material CreateMaterial(string ShaderName)
    {
        return new Material(Shader.Find(ShaderName));
    }


    public Material SetMaterialTexture(Material Mat, Texture2D Text)
    {
        Mat.mainTexture = Text;
        return Mat;
    }



#if UNITY_EDITOR

    public void SaveMaterial(Material material, string AssetPath)
    {
        
        string FolderPath = System.IO.Path.GetDirectoryName("Assets/Contents/" + AssetPath);
        if (!System.IO.Directory.Exists(FolderPath))
        {
            Debug.LogWarning("Creating Folder ==> [" + FolderPath + "]");
            System.IO.Directory.CreateDirectory(FolderPath);
        }
        else
            Debug.Log("Creating Asset ==> [" + "Assets/Contents/" + AssetPath + "]");
        AssetDatabase.CreateAsset(material, "Assets/Contents/" + AssetPath + ".mat");
    }

	public SaveHolder GetSaveHolder(string Name)
	{
		GameObject Prefab = ContentLoader.GetElementInEditor(Name);
		GameObject Instance = (GameObject)PrefabUtility.InstantiatePrefab(Prefab);
		Instance.transform.position = Vector3.zero;

		return Instance.GetComponent<SaveHolder>();
	}
    
	public void SelectElement(Element NewObject)
	{
		Debug.Log ("Before Call");
		Selection.activeGameObject = NewObject.gameObject;
		Debug.Log ("After Call");
	}

    
	public static GameObject GetElementInEditor(string BasePath)
	{
		return ContentLoader.GetElementInEditor(BasePath);
	}

    public static Texture2D GetTextureInEditor(string BasePath)
	{
		return ContentLoader.GetTextureInEditor(BasePath);
	}


	public static string GetScriptInEditor(string BasePath)
	{
		return ContentLoader.GetScriptInEditor(BasePath);
	}


#endif

}
