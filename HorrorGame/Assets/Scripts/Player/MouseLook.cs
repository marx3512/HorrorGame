using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public HandlePlayer handlePlayer;

    public float mouseSensitivity = 200f;

	public Transform playerBody;

	float xRotation = 0f;

	public void Update()
	{
		if (!handlePlayer.ControlIsConnected)
		{
			float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

			xRotation -= mouseY;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			playerBody.Rotate(Vector3.up * mouseX);
		}
		else
		{
			float controlX = Input.GetAxis("HorizontalJoystickRight") * mouseSensitivity * Time.deltaTime;
			float controlY = Input.GetAxis("VerticalJoystickRight") * mouseSensitivity * Time.deltaTime;

			xRotation -= controlX;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			playerBody.Rotate(Vector3.up * controlY);
		}
	}
}
