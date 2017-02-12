using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour {
    private Transform target;
    public float speed_mouse;
    public float speed_cam;
    public float limitX;
    public float limitY;
    // Use this for initialization
    void Start () {
        target = transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(target!=null)
        {
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(target.position.x - (target.position.x - transform.position.x) * speed_cam, target.position.y - (target.position.y - transform.position.y) * speed_cam, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - (transform.position.x - mouseInWorld.x)* speed_mouse, target.position.x - limitX, target.position.x + limitX) , Mathf.Clamp(transform.position.y - (transform.position.y - mouseInWorld.y) * speed_mouse, target.position.y - limitY, target.position.y + limitY) , transform.position.z);

        }
    }

    public void setTargetTransform(Transform pTransform)
    {
        target = pTransform;
    }
}
