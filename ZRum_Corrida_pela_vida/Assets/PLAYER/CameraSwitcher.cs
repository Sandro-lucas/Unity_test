using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    private bool isFirstPerson = true;

    void Start()
    {
        ActivateFirstPerson();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
                ActivateFirstPerson();
            else
                ActivateThirdPerson();
        }
    }

    void ActivateFirstPerson()
    {
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;
    }

    void ActivateThirdPerson()
    {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
    }
}
