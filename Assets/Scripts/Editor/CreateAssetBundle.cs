using UnityEditor;
using System.IO;

public class CreateAssetBundle
{
	[MenuItem("LaVipere/Build AssetBundles/Windows")]
	static void BuildAllAssetBundlesWindows()
	{
		string assetBundleDirectory = "Data";
		if(!Directory.Exists(assetBundleDirectory))
		{
			Directory.CreateDirectory(assetBundleDirectory);
		}
		//BuildPipeline.BuildAssetBundles (outputPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget)
		BuildPipeline.BuildAssetBundles(
			assetBundleDirectory, 
			BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.StrictMode, 
			BuildTarget.StandaloneWindows);
	}

	[MenuItem("LaVipere/Build AssetBundles/Android")]
	static void BuildAllAssetBundlesAndroid()
	{
		string assetBundleDirectory = "Android";
		if(!Directory.Exists(assetBundleDirectory))
		{
			Directory.CreateDirectory(assetBundleDirectory);
		}
		BuildPipeline.BuildAssetBundles(
			assetBundleDirectory, 
			BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.StrictMode, 
			BuildTarget.Android);
	}


}