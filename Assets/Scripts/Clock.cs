using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] int time = 5;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(sound);
        GameManager.gameManager.AddTime(time);
        Destroy(gameObject);
    }
}
