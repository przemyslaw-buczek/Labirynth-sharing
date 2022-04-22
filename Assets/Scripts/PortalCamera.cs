using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    float myAngle;

    public float MyAngle
    {
        get { return myAngle; }
        set { myAngle = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PortalCameraController();
    }

    void PortalCameraController()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if (myAngle == 90 || myAngle == 270)
        {
            angularDifference -= 90;
        }

        Quaternion portalRotDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCameraDirection = portalRotDifference * playerCamera.forward;

        if (myAngle == 90 || myAngle == 270)
        {
            newCameraDirection = new Vector3(newCameraDirection.z * -1, newCameraDirection.y * 1, newCameraDirection.x * 1);
        }
        else
        {
            newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y * 1, newCameraDirection.z * 1);
        }

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
