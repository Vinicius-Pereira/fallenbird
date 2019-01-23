using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseControl : MonoBehaviour {

    public GameObject menu;
    public GameObject player;

    public void Awake()
    {
        PauseGame();
    }

    public void SwitchControl(int control)
    {
        if(control == 0)
        {
            PlayerPrefs.SetString("Control", "Touch");
        }
        else
        {
            PlayerPrefs.SetString("Control", "Accelerometer");
        }
        ContinueGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        player.GetComponent<Player>().setControlMode();
        menu.SetActive(false);
    }
}
