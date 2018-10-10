using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

public enum FileAccessMode
{
	READ = 0,
	WRITE = 1
}

public class BaseContainer {

	FileStream _BaseStream = null;
	XmlTextReader _DecodedStream = null;
	XmlTextWriter _EncodedStream = null;

	public static FileStream GetFileStream(string Path, FileAccessMode AccessMode)
	{
		FileMode Mode;
		if (AccessMode == FileAccessMode.READ)
			Mode = FileMode.Open;
		else
			Mode = FileMode.Create;
		return new FileStream (Path, Mode);
	}

	public static XmlTextWriter EncodeFileStream(FileStream NormalStream)
	{
		XmlTextWriter EncodedStream = new XmlTextWriter (NormalStream, Encoding.GetEncoding ("UTF-8"));
		EncodedStream.Formatting = Formatting.Indented;
		return EncodedStream;
	}

	public static XmlTextReader DecodeFileStream(FileStream NormalStream)
	{
		XmlTextReader DecodedStream = new XmlTextReader (NormalStream);
		return DecodedStream;
	}

	public void WriteFile<T>(XmlSerializer Serializer, string Path, T Cont)
	{
		// OPEN BASE STREAM (MEMORY)
		_BaseStream = GetFileStream (Path, FileAccessMode.WRITE);
		if (_BaseStream == null)
			return ;

		// ENCODE STREAM (MEMORY)
		_EncodedStream = EncodeFileStream (_BaseStream);
		if (_EncodedStream == null)
		{
			CloseFile ();
			return ;
		}

		// FILE WRITE HERE (MEMORY ==> FILE)
		Serializer.Serialize(_EncodedStream, Cont);

		CloseFile ();

	}

	public XmlTextReader ReadFile(XmlSerializer Serializer, string Path)
	{

		_BaseStream = GetFileStream (Path, FileAccessMode.READ);
		if (_BaseStream == null)
			return null;

		_DecodedStream = DecodeFileStream (_BaseStream);
		if (_DecodedStream == null)
		{
			CloseFile ();
			return null;
		}

		return _DecodedStream;
	}

	public void CloseFile()
	{
		if (_DecodedStream != null) {
			_DecodedStream.Close ();
			_DecodedStream = null;
		}

		if (_EncodedStream != null) {
			_EncodedStream.Close ();
			_EncodedStream = null;
		}
			
		if (_BaseStream != null) {
			_BaseStream.Close ();
			_BaseStream = null;
		}
	}

}
