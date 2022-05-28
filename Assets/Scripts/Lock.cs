using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Doors[] doors;
    public KeyColor myColor;
    bool iCanOpen = false;
    bool locked = false;
    Animator key;

    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You Can Use Lock");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You Can not Use Lock");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
            
        }
    }

    public void UseKey()
    {
        foreach(Doors door in doors)
        {
            door.OpenClose();
        }
    }

    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKeys > 0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKeys--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKeys > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKeys--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKeys > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKeys--;
            locked = true;
            return true;
        } else
        {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }




}
