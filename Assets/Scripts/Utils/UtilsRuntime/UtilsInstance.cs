using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoonSharp.Interpreter;


	public partial class UtilsInstance  : MonoBehaviour
	{
		public static UtilsInstance	Instance { get; private set; }

		void Awake() 
		{

			if (Instance != null && Instance != this) {
				Destroy (gameObject);
			}
			Instance = this;
			DontDestroyOnLoad (transform.gameObject);
		}






	}

