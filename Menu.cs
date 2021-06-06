using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject _menuContinuar;
    [SerializeField]
    Text mensagens;

    public void MenuPausa_Continuar()
    {
        //esconder menu pausa
        _menuContinuar.SetActive(false);
        //reativar o tempo
        Time.timeScale = 1;
    }

    #region MenuPrincipal
    public void IniciarJogo()
    {
        SceneManager.LoadScene("nivel1");
    }
    public void IniciarJogoAssinc()
    {
        StartCoroutine(LoadYourAsyncScene("nivel1"));
    }
    IEnumerator LoadYourAsyncScene(string nome)
    {
        //Unity começa a carregar a cena mas não espera que termine de carregar
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nome);

        //esta propriedade permite saber quando terminou de carregar
        while (!asyncLoad.isDone)
        {
            mensagens.text = "Temos de esperar.";

            yield return null;
        }
    }

    public void TerminarJogo()
    {
        Application.Quit();
    }

    #endregion

    private void Update()
    {
        //menu pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //para o tempo
            Time.timeScale = 0;
            _menuContinuar.SetActive(true);
        }
    }
}
