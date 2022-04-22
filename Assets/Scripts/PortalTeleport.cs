using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    [SerializeField] Transform reciever;

    public bool isPlayerOverlapping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        Teleportation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOverlapping = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOverlapping = false;
        }
    }

    private void Teleportation()
    {
        if (isPlayerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f)
            {
                float rotationDifference = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDifference += 180;
                player.Rotate(Vector3.up, rotationDifference);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;

                player.position = reciever.position + positionOffset;
                isPlayerOverlapping = false;
            }
        }
    }
}
