using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_Cursor : MonoBehaviour {
    public Texture2D cursorImage;
    public float size_cursor;
    public float size_transistion;
    public float alpha_transistion;
    public float size_click;
    private float initial_size_cursor;
    private Color guiColor;
    private GameObject target;
    private Vector3 mousePos;

    // Use this for initialization
    void Start () {
        Cursor.visible=false;
        initial_size_cursor = size_cursor;
        guiColor = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
            mousePos = Input.mousePosition;
            if (Input.GetMouseButton(0)&& size_cursor>=initial_size_cursor-0.1)
            {
                size_cursor-= size_click;
            }
            

            if(target!=null)
            {
            Debug.Log(Vector3.Distance(target.transform.position, Camera.main.ScreenToWorldPoint(mousePos)));
                guiColor.a = (Vector3.Distance(target.transform.position, Camera.main.ScreenToWorldPoint(mousePos))-10) * alpha_transistion;
            }
            else target = GameObject.FindGameObjectWithTag("Player");

        size_cursor = Mathf.Lerp(size_cursor, initial_size_cursor, size_transistion);

    }

    private void OnGUI()
    {
        GUI.color = guiColor;
        Rect pos = new Rect(mousePos.x - cursorImage.width/size_cursor/2, Screen.height - mousePos.y- cursorImage.height/size_cursor/2, cursorImage.width/size_cursor, cursorImage.height/size_cursor);
        GUI.Label(pos, cursorImage);
    }

}
