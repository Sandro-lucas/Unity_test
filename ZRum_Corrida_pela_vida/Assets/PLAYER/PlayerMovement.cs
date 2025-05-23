using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float speed = 6f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Checa se está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Entrada de movimento no teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movimento na direção da câmera
        Vector3 direction = (cameraTransform.right * horizontal + cameraTransform.forward * vertical).normalized;
        direction.y = 0f; // Mantém o movimento apenas no plano XZ

        // Verifica se está correndo (Shift segurado)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * currentSpeed * Time.deltaTime);
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
