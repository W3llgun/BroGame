using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseInput
{
    MouseLeft = 0,
    MouseRight = 1,
    MouseMid = 2,
}

[System.Serializable]
public class PlayerInput {
    [SerializeField]
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField]
    private KeyCode Up;
    [SerializeField]
    private KeyCode Down;
    [SerializeField]
    private KeyCode Jump;
    [SerializeField]
    private MouseInput primaryShoot;
    [SerializeField]
    private MouseInput secondaryShoot;

    public bool isLeftDown { get { return Input.GetKeyDown(Left); } }
    public bool isRightDown { get { return Input.GetKeyDown(Right); } }
    public bool isUpDown { get { return Input.GetKeyDown(Up); } }
    public bool isDownDown { get { return Input.GetKeyDown(Down); } }
    public bool isJumpDown { get { return Input.GetKeyDown(Jump); } }
    public bool isPrimaryShootDown { get { return Input.GetMouseButtonDown((int)primaryShoot); } }
    public bool isSecondaryShootDown { get { return Input.GetMouseButtonDown((int)secondaryShoot); } }


    public bool isLeft { get { return Input.GetKey(Left); } }
    public bool isRight { get { return Input.GetKey(Right); } }
    public bool isUp { get { return Input.GetKey(Up); } }
    public bool isDown { get { return Input.GetKey(Down); } }
    public bool isJump { get { return Input.GetKey(Jump); } }
    public bool isPrimaryShoot { get { return Input.GetMouseButton((int)primaryShoot); } }
    public bool isSecondaryShoot { get { return Input.GetMouseButton((int)secondaryShoot); } }
}
