using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public HandlePlayer handlePlayer;

    public CharacterController controller;

    public float speed = 12f;
	float gravity = -18f;

	[SerializeField] private Transform groundCheck;
	private float groundDistance = 0.4f;
	public LayerMask groundMask;
	private bool isGrounded;

	Vector3 velocity;

	private void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0) velocity.y = 0f;

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
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
