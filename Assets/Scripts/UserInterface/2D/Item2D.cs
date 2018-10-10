using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2D : MonoBehaviour {

    public string GetId()
    {
        return this.transform.gameObject.name;
    }

    public void SetId(string NewId)
    {
        this.transform.gameObject.name = NewId;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }



    public void Delete()
    {
        Destroy(this.gameObject);
    }


    // -- UI POSITION --
    public void SetPivot(Vector3 PivotPos)
    {
        this.GetComponent<RectTransform>().pivot = PivotPos;
    }
    public void SetOffsetSize(Vector3 NewSize)
    {
        this.GetComponent<RectTransform>().sizeDelta = NewSize;
    }
    public void SetOffsetPos(Vector3 Anchor)
    {
        this.GetComponent<RectTransform>().anchoredPosition = Anchor;
    }
    public Vector3 GetOffsetPos()
    {
        return this.GetComponent<RectTransform>().anchoredPosition;
    }

    public void SetOffsetMin(Vector3 NewSize)
    {
        this.GetComponent<RectTransform>().offsetMin = NewSize;
    }
    public void SetOffsetMax(Vector3 NewSize)
    {
        this.GetComponent<RectTransform>().offsetMax = NewSize;
    }
    public void SetAnchorMin(Vector3 AnchorMin)
    {
        this.GetComponent<RectTransform>().anchorMin = AnchorMin;
    }
    public void SetAnchorMax(Vector3 AnchorMax)
    {
        this.GetComponent<RectTransform>().anchorMax = AnchorMax;
    }

    public void SetPosition(Vector3 NewMin, Vector3 NewMax)
    {
        //this.GetComponent<RectTransform> ().anchoredPosition3D = NewPos;
        this.GetComponent<RectTransform>().anchorMin = NewMin;
        this.GetComponent<RectTransform>().anchorMax = NewMax;
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
    }
    /*

    public void SetOffset(Vector3 NewMin, Vector3 NewMax)
    {
        //this.GetComponent<RectTransform> ().anchoredPosition3D = NewPos;
        this.GetComponent<RectTransform>().offsetMin = NewMin;
        this.GetComponent<RectTransform>().offsetMax = NewMax;
        //this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
    }

    public void SetSize(Vector3 NewSize)
    {
        this.GetComponent<RectTransform>().offsetMax = NewSize;
    }

    public void SetPos(Vector3 NewSize)
    {
        this.GetComponent<RectTransform>().offsetMin = NewSize;
    }

    public void SetAnchor(Vector3 Anchor)
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(Anchor.x, Anchor.y);
    }
    */
}
