using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  partial class UtilsInstance  : MonoBehaviour
{

	public Vector3 RaycastPosition(Vector3 StartPos, Vector3 EndPos, string[] MaskToTrigger, bool DrawDebug)
	{

		int Mask = LayerMask.GetMask (MaskToTrigger);
		RaycastHit hit;

		if (Physics.Raycast(StartPos, EndPos - StartPos, out hit, Mathf.Infinity, Mask))
		{
			if (DrawDebug == true)
				Debug.DrawRay(StartPos, hit.collider.transform.position, Color.red);
			return hit.point;
		}
		else
		{
			return StartPos;
		}

	}


}
