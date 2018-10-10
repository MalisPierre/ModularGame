using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public partial class ScriptAPI {


	public class UserInterface_2D
	{
		public static void CreatePanel(string AssetId, string PanelId)
		{
			UserInterface2D.Instance.CreatePanel (AssetId, PanelId);
		}

		public static void DeletePanel(string PanelId)
		{
			UserInterface2D.Instance.DeletePanel (PanelId);
		}

		public static Panel2D FindPanel(string PanelId)
		{
			return UserInterface2D.Instance.FindPanel (PanelId);
		}

		public static DynValue Call(string FuncName, DynValue []Params)
		{
			return UserInterface2D.Instance._ScriptInstance.Call (FuncName, Params);
		}

		public static DynValue CallNoParams(string FuncName)
		{
			return UserInterface2D.Instance._ScriptInstance.CallNoParams (FuncName);
		}
	}


}
