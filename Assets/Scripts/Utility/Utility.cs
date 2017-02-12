using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility  {

    public static Vector2 mouseDirection(Camera cam, Transform trsm)
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = trsm.position.z;
        mouse = cam.ScreenToWorldPoint(mouse) - trsm.position;
        return new Vector2(mouse.x, mouse.y);
    }
}
