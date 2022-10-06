using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side{Red,Blue}
public class SideHandler : MonoBehaviour
{
    [SerializeField] public Side side;

    public bool Equals(Side side)
    {
        return this.side == side;
    }
    
    public bool Equals(SideHandler sideHandler)
    {
        return this.side == sideHandler.side;
    }
}
