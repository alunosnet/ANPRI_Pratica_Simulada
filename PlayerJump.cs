using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    CharacterController _characterController;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private bool isJumping;
    [SerializeField] bool playerGrounded;
    Animator _animator;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            _animator.SetTrigger("jump");
            StartCoroutine(JumpEvent());
        }
        playerGrounded = _characterController.isGrounded;
    }

    private IEnumerator JumpEvent()
    {
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir) * jumpMultiplier * Time.deltaTime;

            _characterController.Move(Vector3.up * jumpForce);
            
            timeInAir += Time.deltaTime;
            
            playerGrounded = _characterController.isGrounded;
            isJumping = !_characterController.isGrounded;

            yield return null;
        } while (_characterController.collisionFlags != CollisionFlags.Above && isJumping == true);
        isJumping = false;
    }
}
