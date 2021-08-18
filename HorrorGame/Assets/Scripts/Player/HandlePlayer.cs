using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlePlayer : MonoBehaviour
{
	public MovePlayer playerMove;
	public MouseLook lookMouse;

    [SerializeField] private Transform camTransform;
	[SerializeField] private LayerMask layer;

	[SerializeField] private GameObject textObject;
	[SerializeField] private GameManager gm;

	public bool ImDead = false;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		RaycastHit hit;
		if(Physics.Raycast(camTransform.position, camTransform.forward, out hit, 500f, layer))
		{
			textObject.SetActive(true);
			if (Input.GetMouseButtonDown(0))
			{
				Destroy(hit.transform.gameObject);
				gm.quant++;
			} 
		}
		else textObject.SetActive(false);

		if (ImDead)
		{
			playerMove.enabled = false;
			lookMouse.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
