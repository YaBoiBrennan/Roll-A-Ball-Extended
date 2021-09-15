using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    public GameObject cameraParent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float magnitude = (float)(Math.Pow(moveHorizontal, 2) + Math.Pow(moveVertical, 2));
        float angle = cameraParent.transform.rotation.eulerAngles.y;
        float radian = (float)((Math.PI / 180)) * angle;

        float finalX = (float)(magnitude * Math.Cos(radian));
        float finalZ = (float)(magnitude * Math.Sin(radian));

        Vector3 movement = new Vector3(finalZ, 0.0f, finalX);


        if (moveVertical >= 0)
        {
            rb.AddForce(movement * speed);
            Debug.DrawLine(transform.position, transform.position + movement, Color.red);
        }
        else
        {
            rb.AddForce(movement * speed * -1);
            Debug.DrawLine(transform.position, transform.position - movement, Color.red);
        }
        //rb.velocity = movement * speed;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You win!";
        }
    }
}

