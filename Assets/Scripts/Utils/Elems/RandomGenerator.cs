using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class RandomGenerator : MonoBehaviour {

    public static RandomGenerator Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }





    public int GetRandomInt(int Min, int Max)
    {
        return Random.Range(Min, Max);
    }

    public float GetRandomFloat(float Min, float Max)
    {
        return Random.Range(Min, Max);
    }
}
