using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class SaveNode
{
	[XmlAttribute("Key")]
	public string	_Key;

	[XmlArray("Floats"),XmlArrayItem("Float")]
	public List<SaveValueFloat>	_Floats = new List<SaveValueFloat> ();

	[XmlArray("Ints"),XmlArrayItem("Int")]
	public List<SaveValueInt>	_Ints = new List<SaveValueInt> ();

	[XmlArray("Strings"),XmlArrayItem("String")]
	public List<SaveValueString>	_Strings = new List<SaveValueString> ();

	[XmlArray("Bools"),XmlArrayItem("Bool")]
	public List<SaveValueBool>	_Bools = new List<SaveValueBool> ();

	[XmlArray("Nodes"),XmlArrayItem("Node")]
	public List<SaveNode>	_Nodes = new List<SaveNode> ();



	public SaveNode()
	{
		_Key = "";
	}

	public SaveNode(string NewKey)
	{
		_Key = NewKey;
	}

	public static SaveNode Create(string NewKey)
	{
		return new SaveNode (NewKey);
	}

	public SaveNode AddNode(string NodeKey, List<SaveValueFloat> Floats, List<SaveValueInt> Ints, List<SaveValueString> Strings, List<SaveNode> Nodes)
	{
		SaveNode NewNode = SaveNode.Create (NodeKey);
		NewNode._Floats = Floats;
		NewNode._Ints = Ints;
		NewNode._Strings = Strings;
		NewNode._Nodes = Nodes;

		this._Nodes.Add (NewNode);
		return NewNode;
	}

	public void AddBool(string NewKey, bool NewValue)
	{
		_Bools.Add (new SaveValueBool(NewKey, NewValue));
	}
		
	public void AddString(string NewKey, string NewValue)
	{
		_Strings.Add (new SaveValueString(NewKey, NewValue));
	}

	public void AddFloat(string NewKey, float NewValue)
	{
		_Floats.Add (new SaveValueFloat(NewKey, NewValue));
	}

	public void AddInt(string NewKey, int NewValue)
	{
		_Ints.Add (new SaveValueInt(NewKey, NewValue));
	}

	public bool GetBool(string Key)
	{
		return this._Bools.Find (x => x._Key == Key)._Value;
	}




	public string GetString(string Key)
	{
		return this._Strings.Find (x => x._Key == Key)._Value;
	}




	public int GetStringCount()
	{
		return this._Strings.Count;
	}

	public bool HasString(string Key)
	{
		if (this._Strings.Find (x => x._Key == Key) == null)
			return false;
		return true;
	}

	public string GetString(int Idx)
	{
		return this._Strings [Idx]._Value;
	}

	public float GetFloat(string Key)
	{
		return this._Floats.Find (x => x._Key == Key)._Value;
	}

	public bool HasFloat(string Key)
	{
		if (this._Floats.Find (x => x._Key == Key) == null)
			return false;
		return true;
	}

	public int GetInt(string Key)
	{
		return this._Ints.Find (x => x._Key == Key)._Value;
	}

	public SaveNode AddNode(string NodeKey)
	{
		SaveNode NewNode = SaveNode.Create (NodeKey);
		_Nodes.Add (NewNode);
		return NewNode;
	}

	public SaveNode GetNode(string NewKey)
	{
		return this._Nodes.Find (x => x._Key == NewKey);
	}

	public int GetNodeCount()
	{
		return this._Nodes.Count;
	}

	public SaveNode GetNode(int Idx)
	{
		return this._Nodes[Idx];
	}

	public string GetKey()
	{
		return this._Key;
	}

	public void SetFloat(string Key, float NewValue)
	{
		this._Floats.Find (x => x._Key == Key)._Value = NewValue;
	}
		
	public void SetInt(string Key, int NewValue)
	{
		this._Ints.Find (x => x._Key == Key)._Value = NewValue;
	}
		
	public void SetString(string Key, string NewValue)
	{
		this._Strings.Find (x => x._Key == Key)._Value = NewValue;
	}

}

[System.Serializable]
public class SaveValueInt {

	[XmlAttribute("Key")]
	public string	_Key;
	[XmlElement("Value")]
	public int	_Value;

	public SaveValueInt()
	{
		_Key = "";
		_Value = 0;
	}

	public SaveValueInt(string Key, int Value)
	{
		_Key = Key;
		_Value = Value;
	}

	public static SaveValueInt Create(string Key, int Value)
	{
		return new SaveValueInt (Key, Value);
	}
}

[System.Serializable]
public class SaveValueFloat {

	[XmlAttribute("Key")]
	public string	_Key;
	[XmlElement("Value")]
	public float	_Value;

	public SaveValueFloat()
	{
		_Key = "";
		_Value = 0.0f;
	}

	public SaveValueFloat(string Key, float Value)
	{
		_Key = Key;
		_Value = Value;
	}

	public static SaveValueFloat Create(string Key, float Value)
	{
		return new SaveValueFloat (Key, Value);
	}
}

[System.Serializable]
public class SaveValueString {

	[XmlAttribute("Key")]
	public string	_Key;
	[XmlElement("Value")]
	public string	_Value;

	public SaveValueString()
	{
		_Key = "";
		_Value = "";
	}

	public SaveValueString(string Key, string Value)
	{
		_Key = Key;
		_Value = Value;
	}

	public static SaveValueString Create(string Key, string Value)
	{
		return new SaveValueString (Key, Value);
	}
}

[System.Serializable]
public class SaveValueBool {

	[XmlAttribute("Key")]
	public string	_Key;
	[XmlElement("Value")]
	public bool		_Value;

	public SaveValueBool()
	{
		_Key = "";
		_Value = false;
	}

	public SaveValueBool(string Key, bool Value)
	{
		_Key = Key;
		_Value = Value;
	}

	public static SaveValueBool Create(string Key, bool Value)
	{
		return new SaveValueBool (Key, Value);
	}
}

[System.Serializable]
public class SaveValueByte {

	[XmlAttribute("Key")]
	public string	_Key;
	[XmlElement("Value")]
	public byte[]	_Value;

	public SaveValueByte()
	{
		_Key = "";
		_Value = null;
	}

	public SaveValueByte(string Key, byte[] Value)
	{
		_Key = Key;
		_Value = Value;
	}

	public static SaveValueByte Create(string Key, byte[] Value)
	{
		return new SaveValueByte (Key, Value);
	}
}
