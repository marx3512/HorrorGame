using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private GameObject groupStartExit, groupChoice;

    public void StartGame()
	{
		groupStartExit.SetActive(false);
		groupChoice.SetActive(true);

	}

	public void ExitGame()
	{

	}

	public void CondPlayer(int x)
	{
		if(x == 2)
		{
			if (Input.GetJoystickNames().Length <= 0) Debug.Log("Conecte um controle");
			else
			{
				DataPlayers.cond = x;
				SceneManager.LoadScene(1);
			}
		}
		
	}

	public void ExitMenu()
	{
		groupStartExit.SetActive(true);
		groupChoice.SetActive(false);
	}
}
