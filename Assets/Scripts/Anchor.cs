using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {



	public static Anchor Instance { get; private set; }

	void Awake() {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (transform.gameObject);

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetPosition()
    {

       return FindObjectOfType<ScriptedInstance>().transform.position;
    }
}
