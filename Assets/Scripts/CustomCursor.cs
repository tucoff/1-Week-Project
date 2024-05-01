using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    public Transform mCursorVisual;
    public Vector3 mDisplacement;
    void Start()
    {
      // this sets the base cursor as invisible
      Cursor.visible = false;
    }

    void Update()
    {
      mCursorVisual.position = Input.mousePosition + mDisplacement;

      if (Input.GetMouseButton(0)) 
      {
        transform.GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<Image>().enabled = true;
      }
      else
      {
        transform.GetComponent<Image>().enabled = true;
        transform.GetChild(0).GetComponent<Image>().enabled = false;
      }
    }
}