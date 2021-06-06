using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saude : MonoBehaviour
{
    [SerializeField]
    int vida = 100;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public int GetVida()
    {
        return vida;
    }

    public void retiraVida(int valor)
    {
        vida -= valor;
        if (_audioSource != null)
            _audioSource.Play();
        
    }

   public void adicionarVida(int valor)
    {
        vida += valor;
    }

    private void Update()
    {
        if (vida <= 0)
            Destroy(this.gameObject);
    }
}
