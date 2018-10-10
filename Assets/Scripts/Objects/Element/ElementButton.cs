using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ElementButton : Element, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler  {

	public Color 					_DefaultColor = new Color(0.862f, 0.862f, 0.862f, 1.0f);
	public Color 					_HoverColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public Color 					_ClickedColor = new Color(0.7f, 0.7f, 0.7f, 1.0f);

	public Sprite 					_DefaultSprite;
	public Sprite 					_HoverSprite;
	public Sprite 					_ClickedSprite;

	private bool 					_IsHover = false;
	private bool 					_IsClicked = false;



	public void SetDefaultSkin()
	{
		Debug.Log ("DEFAULT SKIN");
		this.GetComponent<Image> ().color = _DefaultColor;
		this.GetComponent<Image> ().sprite = _DefaultSprite;

	}

	public void SetHoverSkin()
	{
		Debug.Log ("HOVER SKIN");
		this.GetComponent<Image> ().color = _HoverColor;
		this.GetComponent<Image> ().sprite = _HoverSprite;

	}

	public void SetClickedSkin()
	{
		Debug.Log ("CLICKED SKIN");
		this.GetComponent<Image> ().color = _ClickedColor;
		this.GetComponent<Image> ().sprite = _ClickedSprite;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{

		_IsHover = true;
		SetHoverSkin ();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_IsHover = false;
		if (_IsClicked == false) {
			SetDefaultSkin ();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_IsClicked = true;
		SetClickedSkin ();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_IsClicked = false;
		if (_IsHover == true) {
			SetHoverSkin ();
		} else {
			SetDefaultSkin ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		_ScriptInstance.CallNoParams ("OnClick");
	}

	public void SetText(string NewText)
	{
		this.GetComponentInChildren<Text> ().text = NewText;
	}

	public void Activate()
	{
		this.GetComponent<Button> ().interactable = true;
	}

	public void Desactivate()
	{
		this.GetComponent<Button> ().interactable = false;
	}


}
