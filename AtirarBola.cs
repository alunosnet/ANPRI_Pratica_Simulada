using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AtirarBola : MonoBehaviour
{
    public GameObject _modeloBola;
    public Transform _pontoAtirar;
    public float forcaAtirar = 5;

    private void Start()
    {
    }
    void Update()
    {
            //atirar bola com fire1
            if (CrossPlatformInputManager.GetButtonDown("Fire1") && Time.timeScale != 0)
            {
                var objeto = Instantiate(_modeloBola, _pontoAtirar.position, Quaternion.identity);
                objeto.GetComponent<Rigidbody>().AddForce(transform.forward * forcaAtirar);
            }
    }
}
