using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMe : MonoBehaviour
{
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("DropPoint"))
        {
            //desativar apanhar
            //transform.GetComponent<Apanhar>().enabled = false;
            //remover script para que o ovo não possa ser apanhado
            Destroy(GetComponent<Apanhar>());
            Destroy(GetComponent<DropMe>());
            //cair
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
            if (_gameManager == null) _gameManager = GameObject.FindObjectOfType<GameManager>();
            _gameManager.adicionaOvo();
            transform.position += Vector3.up * 2;
        }
    }

}
