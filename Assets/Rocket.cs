using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rgbd;
    AudioSource audiosource;

    void Start()
    {
       rgbd = GetComponent<Rigidbody>(); 
       audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
       ProcessInput(); 
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rgbd.AddRelativeForce(Vector3.up);
            audiosource.Play();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

    }
}
