using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            this.enabled = true;
            objectToActivate.SetActive(true);

            this.enabled = false;  
            objectToDeactivate.SetActive(false);
        }
    }

}
