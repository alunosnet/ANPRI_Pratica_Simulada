using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePorta : MonoBehaviour
{
    [SerializeField]
    Transform pontoInicial; //porta fechada
    [SerializeField]
    Transform pontoFinal; //porta aberta
    public float incY = 1;      //porta sobre e desce

    void Start()
    {
        //ponto inicial
        transform.position = pontoInicial.position;
    }

    void FixedUpdate()
    {
        //calcular nova posição
        Vector3 novaPosicao = transform.position;
        novaPosicao.y += incY * Time.deltaTime;
        transform.position = novaPosicao;

        //verificar se já fechou/abriu
        if (incY > 0) {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoFinal.position)) < 0.1)
                incY *= -1;
        }
        else
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoInicial.position)) < 0.1)
                incY *= -1;
        }
    }
}
