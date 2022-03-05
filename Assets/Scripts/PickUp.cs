using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50;

    public virtual void Picked()
    {
        Debug.Log("Picked up!!!");
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
