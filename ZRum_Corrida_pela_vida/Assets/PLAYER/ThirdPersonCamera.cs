using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;          // Jogador
    public Vector3 offset = new Vector3(0, 3, -6); // Posição inicial da câmera
    public float sensitivity = 5f;    // Sensibilidade do mouse
    public float distance = 6f;       // Distância da câmera
    public float minY = -20f;         // Limite inferior de ângulo (olhar para baixo)
    public float maxY = 80f;          // Limite superior de ângulo (olhar para cima)
    public float smoothSpeed = 10f;   // Suavização do movimento

    float rotX = 0f; // Rotação no eixo X (vertical)
    float rotY = 0f; // Rotação no eixo Y (horizontal)

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotY = angles.y;
        rotX = angles.x;

        Cursor.lockState = CursorLockMode.Locked;  // Trava o cursor no centro da tela
        Cursor.visible = false;                    // Esconde o cursor
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
        // Movimenta com o mouse
        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX -= Input.GetAxis("Mouse Y") * sensitivity;

        // Limita a rotação vertical
        rotX = Mathf.Clamp(rotX, minY, maxY);

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position + offset;
        // Suaviza o movimento
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothSpeed);
        transform.LookAt(target.position + Vector3.up * offset.y);
    }
}
