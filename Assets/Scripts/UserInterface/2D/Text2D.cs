using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text2D : Item2D
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
	public void SetText(string NewText)
	{
		this.GetComponent<Text> ().text = NewText;
	}

	public void SetColor(Color NewColor)
	{
		this.GetComponent<Text> ().color = NewColor;
	}

	public string GetText()
	{
		return this.GetComponent<Text> ().text;
	}

	public void SetFontSize(int NewSize)
	{
		this.GetComponent<Text> ().fontSize = NewSize;
	}

	public void SetFontType(Font NewFont)
	{
		this.GetComponent<Text> ().font = NewFont;
	}
}
