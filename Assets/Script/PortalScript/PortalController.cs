using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject cameraToActivate;
    public GameObject objectToDeactivate;
    public GameObject cameraToDeactivate;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            this.enabled = true;
            objectToActivate.SetActive(true);
            cameraToActivate.SetActive(true);

            this.enabled = false;  
            objectToDeactivate.SetActive(false);
            cameraToDeactivate.SetActive(false);
        }
    }

}
