using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Element : MonoBehaviour {

	public int GetElementCount()
	{
		return this.transform.childCount;
	}

	public Element GetElement(int Idx)
	{
		return this.transform.GetChild (Idx).GetComponent<Element> ();
	}

	public Element FindElement(string Id)
	{
		return this.transform.Find (Id).GetComponent<Element> ();
	}
		

}
