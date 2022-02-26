using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController characterController;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch(terrainType)
            {
                case "Slow":
                    speed = 5;
                    break;
                case "Fast":
                    speed = 20;
                    break;
                default:
                    speed = 12;
                    break;
            }
        }
    }
}
