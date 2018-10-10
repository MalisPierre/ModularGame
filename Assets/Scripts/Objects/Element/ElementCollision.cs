using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using UnityEngine.AI;

public partial class Element : MonoBehaviour {

	public bool	_OnTriggerEnter = false;

	public bool _OnTriggerExit = false;




	void OnTriggerEnter(Collider other) {
		if ((_OnTriggerEnter == true) && (other.gameObject.GetComponent<Element> () != null) && (this._ScriptInstance._Script != null))
		{
			_ScriptInstance._Script.Call (_ScriptInstance._Script.Globals ["OnTriggerEnter"], other.gameObject.GetComponent<Element> ());
		}
	}

	void OnTriggerExit(Collider other) {
		if ((_OnTriggerExit == true) && (other.gameObject.GetComponent<Element> () != null) && (this._ScriptInstance._Script != null))
		{
			_ScriptInstance._Script.Call (_ScriptInstance._Script.Globals ["OnTriggerExit"], other.gameObject.GetComponent<Element> ());
		}
	}


	public CapsuleCollider GetCapsuleCollider()
	{
		return this.GetComponent<CapsuleCollider> ();
	}

	public void SetCapsuleColliderTrigger()
	{
		this.GetComponent<CapsuleCollider> ().isTrigger = true;
	}

	public void SetCapsuleColliderCollision()
	{
		this.GetComponent<CapsuleCollider> ().isTrigger = false;
	}

	public void DeleteCapsuleCollider()
	{
		Destroy (this.GetComponent<CapsuleCollider> ());
	}

	public void SetCapsuleColliderCenter(Vector3 NewPos)
	{
		this.GetComponent<CapsuleCollider> ().center = NewPos;
	}

	public void SetCapsuleColliderRadius(float NewValue)
	{
		this.GetComponent<CapsuleCollider> ().radius = NewValue;
	}




}
