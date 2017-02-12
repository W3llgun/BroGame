using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_Cursor : MonoBehaviour {
    public Texture cursorImage;
    public float size_cursor;
	// Use this for initialization
	void Start () {
        Cursor.visible=false;
    }
	
	// Update is called once per frame
	/*void Update () {
		
	}*/

    private void OnGUI()
    {
        Vector3 mousePos = Input.mousePosition;
        Rect pos = new Rect(mousePos.x - cursorImage.width/Mathf.Pow(size_cursor,2), Screen.height - mousePos.y- cursorImage.height/ Mathf.Pow(size_cursor, 2), cursorImage.width/size_cursor, cursorImage.height/size_cursor);
        GUI.Label(pos, cursorImage);
    }
}
