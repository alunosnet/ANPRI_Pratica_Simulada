using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveNPC : MonoBehaviour
{
    [SerializeField]
    Transform[] pontos; //este vetor terá os pontos em que o NPC vai passar
    public int proximoPonto = 0;
    [SerializeField]
    float velocidade;
    [SerializeField]
    float distanciaMinima = 5;
    [SerializeField]
    bool emMovimento = false;
    Rigidbody _rigidbody;

    //NavMesh
    NavMeshAgent _navMeshAgent;

    //Animator
    Animator _animator;

    void Start()
    {
        if (pontos.Length == 0)
        {
            Debug.Log("Tem de indicar os pontos a percorrer");
            return;
        }
        _rigidbody = GetComponent<Rigidbody>();     //faz cache do rigidbody
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pontos.Length == 0)
        {
            Debug.Log("Tem de indicar os pontos a percorrer");
            return;
        }
        //distancia para o próximo ponto
        //Debug.Log(Vector3.Distance(transform.position, pontos[proximoPonto].position));
        if (Vector3.Distance(transform.position, pontos[proximoPonto].position) < distanciaMinima)
        {
            //passa para o próxmo
            proximoPonto++;
            if (proximoPonto > pontos.Length - 1)   //não tem mais pontos volta ao inicio
                proximoPonto = 0;
        }
        ////direcao
        //Vector3 direcao = pontos[proximoPonto].position - transform.position;
        ////rodar na direção do próximo ponto
        //Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
        //transform.rotation = rotacao;
        ////anda na direção do ponto
        ////transform.Translate(Vector3.forward*velocidade*Time.deltaTime);
        //_rigidbody.MovePosition(transform.position + (transform.forward *velocidade* Time.deltaTime));
        _navMeshAgent.SetDestination(pontos[proximoPonto].position);

        _animator.SetFloat("velocidade", _navMeshAgent.velocity.magnitude);
    }
}
