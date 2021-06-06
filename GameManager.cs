using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Mudar de nível
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    int TotalOvos;
    [SerializeField]
    int NrOvosDoNivel;
    [SerializeField]
    int OvosApanhadosNesteNivel;
    [SerializeField]
    Text DadosJogo;
    [SerializeField]
    GameObject MenuDerrota;

    //player
    GameObject player;

    void Awake()
    {
        //garantir que só existe um
        GameManager[] ops = GameObject.FindObjectsOfType<GameManager>();
        if (ops.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        //evento para quando cena é carregada
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //sempre que uma cena é carregada
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex == 0) return;

        //contar ovos
        NrOvosDoNivel = FindObjectsOfType<Apanhar>().Length;

        if (DadosJogo == null)
            DadosJogo = GameObject.FindGameObjectWithTag("TxtOvos").GetComponent<Text>();

        AtualizarDadosJogador();

        if (MenuDerrota == null)
            MenuDerrota=GameObject.FindObjectOfType<Canvas>().transform.Find("MenuDerrota").gameObject;
//            MenuDerrota = GameObject.FindGameObjectWithTag("MenuDerrota");

        if (MenuDerrota != null)
            MenuDerrota.SetActive(false);

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        OvosApanhadosNesteNivel = 0;

        //guardar o nível atual
        if (PlayerPrefs.GetInt("nivel", 0) < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("nivel", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
    }

    private void AtualizarDadosJogador()
    {
        if (DadosJogo != null)
            DadosJogo.text = "Ovos no nível: " + (NrOvosDoNivel-OvosApanhadosNesteNivel )+ " | Total de ovos: " + TotalOvos;
    }

    public void recomecarNivel()
    {
        TotalOvos -= OvosApanhadosNesteNivel;
    }

    public void adicionaOvo()
    {
        TotalOvos++;
        OvosApanhadosNesteNivel++;
        AtualizarDadosJogador();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        AtualizarDadosJogador();
        if (player == null)
        {
            MenuDerrota.SetActive(true);
            Time.timeScale = 0;
        }

        if (NrOvosDoNivel == OvosApanhadosNesteNivel)
        {
            if(SceneManager.GetActiveScene().buildIndex<SceneManager.sceneCountInBuildSettings-1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene("MenuPrincipal");

        }

    }
}
