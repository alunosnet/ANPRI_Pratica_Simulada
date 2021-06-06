using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
            _animator.SetTrigger("AbrePorta");
    }

    public void PortaFechada()
    {
        Debug.Log("A porta está fechada");
    }
    public void PortaAberta()
    {
        Debug.Log("A porta está aberta");
    }
}
