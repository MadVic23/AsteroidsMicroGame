using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    private bool estaPausado = false;

    public GameObject menuPausa;
    public GameObject Life1,Life2,Life3;


    private void Start()
    {
        menuPausa.SetActive(false);
        Life1.SetActive(true);
        Life2.SetActive(true);
        Life3.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausa();
        }
        if(Player.LIFES == 2){
            Life3.SetActive(false);
        }
        if(Player.LIFES == 1){
            Life2.SetActive(false);
        }
        if(Player.LIFES == 0){
            Life2.SetActive(true);
        }

    }

    public void Reanudar(){
         
         Time.timeScale = 1; // Reanuda el tiempo en la escena.
         menuPausa.SetActive(false);
    }

    public void TogglePausa()
    {
        estaPausado = !estaPausado;

        if (estaPausado)
        {
            menuPausa.SetActive(true);
            Time.timeScale = 0; // Pausa el tiempo en la escena.
        }
        else
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1; // Reanuda el tiempo en la escena.
        }

}
}