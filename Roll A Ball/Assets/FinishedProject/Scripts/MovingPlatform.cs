using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject point1;
    public GameObject point2;

    private bool goingToPoint2;
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        goingToPoint2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(goingToPoint2)
        {
            Vector3 translation = point2.transform.position - platform.transform.position;
            platform.transform.Translate(translation.normalized * speed * Time.deltaTime);
            if (Vector3.Magnitude(platform.transform.position - point2.transform.position) <= 0.1)
                goingToPoint2 = false;
        }
        else
        {
            Vector3 translation = point1.transform.position - platform.transform.position;
            platform.transform.Translate(translation.normalized * speed * Time.deltaTime);
            if (Vector3.Magnitude(platform.transform.position - point1.transform.position) <= 0.1)
                goingToPoint2 = true;
        }

    }
}
