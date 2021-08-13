using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleEnemy : MonoBehaviour
{
    [SerializeField] private GameObject playerTarget;

	private void Start()
	{
		playerTarget = GameObject.Find("Player");
	}

	private void Update()
	{
		if (Vector3.Distance(this.transform.position, playerTarget.transform.position) >= 100f) Debug.Log("Estou muito longe");
	}
}
