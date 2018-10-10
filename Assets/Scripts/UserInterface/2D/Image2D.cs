using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image2D : Item2D {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetImage(Sprite NewSprite)
	{
		this.GetComponent<Image> ().sprite = NewSprite;
	}

	public void SetTexture(Texture2D NewTexture)
	{
		Sprite OldSprite = this.GetComponent<Image> ().sprite;
		Sprite NewSprite = Sprite.Create(NewTexture, new Rect(0.0f, 0.0f, NewTexture.width, NewTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
		//this.GetComponent<Animator> ().runtimeAnimatorController = null;
		this.GetComponent<Image> ().sprite = NewSprite;
	}

	public void SetColor(Color NewColor)
	{
		this.GetComponent<Image> ().color = NewColor;
	}

	public void SetAnimation(RuntimeAnimatorController Controller)
	{
		Debug.Log ("-->" + Controller.name);
		this.GetComponent<Image> ().sprite = null;
		this.GetComponent<Animator> ().runtimeAnimatorController = Controller;
	}

}
