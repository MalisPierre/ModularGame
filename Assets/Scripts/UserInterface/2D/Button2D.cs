using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonSharp.Interpreter;
using UnityEngine.EventSystems;

public class Button2D : Item2D, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {

	public Color 					_DefaultColor = new Color(0.862f, 0.862f, 0.862f, 1.0f);
	public Color 					_HoverColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public Color 					_ClickedColor = new Color(0.7f, 0.7f, 0.7f, 1.0f);

	public Sprite 					_DefaultSprite;
	public Sprite 					_HoverSprite;
	public Sprite 					_ClickedSprite;

	private bool 					_IsHover = false;
	private bool 					_IsClicked = false;


	public ScriptedInstance			_Instance;

	void Start () {
		SetDefaultSkin ();
		_Instance.Init();
	}

	void Update () {
		
	}

	public void OnClick()
	{
		_Instance.CallNoParams ("OnClick");
	}

	public void SetDefaultSkin()
	{
		this.GetComponent<Image> ().color = _DefaultColor;
		this.GetComponent<Image> ().sprite = _DefaultSprite;
		this.GetComponent<RectTransform>().localScale = new Vector3 (1, 1, 1);
	}

	public void SetHoverSkin()
	{
		this.GetComponent<Image> ().color = _HoverColor;
		this.GetComponent<Image> ().sprite = _HoverSprite;
		this.GetComponent<RectTransform>().localScale = new Vector3 (1, 1, 1);
	}

	public void SetClickedSkin()
	{
		this.GetComponent<Image> ().color = _ClickedColor;
		this.GetComponent<Image> ().sprite = _ClickedSprite;
		this.GetComponent<RectTransform>().localScale = new Vector3 (0.9f, 0.9f, 0.9f);
	}

	public void SetColor(Color NewColor)
	{
		this.GetComponent<Image> ().color = NewColor;

	}

	public void SetScale(Vector3 NewScale)
	{
		this.GetComponent<RectTransform>().localScale = NewScale;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.GetComponent<Button> ().interactable == true)
		{
			_IsHover = true;
			SetHoverSkin ();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.GetComponent<Button> ().interactable == true)
		{
			_IsHover = false;
			if (_IsClicked == false) {
				SetDefaultSkin ();
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.GetComponent<Button> ().interactable == true)
		{
			_IsClicked = true;
			SetClickedSkin ();
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.GetComponent<Button> ().interactable == true)
		{
			_IsClicked = false;
			if (_IsHover == true) {
				SetHoverSkin ();
			} else {
				SetDefaultSkin ();
			}
		}
	}

	public Text2D FindText(string TextId)
	{
		return this.transform.Find (TextId).GetComponent<Text2D>();
	}

	public void Activate()
	{
		this.GetComponent<Button> ().interactable = true;
	}

	public void Desactivate()
	{
		this.GetComponent<Button> ().interactable = false;
	}

	public void Initialize ()
	{
		if (_Instance._FileName != "")
			_Instance.Init ();
	}

    public void InitScript(string ScriptId)
    {
        _Instance._FileName = ScriptId;
        Initialize();
    }

    public DynValue Call(string FuncName, DynValue []Params)
	{
		return this._Instance.Call (FuncName, Params);
	} 

}
