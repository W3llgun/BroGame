using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public static CameraScript instance;
    Camera cam;

    void Awake () {
        instance = this;
        cam = GetComponent<Camera>();
    }

    public Vector3 MouseToViewport()
    {
        return cam.ScreenToViewportPoint(Input.mousePosition);
    }
    public Vector3 MouseToWorld()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector3 WorldToViewport(Vector3 pos)
    {
        return cam.WorldToViewportPoint(pos);
    }
}

