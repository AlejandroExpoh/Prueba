using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public bool estaPausado = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (estaPausado)
            {
                pausa();
            }
            else
            {
                continuar();
            }
        }
    }

    public void pausa()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = false;
    }

    public void continuar()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = true;
    }

    public void salir()
    {
        Application.Quit();
    }

    public void irmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
}
