using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TesteButton : MonoBehaviour
{
    [SerializeField]
    Text mensagem;

    [SerializeField]
    GameObject MenuPausa;

    public void MenuPrincipal_CliqueBotaoContinuar()
    {
        mensagem.text = "Isto é um teste";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (MenuPausa != null)
            {
                MenuPausa.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void MenuPausa_Continuar()
    {
        if (MenuPausa != null)
        {
            MenuPausa.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void MenuPausa_Sair()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void MenuPrincipal_Iniciar()
    {
        SceneManager.LoadScene("nivel1");
    }

    public void MenuPrincipal_Terminar()
    {
        Application.Quit();
    }

   public void RecomecarNivel()
    {
        Time.timeScale = 1;

        FindObjectOfType<GameManager>().recomecarNivel();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuPrincipal_Continuar()
    {
        int cena = PlayerPrefs.GetInt("nivel", -1);
        if (cena == -1)
            MenuPrincipal_Iniciar();
        else
            SceneManager.LoadScene(cena);
    }
}
