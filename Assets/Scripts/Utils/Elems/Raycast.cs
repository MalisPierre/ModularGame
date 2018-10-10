using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class Raycast : MonoBehaviour {

    public static Raycast Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }


    public static Vector3 RaycastPosition(Vector3 StartPos, Vector3 EndPos, string[] MaskToTrigger, bool DrawDebug)
    {
        return Vector3.zero;// Raycast.Instance.RaycastPosition(StartPos, EndPos, MaskToTrigger, DrawDebug);
    }
}
