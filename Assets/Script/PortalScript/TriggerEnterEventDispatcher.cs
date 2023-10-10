using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterEventDispatcher : MonoBehaviour
{
    public event EventHandler<Collider2D> OnTriggerEvent;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
         OnTriggerEvent?.Invoke(this,collision);
    }
}
