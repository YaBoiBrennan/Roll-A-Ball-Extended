using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    /*
    ** Whenever the player collides with the death box we want to move
    ** the player and the camera back to a valid position 
    */
    public GameObject respawnPoint;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            transform.position = respawnPoint.transform.position;
            rb.velocity = Vector3.zero;
        }
    }
}
