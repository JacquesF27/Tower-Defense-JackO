using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesSurvived : MonoBehaviour
{
    public Text wavesText;

	private void OnEnable()
	{
		StartCoroutine(AnimateText());
	}

	IEnumerator AnimateText()
	{
		wavesText.text = "0";
		int wave = 0;

		yield return new WaitForSeconds(.7f);

		while (wave < PlayerStats.waves)
		{
			wave++;
			wavesText.text = wave.ToString();

			yield return new WaitForSeconds(.05f);
		}
	}
}
