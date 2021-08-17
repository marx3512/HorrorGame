using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int quant = 0;
    public Text quantText;

	private void Update()
	{
		quantText.text = quant + "/8";
	}
}
