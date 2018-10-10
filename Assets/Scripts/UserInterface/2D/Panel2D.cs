using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using UnityEngine.UI;

public class Panel2D : Item2D
{

	public ScriptedInstance			_ScriptInstance;

	public List<Image2D>	_Images;

	public List<Text2D>		_Texts;

	public List<Button2D>	_Buttons;

	public List<Slider2D>	_Sliders;

	public List<Input2D>	_Inputs;

	public List<Joystick2D>	_Joysticks;

	public List<Panel2D>	_Panels;

	void Update () {
		if ((_ScriptInstance != null) && (_ScriptInstance._CallUpdate == true))
		{
			this._ScriptInstance.CallNoParams ("Update");
		}
	}

    public void SetImage(Sprite NewSprite)
    {
        this.GetComponent<Image>().sprite = NewSprite;
    }



    public Text2D CreateText(string Id, string Name)
    {
        GameObject Prefab = EngineInstance.Instance._ContentLoader.GetPanel(Id);

        if (Prefab == null)
            Debug.LogError("UI Panel [" + "UI/2D/Panels/" + PathBuilder.GetFileFromPath(Id) + "] not Found !");

        GameObject Instance = Instantiate(
            Prefab,
            new Vector3(0, 0, 0),
            Quaternion.identity) as GameObject;

        Instance.transform.name = Name;
        Instance.transform.SetParent(this.gameObject.transform, false);

        _Texts.Add(Instance.GetComponent<Text2D>());
        return Instance.GetComponent<Text2D>();
    }

    public Text2D FindText(string Id)
    {
        return _Texts.Find(x => x.gameObject.name == Id);
    }

    public Text2D GetText(int Idx)
    {
        return _Texts[Idx];
    }

    public int GetTextCount()
    {
        return _Texts.Count;
    }

    public void DeleteAllTexts()
    {
        while (_Texts.Count > 0)
        {
            DeleteTextByIndex(0);
        }
    }

    public void DeleteTextById(string Id)
    {
        Text2D Panel = _Texts.Find(x => x.gameObject.name == Id);
        Panel.Delete();
        _Texts.Remove(Panel);
    }

    public void DeleteTextByIndex(int Idx)
    {
        Text2D TextObj = _Texts[Idx];
        TextObj.Delete();
        _Texts.Remove(TextObj);
    }




    public Button2D CreateButton(string Id, string Name)
    {
        GameObject Prefab = EngineInstance.Instance._ContentLoader.GetPanel(Id);

        if (Prefab == null)
            Debug.LogError("UI Panel [" + "UI/2D/Panels/" + PathBuilder.GetFileFromPath(Id) + "] not Found !");

        GameObject Instance = Instantiate(
            Prefab,
            new Vector3(0, 0, 0),
            Quaternion.identity) as GameObject;

        Instance.transform.name = Name;
        Instance.transform.SetParent(this.gameObject.transform, false);

        _Buttons.Add(Instance.GetComponent<Button2D>());
        return Instance.GetComponent<Button2D>();
    }

    public Button2D FindButton(string Id)
    {
        return _Buttons.Find (x => x.gameObject.name == Id);
    }

    public Button2D GetButton(int Idx)
    {
        return _Buttons[Idx];
    }

    public int GetButtonCount()
    {
        return _Buttons.Count;
    }

    public void DeleteAllButtons()
    {
        while (_Buttons.Count > 0)
        {
            DeleteButtonByIndex(0);
        }
    }

    public void DeleteButtonById(string Id)
    {
        Button2D Panel = _Buttons.Find(x => x.gameObject.name == Id);
        Panel.Delete();
        _Buttons.Remove(Panel);
    }

    public void DeleteButtonByIndex(int Idx)
    {
        Button2D ButtonObj = _Buttons[Idx];
        ButtonObj.Delete();
        _Buttons.Remove(ButtonObj);
    }




    public Slider2D CreateSlider(string Id, string Name)
    {
        GameObject Prefab = EngineInstance.Instance._ContentLoader.GetPanel(Id);

        if (Prefab == null)
            Debug.LogError("UI Panel [" + "UI/2D/Panels/" + PathBuilder.GetFileFromPath(Id) + "] not Found !");

        GameObject Instance = Instantiate(
            Prefab,
            new Vector3(0, 0, 0),
            Quaternion.identity) as GameObject;

        Instance.transform.name = Name;
        Instance.transform.SetParent(this.gameObject.transform, false);

        _Sliders.Add(Instance.GetComponent<Slider2D>());
        return Instance.GetComponent<Slider2D>();
    }

    public Slider2D FindSlider(string Id)
    {
        return _Sliders.Find(x => x.gameObject.name == Id);
    }

    public Slider2D GetSlider(int Idx)
    {
        return _Sliders[Idx];
    }

    public int GetSliderCount()
    {
        return _Sliders.Count;
    }

    public void DeleteAllSliders()
    {
        while (_Sliders.Count > 0)
        {
            DeleteSliderByIndex(0);
        }
    }

    public void DeleteSliderById(string Id)
    {
        Slider2D Panel = _Sliders.Find(x => x.gameObject.name == Id);
        Panel.Delete();
        _Sliders.Remove(Panel);
    }

    public void DeleteSliderByIndex(int Idx)
    {
        Slider2D SliderObj = _Sliders[Idx];
        SliderObj.Delete();
        _Sliders.Remove(SliderObj);
    }





    public Image2D CreateImage(string Id, string Name)
    {
        GameObject Prefab = EngineInstance.Instance._ContentLoader.GetPanel(Id);

        if (Prefab == null)
            Debug.LogError("UI Panel [" + "UI/2D/Panels/" + PathBuilder.GetFileFromPath(Id) + "] not Found !");

        GameObject Instance = Instantiate(
            Prefab,
            new Vector3(0, 0, 0),
            Quaternion.identity) as GameObject;

        Instance.transform.name = Name;
        Instance.transform.SetParent(this.gameObject.transform, false);

        _Images.Add(Instance.GetComponent<Image2D>());
        return Instance.GetComponent<Image2D>();
    }

    public Image2D FindImage(string Id)
    {
        return _Images.Find(x => x.gameObject.name == Id);
    }

    public Image2D GetImage(int Idx)
    {
        return _Images[Idx];
    }

    public int GetImageCount()
    {
        return _Images.Count;
    }

    public void DeleteAllImages()
    {
        while (_Images.Count > 0)
        {
            DeleteImageByIndex(0);
        }
    }

    public void DeleteImageBId(string Id)
    {
        Image2D Panel = _Images.Find(x => x.gameObject.name == Id);
        Panel.Delete();
        _Images.Remove(Panel);
    }

    public void DeleteImageByIndex(int Idx)
    {
        Image2D ImageObj = _Images[Idx];
        ImageObj.Delete();
        _Images.Remove(ImageObj);
    }



    public Input2D FindInput(string Id)
	{
		return _Inputs.Find (x => x.gameObject.name == Id);
	}

	public Joystick2D FindJoystick(string Id)
	{
		return _Joysticks.Find (x => x.gameObject.name == Id);
	}

	public Panel2D FindPanel(string Id)
	{
		return _Panels.Find (x => x.gameObject.name == Id);
	}

	public DynValue Call(string FuncName, DynValue []Params)
	{
		return this._ScriptInstance.Call (FuncName, Params);
	}

	public void Initialize()
	{
		if (_ScriptInstance._FileName != "")
			_ScriptInstance.Init ();

		for (int i = 0; i < _Panels.Count; i = i + 1) {
			_Panels [i].Initialize ();
		}

		for (int i = 0; i < _Sliders.Count; i = i + 1) {
			_Sliders [i].Initialize ();
		}

		for (int i = 0; i < _Buttons.Count; i = i + 1) {
			_Buttons [i].Initialize ();
		}

		for (int i = 0; i < _Inputs.Count; i = i + 1) {
			_Inputs [i].Initialize ();
		}

		for (int i = 0; i < _Joysticks.Count; i = i + 1) {
			_Joysticks [i].Initialize ();
		}

	}

	public void TestScriptPath(string NewPath)
	{
		string OldPath = _ScriptInstance._FileName;
		string[] Splitter = OldPath.Split (':');
		string FinalPath = NewPath + ":" + Splitter [2];
		Debug.Log ("OldPath = [" + OldPath + "]");
		Debug.Log ("NewPath = [" + FinalPath + "]");
	}

	public void RefreshScriptPath(string NewPath)
	{
		this._ScriptInstance._FileName = GetNewScriptPath (this._ScriptInstance._FileName, NewPath);

		for (int i = 0; i < _Panels.Count; i = i + 1) {
			_Panels [i].RefreshScriptPath (NewPath);
		}

		for (int i = 0; i < _Sliders.Count; i = i + 1) {
			_Sliders [i]._ScriptInstance._FileName = this._ScriptInstance._FileName = GetNewScriptPath (_Sliders [i]._ScriptInstance._FileName, NewPath);
		}

		for (int i = 0; i < _Buttons.Count; i = i + 1) {
			_Buttons [i]._Instance._FileName = GetNewScriptPath (_Buttons [i]._Instance._FileName, NewPath);
		}

		for (int i = 0; i < _Inputs.Count; i = i + 1) {
			_Inputs [i]._Instance._FileName = GetNewScriptPath (_Inputs [i]._Instance._FileName, NewPath);
		}
	}

	private string GetNewScriptPath(string OldPath, string NewPath)
	{
		if (OldPath != "")
		{
			string[] Splitter = OldPath.Split (':');
			return NewPath + ":" + Splitter [2];
		} 
		else 
		{
			return OldPath;
		}
	}


}
