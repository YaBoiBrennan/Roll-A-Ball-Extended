using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	[SerializeField] private Vector2 sensitivity;

	private Vector2 rotation;

	[SerializeField] private float maxVerticalAngleFromHorizon;

	void Start ()
    {
        offset = transform.position - player.transform.position;

	}

	private float ClampVerticalAngle(float angle)
    {
		return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);
    }

	private Vector2 GetInput()
    {
		return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * -1);
    }
	
	
	void LateUpdate ()
    {
		Vector2 wantedVelocity = GetInput() * sensitivity;

		rotation += wantedVelocity * Time.deltaTime;
		rotation.y = ClampVerticalAngle(rotation.y);

        transform.position = player.transform.position + offset;



		transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
	}
}
