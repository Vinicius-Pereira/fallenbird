using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsBarController : MonoBehaviour {

    [Range(0,1000)]
    public float fillAmount = 1.0f;

    public Image content;
    public Text textContent;
    public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fillAmount = player.soulEnergy;
		HandleBar();
	}

    private void HandleBar()
    {

        content.fillAmount = Map(fillAmount, 0, 1000, 0, 1);
        textContent.text = "Souls: " + Mathf.Round(content.fillAmount * 100) + "%";
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
