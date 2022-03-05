using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Gold
}

public class Key : PickUp
{
    [SerializeField] KeyColor color;

    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);

        Destroy(gameObject);
    }
}
