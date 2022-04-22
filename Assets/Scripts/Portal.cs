using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    GameObject player;
    [SerializeField] Transform myRenderPlane;
    [SerializeField] Transform myColliderPlane;
    [SerializeField] Portal otherPortal;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;

    [SerializeField] Material material;
    public float myAngle;

    // Start is called before the first frame update
    void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.gameObject.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");
        portalTeleport.player = player.transform;

        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);

        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.MyAngle = myAngle;
    }

    private void Start()
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
        CheckAngle();
    }

    void CheckAngle()
    {
        if (Mathf.Abs(otherPortal.myAngle) - myAngle != 180)
        {
            Debug.LogWarning("portale nie są odpowiednio ustawione: " + gameObject.name);
            Debug.Log("Angle: " + (Mathf.Abs(otherPortal.myAngle) - myAngle));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
