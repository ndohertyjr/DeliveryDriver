using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;
    int numOfDeliveries = 0;
    

    //Delay to destroy object;
    [SerializeField] float destroyDelay = 0.2f;
    //Change vehicle color on package pickup
    [SerializeField] Color32 hasPackageColor = new Color32(1, 0, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 0, 0, 1);
    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You hit something!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //if trigger is package, indicate package is picked up
        if (other.tag == "Package" && hasPackage == false) 
        {
            Debug.Log("Package collected!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            
        }
        else if (other.tag == "Package" && hasPackage == true)
        {
            Debug.Log("Package already on the vehicle.  Deliver your package first!");
        }
        if (other.tag == "Delivery Location" && hasPackage == false) 
        {
            Debug.Log("No package in inventory!");            
        }
        else if (other.tag == "Delivery Location"  && hasPackage == true) 
        {
            numOfDeliveries++;
            Debug.Log("Package Delivered!  Total deliveries: " + numOfDeliveries);
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
        
        
    }

}
