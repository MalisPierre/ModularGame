using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public partial class ScriptAPI {


	public class ScriptLib
	{
		public static ScriptHolder AddCategory(string CategoryName)
		{
			return ScriptLibrary.Instance.AddCategory(CategoryName);
		}

		public static ScriptHolder AddHolder(string CategoryName, string ScriptPath)
		{
			return ScriptLibrary.Instance.AddHolder(CategoryName, ScriptPath);
		}

		public static bool Has(string HolderName)
		{
			return ScriptLibrary.Instance.Has(HolderName);
		}
			
		public static ScriptHolder Find(string HolderName)
		{
			return ScriptLibrary.Instance.Find(HolderName);
		}

		public static ScriptHolder GetHolder(int HolderIdx)
		{
			return ScriptLibrary.Instance.GetHolder(HolderIdx);
		}

		public static int GetHolderCount()
		{
			return ScriptLibrary.Instance.GetHolderCount ();
		}

		public static void DeleteHolder(string HolderName)
		{
			ScriptLibrary.Instance.DeleteHolder (HolderName);
		}

		public static void DeleteHolder(int HolderIdx)
		{
			ScriptLibrary.Instance.DeleteHolder (HolderIdx);
		}

	}
}
