using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour{

    public abstract void Use();
    public abstract bool canUse();
}
