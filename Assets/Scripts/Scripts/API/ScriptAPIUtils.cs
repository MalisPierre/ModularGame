using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public partial class ScriptAPI : MonoBehaviour {

    public static UtilsInstance GetUtils()
    {
        return UtilsInstance.Instance;
    }

    public static AssetManager GetAssetManager()
    {
        return AssetManager.Instance;
    }

    public static Call GetCall()
    {
        return Call.Instance;
    }

    public static RandomGenerator GetRandomGenerator()
    {
        return RandomGenerator.Instance;
    }

    public static Raycast GetRaycast()
    {
        return Raycast.Instance;
    }

    public static Scene GetScene()
    {
        return Scene.Instance;
    }
    

}
