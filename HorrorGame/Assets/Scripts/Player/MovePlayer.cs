using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public HandlePlayer handlePlayer;

    public CharacterController controller;

    public float speed = 12f;

	private void Update()
	{
		if (!handlePlayer.ControlIsConnected)
		{
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			Vector3 move = transform.right * x + transform.forward * z;
			controller.Move(move * speed * Time.deltaTime);
		}
		else
		{
			float x = Input.GetAxis("HorizontalJoystickLeft");
			float z = Input.GetAxis("VerticalJoystickLeft");

			Vector3 move = transform.right * x + transform.forward * z;
			controller.Move(move * speed * Time.deltaTime);
		}
	}
}
