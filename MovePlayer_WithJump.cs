using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class MovePlayer_WithJump : MonoBehaviour
{
    public float velocidadeAndar = 5;
    public float velocidadeRodar = 5;
    CharacterController _characterController;
    private float inputAndar;
    private float inputRodar;
    [SerializeField]
    Animator _animator;

    //jump
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    bool PlayerGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputAndar = Input.GetAxis("Vertical"); //andar para frente e para trás
        inputRodar = Input.GetAxis("Horizontal");   //rodar para esquerda e direita

        //definir o parametro velocidade
        //_animator.SetFloat("velocidade", inputAndar);

        PlayerGrounded = _characterController.isGrounded;
        if (PlayerGrounded) isJumping = false;

        Vector3 novaPosicao = transform.forward * velocidadeAndar * inputAndar;
        if(isJumping==false)
            novaPosicao.y = Physics.gravity.y;

        JumpInput();
        _characterController.Move(novaPosicao * Time.deltaTime);

        if (isJumping) return;
        _characterController.transform.Rotate(_characterController.transform.up * velocidadeRodar * inputRodar);

    }
    private void JumpInput()
    {
        if (Input.GetButtonDown("Jump") && isJumping==false)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }
    private IEnumerator JumpEvent()
    {
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir) * jumpMultiplier * Time.deltaTime;
            
            _characterController.Move(Vector3.up * jumpForce);
            timeInAir += Time.deltaTime;

            yield return null;
        } while (!_characterController.isGrounded && _characterController.collisionFlags != CollisionFlags.Above && isJumping==true);
        isJumping = false;
    }
}
