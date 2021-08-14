using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleEnemy : MonoBehaviour
{
    [SerializeField] private GameObject playerTarget;
	[SerializeField] private GameObject enemy;
	[SerializeField] private AIEnemy aiEnemyScript;

	private void Start()
	{
		playerTarget = GameObject.Find("Player");
	}

	private void Update()
	{
		if (Vector3.Distance(transform.position, playerTarget.transform.position) >= 100f)
		{
			enemy.transform.position = new Vector3(playerTarget.transform.position.x + 50,
				playerTarget.transform.position.y, 
				playerTarget.transform.position.z + 50);
			aiEnemyScript.walkPointSet = false;
		}
	}
}
