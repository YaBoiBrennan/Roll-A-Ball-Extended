using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float speed;
    public float xVal;
    public float yVal;
    public float zVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xVal, yVal, zVal) * speed * Time.deltaTime);
    }
}
