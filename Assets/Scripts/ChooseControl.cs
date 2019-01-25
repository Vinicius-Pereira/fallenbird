using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseControl : MonoBehaviour {

    public GameObject menu;
    public GameObject player;

    public void Awake()
    {
        //Pausa o jogo
        PauseGame();
    }

    //Define o tipo de controle
    public void SwitchControl(int control)
    {
        if(control == 0)
        {
            PlayerPrefs.SetString("Control", "Touch");
        }
        else if(control == 1)
        {
            PlayerPrefs.SetString("Control", "Accelerometer");
        }
        else
        {
            PlayerPrefs.SetString("Control", "Arrows");
        }
        ContinueGame();
    }
    //Pausa o jogo
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    //Reinicia o jogo e informa o modo de controle do player
    private void ContinueGame()
    {
        Time.timeScale = 1;
        player.GetComponent<Player>().setControlMode();
        menu.SetActive(false);
    }
}
