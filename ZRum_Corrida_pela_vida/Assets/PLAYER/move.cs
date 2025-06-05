using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class move : MonoBehaviour
{
    private CharacterController controller;
    private Transform myCamera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = myCamera.TransformDirection(movimento);
        movimento.y = 0; // Ensure no vertical movement
        controller.Move(movimento * Time.deltaTime * 5);
        controller.Move(new Vector3(0, -9.81f * Time.deltaTime, 0));
        if (movimento != Vector3.zero)
        {
            
         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento),
          Time.deltaTime * 10);
    }
    }// Gravity effect
       
}
