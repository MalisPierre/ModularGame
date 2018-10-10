using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[XmlRoot("SaveGame")]
public class SaveHandler : BaseContainer{

	[XmlElement("Nodes")]
	public SaveNode		_SaveGame;


	public static void WriteSave(SaveNode NewData, string NewPath)
	{
		string Path = NewPath;

		SaveHandler Cont = new SaveHandler ();
		Cont._SaveGame = NewData;

		var Serializer = new XmlSerializer(typeof(SaveHandler));

		Cont.WriteFile <SaveHandler>(Serializer, Path, Cont);
	}

	public static Texture2D LoadTexture(string Path)
	{
		Texture2D Text = new Texture2D(1280, 720, TextureFormat.ARGB32, false);
		Text.LoadImage (File.ReadAllBytes (Path));
		//WWW www = new WWW (Path);
		//www.LoadImageIntoTexture (Text);

		return Text;


		//Text.LoadRawTextureData(File.ReadAllBytes (Path));
		//return Text;
	}

	public static void WriteTexture(Texture2D Img, string NewPath)
	{
		File.WriteAllBytes(NewPath, Img.EncodeToPNG());
	}

	public static void WriteBynary(byte[] Data, string NewPath)
	{
		File.WriteAllBytes(NewPath, Data);

	}

	// ENCODED
	// DESCRYPTED
	public SaveNode ReadSave(string NewPath)
	{
		string Path = NewPath;
		if (File.Exists (Path) == false)
			return null;
		BaseContainer Reader = new BaseContainer ();

		var Serializer = new XmlSerializer(typeof(SaveHandler));

		XmlTextReader stream = Reader.ReadFile (Serializer, Path);

		SaveHandler Cont = new SaveHandler ();

		Cont = (SaveHandler)Serializer.Deserialize (stream);
		stream.Close ();
		Reader.CloseFile ();

		Cont.CloseFile ();
		return Cont._SaveGame;
	}

	public static string GetSaveName(string FPath, string Extention, int Idx)
	{
		return Path.GetFileName (Directory.GetFiles (FPath, Extention)[Idx]);
	}

	public static string GetSaveName(string FPath, int Idx)
	{
		return Path.GetFileName (Directory.GetFiles (FPath)[Idx]);
	}

	public static string GetSaveFile(string Path, int Idx)
	{
		return Directory.GetFiles (Path)[Idx];
	}

	public static string GetSaveFile(string Path, string Extention, int Idx)
	{
		return Directory.GetFiles (Path, Extention)[Idx];
	}

	public static int GetSavesLen(string Path)
	{
		return Directory.GetFiles (Path).Length;
	}

	public static int GetSavesLen(string Path, string Extention)
	{
		return Directory.GetFiles (Path, Extention).Length;
	}

	public static bool SaveFileExist(string FullPath)
	{
		return File.Exists (FullPath);
		/*
		string FullName = Path + Name;
		List<string> SaveNames = new List<string>(Directory.GetFiles (Path));
		return SaveNames.Contains (FullName);*/
	}

}
	