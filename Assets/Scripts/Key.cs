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
    [SerializeField] Material red;
    [SerializeField] Material green;
    [SerializeField] Material gold;

    private void Start()
    {
        SetMyColor();
    }

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(sound);
        GameManager.gameManager.AddKey(color);
        Destroy(gameObject);
    }

    void SetMyColor()
    {
        switch(color)
        {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                break;
        }
    }
}
