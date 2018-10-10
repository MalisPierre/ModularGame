using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class Call : MonoBehaviour {

    public static Call Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }


    public void WaitForCallElement(float TimeToWait, string FuncName, Element Obj, DynValue[] Params)
    {
        StartCoroutine(WaitForCallElementCoroute(TimeToWait, FuncName, Obj, Params));
    }

    public IEnumerator WaitForCallElementCoroute(float TimeToWait, string FuncName, Element Obj, DynValue[] Params)
    {
        yield return new WaitForSeconds(TimeToWait);
        Obj._ScriptInstance.Call(FuncName, Params);
    }

    public void WaitForCallButton2D(float TimeToWait, string FuncName, Button2D Obj, DynValue[] Params)
    {
        StartCoroutine(WaitForCallButton2DCoroute(TimeToWait, FuncName, Obj, Params));
    }

    public IEnumerator WaitForCallButton2DCoroute(float TimeToWait, string FuncName, Button2D Obj, DynValue[] Params)
    {
        yield return new WaitForSeconds(TimeToWait);
        Obj._Instance.Call(FuncName, Params);
    }

    public DynValue CallButton2D(string FuncName, Button2D Obj, DynValue[] Params)
    {
        return Obj._Instance.Call(FuncName, Params);
    }

    public DynValue CallElement(string FuncName, Element Obj, DynValue[] Params)
    {
        return Obj._ScriptInstance.Call(FuncName, Params);
    }



    public void WaitForCallEngine(float TimeToWait, string FuncName, DynValue[] Params)
    {
        Debug.Log("WAIT FOR CALL ENGINE 1 [" + FuncName + "]");
        StartCoroutine(WaitForCallEngineCoroute(TimeToWait, FuncName, Params));
    }

    public IEnumerator WaitForCallEngineCoroute(float TimeToWait, string FuncName, DynValue[] Params)
    {
        Debug.Log("WAIT FOR CALL ENGINE 2 [" + FuncName + "]");
        yield return new WaitForSeconds(TimeToWait);
        Debug.Log("WAIT FOR CALL ENGINE 3 [" + FuncName + "]");
        EngineInstance.Instance._ScriptInstance.Call(FuncName, Params);
    }

    public DynValue CallEngine(string FuncName, DynValue[] Params)
    {
        return EngineInstance.Instance._ScriptInstance.Call(FuncName, Params);
    }
}
