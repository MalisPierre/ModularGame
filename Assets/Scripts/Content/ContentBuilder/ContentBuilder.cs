using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentBuilder : MonoBehaviour {


	public static SaveNode GetParadiseIslandData()
	{
		SaveNode ConfigRoot = new SaveNode ("Root");

		SaveNode Loading = ConfigRoot.AddNode ("Loading");
		Loading.AddString ("Bundle", "exterminator_main/loading");
		Loading.AddString ("Asset", "Assets/Contents/exterminator_main/loading/loading.controller");

		SaveNode Bundles = ConfigRoot.AddNode ("Bundles");

		Bundles.AddString ("01", "core_content");
		Bundles.AddString ("02", "common_assets");
		Bundles.AddString ("03", "paradise_island_core");
		Bundles.AddString ("04", "paradise_island_01");
		//ParadiseIsland01.AddString ("01", "stranded_dialog");

		return ConfigRoot;
	}

	public static SaveNode GetExterminatorAndroidData()
	{
		LoadOrderData LoadOrder = new LoadOrderData ();
		LoadOrder.SetVersion ("1.0");
		LoadOrder.SetLoading ("exterminator_main/loading", "Assets/Contents/exterminator_main/loading/loading.controller");
		LoadOrder.SetInstances (
			"exterminator_main:exterminator_core:Scripts/Engine/Engine",
			"exterminator_main:exterminator_core:Scripts/Camera/Camera",
			"exterminator_main:exterminator_ui:Scripts/UserInterface"
		);
		LoadOrder.AddHeader (new HeaderData ("core_content", "https://drive.google.com/uc?export=download&id=12Bt_OY6MDe75Uqd7Pbf8TRXJJsi5x-Vb"));
		LoadOrder.AddHeader (new HeaderData ("common_assets", "https://drive.google.com/uc?export=download&id=17BMSyWRWtD_QlwblSy3DLRoaHcsFcjs7"));
		LoadOrder.AddHeader (new HeaderData ("exterminator_main", "https://drive.google.com/uc?export=download&id=1h7ssEgy6ZoWu9TPrMasuEXultly3vvZO"));
		LoadOrder.AddHeader (new HeaderData ("exterminator_scenes", "https://drive.google.com/uc?export=download&id=1BXXj5wCwYj8VcxDCVS_EKwV1I1sSde5B"));
		LoadOrder.AddHeader (new HeaderData ("exterminator_characters", "https://drive.google.com/uc?export=download&id=1mFCtrMdlSVfE-N6mRAu1MCoSfMfJewdx"));
		return LoadOrder.LoadOrderDataToSaveNode ();
	}

	public static SaveNode GetExterminatorData()
	{
		LoadOrderData LoadOrder = new LoadOrderData ();
		LoadOrder.SetVersion ("1.0");
		LoadOrder.SetLoading ("exterminator_main/loading", "Assets/Contents/exterminator_main/loading/loading.controller");
		LoadOrder.SetInstances (
			"exterminator_main:exterminator_core:Scripts/Engine/Engine",
			"exterminator_main:exterminator_core:Scripts/Camera/Camera",
			"exterminator_main:exterminator_ui:Scripts/UserInterface"
		);

		LoadOrder.AddHeader (new HeaderData ("core_content", "https://drive.google.com/uc?export=download&id=14kuabzg-0-gwq-XqS2hk3FXUyu9m1lGV"));
		LoadOrder.AddHeader (new HeaderData ("common_assets", "https://drive.google.com/uc?export=download&id=1PWbv0Z-8GBEJQ-0N7qshtoOuuhH3CYAT"));
		LoadOrder.AddHeader (new HeaderData ("exterminator_main", "https://drive.google.com/uc?export=download&id=1Bki57jCbvoU5KTpMs58HJgVmNJCeSpKl"));
		LoadOrder.AddHeader (new HeaderData ("exterminator_scenes", "https://drive.google.com/uc?export=download&id=1ipwNBQwCKkxvx07G3uPSKDmV1uElVV-f"));
		LoadOrder.AddHeader (new HeaderData ("exterminator_characters", "https://drive.google.com/uc?export=download&id=18H8B9Ika8LlG24gm32Qq4oGFV-TQwVII"));
		return LoadOrder.LoadOrderDataToSaveNode ();
	}

	public static SaveNode GetLabyrinth3DData()
	{
		LoadOrderData LoadOrder = new LoadOrderData ();

		LoadOrder.SetVersion ("1.0");

		LoadOrder.SetLoading (
			"labyrinth_3d_main/loading", 
			"Assets/Contents/labyrinth_3d_main/loading/loading.controller");
		
		LoadOrder.SetInstances (
			"labyrinth_3d_main:labyrinth_core:Scripts/Engine/Engine",
			"labyrinth_3d_main:labyrinth_core:Scripts/Camera/Camera",
			"labyrinth_3d_main:labyrinth_ui:Scripts/UserInterface/UserInterface"
		);
		LoadOrder.AddHeader (new HeaderData ("core_content", "https://drive.google.com/uc?export=download&id=12Bt_OY6MDe75Uqd7Pbf8TRXJJsi5x-Vb"));
		LoadOrder.AddHeader (new HeaderData ("common_assets", "https://drive.google.com/uc?export=download&id=17BMSyWRWtD_QlwblSy3DLRoaHcsFcjs7"));
		LoadOrder.AddHeader (new HeaderData ("labyrinth_3d_main", "https://drive.google.com/uc?export=download&id=1fQCNVErw9rvQ6J-Ur-GDCDjKHa4pFbN7"));
		return LoadOrder.LoadOrderDataToSaveNode ();
	}

	public static SaveNode GetPlatformSolverData()
	{
		LoadOrderData LoadOrder = new LoadOrderData ();

		LoadOrder.SetVersion ("1.0");

		LoadOrder.SetLoading (
			"platform_solver/loading", 
			"Assets/Contents/platform_solver/loading/loading.controller");

		LoadOrder.SetInstances (
			"platform_solver:core:Scripts/Engine/Engine",
			"platform_solver:core:Scripts/Camera/Camera",
			"platform_solver:ui:Scripts/UserInterface/UserInterface"
		);//https://drive.google.com/open?id=1pS1_HVgKXCDN6Z5cO4WYIvhsGajtCen_
		LoadOrder.AddHeader (new HeaderData ("core_content", "1.0.A"));
		LoadOrder.AddHeader (new HeaderData ("common_assets", "1.0.A"));
		LoadOrder.AddHeader (new HeaderData ("platform_solver", "1.0.A"));
		return LoadOrder.LoadOrderDataToSaveNode ();
	}

	public static SaveNode GetLabyrinth2DData()
	{
		SaveNode ConfigRoot = new SaveNode ("Root");

		SaveNode Loading = ConfigRoot.AddNode ("Loading");
		Loading.AddString ("Bundle", "labyrinth_2d_main/loading");
		Loading.AddString ("Asset", "Assets/Contents/labyrinth_2d_main/loading/loading.controller");
		SaveNode Instances = ConfigRoot.AddNode ("Instances");
		Instances.AddString ("Engine", "labyrinth_2d_main:labyrinth_core:Scripts/Engine/Engine");
		Instances.AddString ("Camera", "labyrinth_2d_main:labyrinth_core:Scripts/Camera/Camera");
		Instances.AddString ("UserInterface", "labyrinth_2d_main:labyrinth_ui:Scripts/UserInterface");

		SaveNode Bundles = ConfigRoot.AddNode ("Bundles");
		//SaveNode CoreContent = ConfigRoot.AddNode ("core_content");
		Bundles.AddString ("01", "core_content");
		Bundles.AddString ("02", "common_assets");
		Bundles.AddString ("03", "labyrinth_2d_main");
		return ConfigRoot;
	}

	public static SaveNode GetLabyrinth2DEditorData()
	{
		SaveNode ConfigRoot = new SaveNode ("Root");

		SaveNode Loading = ConfigRoot.AddNode ("Loading");
		Loading.AddString ("Bundle", "labyrinth_2d_main/loading");
		Loading.AddString ("Asset", "Assets/Contents/labyrinth_2d_main/loading/loading.controller");
		SaveNode Instances = ConfigRoot.AddNode ("Instances");
		Instances.AddString ("Engine", "labyrinth_2d_editor:labyrinth_2d_editor:Scripts/GenerateLabyrinth/Engine/Engine");
		Instances.AddString ("Camera", "labyrinth_2d_editor:labyrinth_2d_editor:Scripts/GenerateLabyrinth/Camera/Camera");
		Instances.AddString ("UserInterface", "labyrinth_2d_editor:labyrinth_2d_editor:Scripts/GenerateLabyrinth/UserInterface");

		SaveNode Bundles = ConfigRoot.AddNode ("Bundles");

		//SaveNode CoreContent = ConfigRoot.AddNode ("core_content");
		Bundles.AddString ("01", "core_content");
		Bundles.AddString ("02", "common_assets");
		Bundles.AddString ("03", "labyrinth_2d_main");
		Bundles.AddString ("04", "labyrinth_2d_editor");
		return ConfigRoot;
	}

	public static SaveNode GetNiceTownData()
	{
		LoadOrderData LoadOrder = new LoadOrderData ();

		LoadOrder.SetVersion ("1.0");

		LoadOrder.SetLoading (
			"nice_town_core/loading", 
			"Assets/Contents/nice_town_core/loading/Animations/HouseFront.controller");

		LoadOrder.SetInstances (
			"nice_town_core:core:Scripts/Engine/Engine",
			"nice_town_core:core:Scripts/Camera/Camera",
			"nice_town_core:ui:Scripts/UserInterface/UserInterface"
		);
		LoadOrder.AddHeader (new HeaderData ("core_content", "1.0.A"));
		LoadOrder.AddHeader (new HeaderData ("common_assets", "1.0.A"));
		LoadOrder.AddHeader (new HeaderData ("nice_town_core", "1.0.A"));

		LoadOrder.AddHeader (new HeaderData ("nice_town_event_demenagement", "1.0.A"));
        LoadOrder.AddHeader(new HeaderData("nice_town_event_milkmaidtraining", "1.0.A"));
        

        LoadOrder.AddHeader (new HeaderData ("nice_town_area_nice_neighborhood", "1.0.A"));
		LoadOrder.AddHeader (new HeaderData ("nice_town_area_lilith_realm", "1.0.A"));
		return LoadOrder.LoadOrderDataToSaveNode ();
	}

}
