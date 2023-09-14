using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    public float minY; 
    public float maxY; 
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    [SerializeField] float verticalmovementSpeed ;
    
    
    private void Update()
    {
        
            if (Input.GetMouseButton(0))
            {
                
                PlayerPositionUp();

            }
            else
            {

            PlayerPositionDown();

            }                

    }
    

    
    void PlayerPositionUp()
    {
        
        Vector2 position = transform.position + (Time.deltaTime * verticalmovementSpeed * Vector3.up);

        position.y = Mathf.Clamp(position.y, minY, maxY);
        
        transform.position = position;
    }
    void PlayerPositionDown()
    {

        Vector2 position = transform.position + (Time.deltaTime * verticalmovementSpeed * Vector3.down);

        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }



}
