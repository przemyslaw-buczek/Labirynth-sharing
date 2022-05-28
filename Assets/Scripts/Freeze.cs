using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    [SerializeField] int freezeTime = 5;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(sound);
        GameManager.gameManager.FreezeTime(freezeTime);
        Destroy(gameObject);
    }
}
