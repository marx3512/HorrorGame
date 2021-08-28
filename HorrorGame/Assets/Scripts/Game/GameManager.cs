using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public HandlePlayer playerHandler;

	[SerializeField] private Transform posResSecondPlayer;
    public int quant = 0;
    public Text quantText;
	public GameObject screenDead,player;

	private void Update()
	{
		quantText.text = quant + "/8";
		if (playerHandler.ImDead) screenDead.SetActive(true);

	}

	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}
}
