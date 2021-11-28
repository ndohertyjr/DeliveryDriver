using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 100f;

    int boostTimer = 0;
    int collisionTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pick up a package and drop it at the blue point to score!");
    }

    // Update is called once per frame
    void Update()
    {
        if (boostTimer > 0) 
        {
            boostTimer--;
        }
        if (collisionTimer > 0) 
        {
            collisionTimer--;
        }
        if (collisionTimer == 0 && boostTimer == 0) 
        {
            moveSpeed = 20f;
        }
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float driveSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, driveSpeed, 0);
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            boostTimer = 50;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
        collisionTimer = 5;
    }
}
