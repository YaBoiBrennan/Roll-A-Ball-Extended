using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	[SerializeField] private Vector2 sensitivity;

	private Vector2 rotation;


	
	void Start ()
    {
        offset = transform.position - player.transform.position;

	}

	private Vector2 GetInput()
    {
		return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * -1);
    }
	
	
	void LateUpdate ()
    {
		Vector2 wantedVelocity = GetInput() * sensitivity;

		rotation += wantedVelocity * Time.deltaTime;

        transform.position = player.transform.position + offset;

		transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
	}
}
