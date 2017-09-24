using UnityEngine;
using System.Collections.Generic;

public class CharacterCommand : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float turnSpeed = 200;
    [SerializeField] private float jumpForce = 4;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController character;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool wasGrounded;
    private Vector3 currentDirection = Vector3.zero;

    private float jumpTimeStamp = 0;
    private float minJumpInterval = 0.25f;

    private List<Collider> m_collisions = new List<Collider>();

    void Update()
    {
        animator.SetBool("Grounded", character.isGrounded);
        DirectUpdate();
        wasGrounded = character.isGrounded;
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            currentDirection = Vector3.Slerp(currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(currentDirection);
            character.SimpleMove(currentDirection * moveSpeed * Time.deltaTime);

            animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - jumpTimeStamp) >= minJumpInterval;

        if (jumpCooldownOver && character.isGrounded && Input.GetAxis("Fire1") > 0)
        {
            jumpTimeStamp = Time.time;
            character.SimpleMove(Vector3.up * jumpForce);
        }

        if (!wasGrounded && character.isGrounded)
        {
            animator.SetTrigger("Land");
        }

        if (!character.isGrounded && wasGrounded)
        {
            animator.SetTrigger("Jump");
        }
    }
}
