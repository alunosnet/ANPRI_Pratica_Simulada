using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class MovePlayer : MonoBehaviour
{
    public float velocidadeAndar = 5;
    public float velocidadeRodar = 5;
    CharacterController _characterController;
    private float inputAndar;
    private float inputRodar;

    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputAndar = CrossPlatformInputManager.GetAxis("Vertical");
        inputRodar = CrossPlatformInputManager.GetAxis("Horizontal");

        _animator.SetFloat("velocidade", inputAndar);

        Vector3 novaPosicao = transform.forward * velocidadeAndar * inputAndar;
        novaPosicao.y += Physics.gravity.y;

        _characterController.Move(novaPosicao * Time.deltaTime);

        _characterController.transform.Rotate(_characterController.transform.up * velocidadeRodar * inputRodar);

    }

}
