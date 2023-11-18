
using UnityEngine;


public class PortalController : MonoBehaviour
{

    [SerializeField] 
    private TriggerEnterEventDispatcher _portalEventDispatcher;
    private void OnEnable()
    {
        AddEvents();
        
    }
    private void OnDisable()
    {
        RemoveEvents();
       
    }

    private void OnTriggerPortal(object sender , Collider2D collider2D)
    {
      var PlayerController = collider2D.GetComponent<PlayerController>();
        if (PlayerController == null)
        {
            return;
        }
        PlayerController.PortalEnter();
        
    }
    private void AddEvents()
    {
        _portalEventDispatcher.OnTriggerEvent += OnTriggerPortal;
              
    }
    private void RemoveEvents()
    {
        _portalEventDispatcher.OnTriggerEvent -= OnTriggerPortal;
       
    }
}
 
